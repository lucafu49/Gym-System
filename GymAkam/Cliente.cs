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

        private void CargarClientesEnGridView()
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
                    MAX(t.FechaVencimiento) AS UltimaFechaVencimiento
                FROM 
                    Cliente c
                LEFT JOIN 
                    Transacciones t ON c.ClienteID = t.IDCliente
                WHERE 
                    c.Habilitado = 0
                GROUP BY 
                    c.ClienteID,
                    c.Nombre,
                    c.Apellido,
                    c.DNI,
                    c.Habilitado;";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        dt_client.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_clientID.Text = dt_client.SelectedCells[0].Value.ToString();
            txt_name.Text = dt_client.SelectedCells[1].Value.ToString();
            txt_surname.Text = dt_client.SelectedCells[2].Value.ToString();
            txt_dni.Text = dt_client.SelectedCells[3].Value.ToString();
            txt_enabled.Text = dt_client.SelectedCells[4].Value.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Cliente SET Habilitado = 1, FechadePago = @DiaActual WHERE ClienteID = @ClienteID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DiaActual", DateTime.Now.Day);
                        command.Parameters.AddWithValue("@ClienteID", txt_clientID.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ClienteID,Nombre,Apellido,DNI,Habilitado FROM Cliente";

                    if (!string.IsNullOrEmpty(txt_search.Text))
                    {
                        query += " WHERE DNI = @DNIsearch";
                    }

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(txt_search.Text))
                        {
                            command.Parameters.AddWithValue("@DNIsearch", txt_search.Text);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox1.SelectedItem.ToString();

            switch (value)
            {
                case "Habilitados":
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "SELECT ClienteID,Nombre,Apellido,DNI,Habilitado FROM Cliente WHERE Habilitado = 1";

                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
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
                    break;
                case "Vencidos":
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "SELECT ClienteID,Nombre,Apellido,DNI,Habilitado FROM Cliente WHERE Habilitado = 0";

                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
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
                    break;
                case "Todos":
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "SELECT ClienteID,Nombre,Apellido,DNI,Habilitado FROM Cliente";

                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
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
                    break;

                default:
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "SELECT ClienteID,Nombre,Apellido,DNI,Habilitado FROM Cliente";

                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
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
                    break;
            }
        }
    }
}
