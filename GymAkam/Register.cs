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

        private void btn_register_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_name.Text) ||
                string.IsNullOrWhiteSpace(txt_surname.Text) ||
                string.IsNullOrWhiteSpace(txt_birthDate.Text) ||
                string.IsNullOrWhiteSpace(txt_genre.Text) ||
                string.IsNullOrWhiteSpace(txt_phone.Text) ||
                string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_injury.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de registrar al cliente.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;

            // Usa la cadena de conexión para conectarte a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Cliente (Nombre, Apellido,DNI, FechaNacimiento, Genero, Telefono, Direccion, FechadePago, Lesiones) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Genero, @Telefono, @Direccion, @FechadePago, @Lesiones)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", txt_name.Text);
                        command.Parameters.AddWithValue("@Apellido", txt_surname.Text);
                        command.Parameters.AddWithValue("@FechaNacimiento", txt_birthDate.Text);
                        command.Parameters.AddWithValue("@Genero", txt_genre.Text);
                        command.Parameters.AddWithValue("@Telefono", txt_phone.Text);
                        command.Parameters.AddWithValue("@Direccion", txt_address.Text);
                        command.Parameters.AddWithValue("@FechadePago", DateTime.Now);
                        command.Parameters.AddWithValue("@Lesiones", txt_injury.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cliente registrado exitosamente");
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
