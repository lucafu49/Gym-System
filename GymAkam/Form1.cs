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
    public partial class Form1 : Form
    {

        DateTime date;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;

            // Usa la cadena de conexión para conectarte a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Cliente (Nombre, Apellido, FechaNacimiento, Genero, Telefono, Direccion, FechadePago, Lesiones) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Genero, @Telefono, @Direccion, @FechadePago, @Lesiones)";

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre",txt_name.Text);
                        command.Parameters.AddWithValue("@Apellido",txt_lastName.Text);
                        command.Parameters.AddWithValue("@FechaNacimiento",txt_birthDate.Text);
                        command.Parameters.AddWithValue("@Genero",txt_genre.Text);
                        command.Parameters.AddWithValue("@Telefono",txt_phone.Text);
                        command.Parameters.AddWithValue("@Direccion",txt_address.Text);
                        command.Parameters.AddWithValue("@FechadePago",date.Day.ToString());
                        command.Parameters.AddWithValue("@Lesiones",txt_injury.Text);

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

        //private void button1_click(object sender, eventargs e)
        //{
        //    // obtén la cadena de conexión desde el archivo app.config
        //    string connectionstring = configurationmanager.connectionstrings["gymakam.properties.settings.gymakamconnectionstring"].connectionstring;

        //    // usa la cadena de conexión para conectarte a la base de datos
        //    using (sqlconnection connection = new sqlconnection(connectionstring))
        //    {
        //        try
        //        {
        //            connection.open();
        //            messagebox.show("conexión exitosa a la base de datos.");

        //            // aquí puedes ejecutar tus comandos sql
        //        }
        //        catch (exception ex)
        //        {
        //            messagebox.show("error al conectar a la base de datos: " + ex.message);
        //        }
        //    }
        //}


    }
}
