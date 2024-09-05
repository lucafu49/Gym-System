using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GymAkam
{
    public partial class Cliente : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;

        public Cliente()
        {
            InitializeComponent();
            CargarClientesEnGridView();
        }

        private void CargarClientesEnGridView(string whereClause = "", string searchText = "", bool? habilitado = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
            SELECT 
                c.ClienteID,
                c.Nombre,
                c.Apellido,
                c.DNI,
                c.Habilitado,
                t.FechaVencimiento AS UltimaFechaVencimiento
            FROM 
                Cliente c
            LEFT JOIN 
            (
                SELECT IDCliente, FechaVencimiento
                FROM Transacciones
                WHERE IDTransaccion = (
                    SELECT MAX(IDTransaccion)
                    FROM Transacciones AS t2
                    WHERE t2.IDCliente = Transacciones.IDCliente
                )
            ) AS t
            ON c.ClienteID = t.IDCliente
            ";

                    // Construir el WHERE clause
                    List<string> conditions = new List<string>();

                    // Si hay texto de búsqueda (por Apellido o DNI)
                    if (!string.IsNullOrEmpty(whereClause))
                    {
                        conditions.Add(whereClause);
                    }

                    // Si hay un filtro de habilitación
                    if (habilitado.HasValue)
                    {
                        conditions.Add($"c.Habilitado = {(habilitado.Value ? 1 : 0)}");
                    }

                    // Combinar todas las condiciones
                    if (conditions.Count > 0)
                    {
                        query += " WHERE " + string.Join(" AND ", conditions);
                    }

                    query += @"
            GROUP BY 
                c.ClienteID,
                c.Nombre,
                c.Apellido,
                c.DNI,
                c.Habilitado,
                t.FechaVencimiento;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir el parámetro de búsqueda si es necesario
                        if (!string.IsNullOrEmpty(searchText))
                        {
                            command.Parameters.AddWithValue("@SearchText", searchText);
                        }

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            dt_client.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ASIGNAR DATOS DE CELDA EN textBox
        private void dt_client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_clientID.Text = dt_client.SelectedCells[0].Value.ToString();
            txt_name.Text = dt_client.SelectedCells[1].Value.ToString();
            txt_surname.Text = dt_client.SelectedCells[2].Value.ToString();
            txt_dni.Text = dt_client.SelectedCells[3].Value.ToString();
            txt_enabled.Text = dt_client.SelectedCells[4].Value.ToString();
        }

        //RENOVAR CLIENTE
        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Comenzamos una transacción para asegurar que ambas operaciones se completen juntas.
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 1. Actualizar el estado del cliente
                        string updateQuery = "UPDATE Cliente SET Habilitado = 1 WHERE ClienteID = @ClienteID";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@ClienteID", txt_clientID.Text);
                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("No se encontró ningún cliente con el ID especificado.");
                            }
                        }

                        // 2. Insertar una nueva transacción
                        string insertQuery = @"
                    INSERT INTO Transacciones (IDCliente, Monto, FechaPago, FechaVencimiento) 
                    VALUES (@IDCliente, @Monto, @FechaPago, @FechaVencimiento)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                        {
                            insertCommand.Parameters.AddWithValue("@IDCliente", txt_clientID.Text);
                            insertCommand.Parameters.AddWithValue("@Monto", txt_mount.Text); // Asumiendo que tienes un TextBox para el monto
                            insertCommand.Parameters.AddWithValue("@FechaPago", DateTime.Now);

                            // Asumiendo que tienes un TextBox para ingresar la fecha de vencimiento
                            insertCommand.Parameters.AddWithValue("@FechaVencimiento", DateTime.Parse(txt_expirationDate.Text));

                            insertCommand.ExecuteNonQuery();
                        }

                        // Si ambas operaciones tuvieron éxito, hacemos commit a la transacción
                        transaction.Commit();

                        MessageBox.Show("Cliente actualizado correctamente y transacción registrada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientesEnGridView();
                    }
                    catch (Exception ex)
                    {
                        // Si algo salió mal, hacemos rollback a la transacción
                        transaction.Rollback();
                        MessageBox.Show($"Error al actualizar el cliente o registrar la transacción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //BORRAR POR ID
        private void txt_delete_Click(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Cliente WHERE ClienteID= @IdCliente";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@IdCliente", txt_clientID.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente Borrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientesEnGridView();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún cliente con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al actualizar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BUSQUEDA
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string whereClause = "";
                    string searchText = txt_search.Text;
                    bool? habilitado = null; // Por defecto, no se filtra por habilitación

                    // Verificar la opción seleccionada en el ComboBox de filtro
                    if (cb_options.SelectedItem != null)
                    {
                        switch (cb_options.SelectedItem.ToString())
                        {
                            case "Buscar por DNI":
                                whereClause = "c.DNI = @SearchText";
                                break;

                            case "Buscar por Apellido":
                                whereClause = "c.Apellido LIKE @SearchText";
                                searchText = $"%{searchText}%";
                                break;

                            default:
                                MessageBox.Show("Seleccione una opción de búsqueda válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }
                    }

                    // Verificar el filtro de habilitación
                    if (comboBox1.SelectedItem != null)
                    {
                        switch (comboBox1.SelectedItem.ToString())
                        {
                            case "Habilitados":
                                habilitado = true;
                                break;

                            case "Vencidos":
                                habilitado = false;
                                break;

                            case "Todos":
                                habilitado = null; // No filtrar por habilitación
                                break;
                        }
                    }

                    // Llamar a CargarClientesEnGridView con ambos filtros
                    CargarClientesEnGridView(whereClause, searchText, habilitado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
