using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymAkam
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private bool DNIRepetido(string dni)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Cliente WHERE DNI = @DNI";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DNI", dni);
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Si el count es mayor a 0, significa que el DNI ya existe
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar el DNI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int? searchClientByDNI(string dni)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ClienteID FROM Cliente WHERE DNI = @DNI";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DNI", dni);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Devuelve el ID del cliente encontrado
                        }
                        else
                        {
                            return null; // No se encontró ningún cliente con ese DNI
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }


        private void btn_register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) ||
                string.IsNullOrWhiteSpace(txt_surname.Text) ||
                string.IsNullOrWhiteSpace(txt_birthDate.Text) ||
                string.IsNullOrWhiteSpace(txt_genre.Text) ||
                string.IsNullOrWhiteSpace(txt_phone.Text) ||
                string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_injury.Text) ||
                string.IsNullOrWhiteSpace(txt_dni.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de registrar al cliente.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificamos si el DNI ya está registrado
            if (DNIRepetido(txt_dni.Text))
            {
                MessageBox.Show("El DNI ingresado ya está registrado. Por favor, verifica los datos.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Consulta para insertar un nuevo cliente
                    string query = "INSERT INTO Cliente (Nombre, Apellido, DNI, FechaNacimiento, Genero, Telefono, Direccion, Lesiones) VALUES (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Genero, @Telefono, @Direccion, @Lesiones)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", txt_name.Text);
                        command.Parameters.AddWithValue("@Apellido", txt_surname.Text);
                        command.Parameters.AddWithValue("@DNI", txt_dni.Text);
                        command.Parameters.AddWithValue("@FechaNacimiento", txt_birthDate.Text);
                        command.Parameters.AddWithValue("@Genero", txt_genre.Text);
                        command.Parameters.AddWithValue("@Telefono", txt_phone.Text);
                        command.Parameters.AddWithValue("@Direccion", txt_address.Text);
                        command.Parameters.AddWithValue("@Lesiones", txt_injury.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cliente registrado exitosamente");

                        // Registrar la transacción
                        string queryDate = "INSERT INTO Transacciones (IDCliente, Monto, FechaPago, FechaVencimiento) VALUES (@IDCliente, @Monto, @FechaPago, @FechaVencimiento)";
                        var idSearch = searchClientByDNI(txt_dni.Text);

                        using (SqlCommand commandDate = new SqlCommand(queryDate, connection))
                        {
                            commandDate.Parameters.AddWithValue("@IDCliente", idSearch);
                            commandDate.Parameters.AddWithValue("@Monto", txt_mount.Text);
                            commandDate.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                            commandDate.Parameters.AddWithValue("@FechaVencimiento", txt_expirationDate.Text);

                            commandDate.ExecuteNonQuery();
                            MessageBox.Show("Transacción registrada exitosamente");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ocurrió un error al registrar el cliente: {ex.Message} ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
