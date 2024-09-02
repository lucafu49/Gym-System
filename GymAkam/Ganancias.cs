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
    public partial class Ganancias : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["GymAkam.Properties.Settings.GymAkamConnectionString"].ConnectionString;

        public Ganancias()
        {
            InitializeComponent();
            cargarGanancias();
        }

        private void cargarGanancias()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Transacciones";

                    // Si ambos campos de fecha están completos, agregamos el filtro de rango de fechas
                    if (!string.IsNullOrWhiteSpace(txt_from.Text) && !string.IsNullOrWhiteSpace(txt_to.Text))
                    {
                        query += " WHERE FechaPago BETWEEN @FechaInicio AND @FechaFin";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Si se han completado ambos campos de fecha, agregamos los parámetros
                        if (!string.IsNullOrWhiteSpace(txt_from.Text) && !string.IsNullOrWhiteSpace(txt_to.Text))
                        {
                            command.Parameters.AddWithValue("@FechaInicio", txt_from.Text);
                            command.Parameters.AddWithValue("@FechaFin", txt_to.Text);
                        }

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            gv_transactions.DataSource = dataTable;

                            // Calcular la ganancia total
                            decimal gananciaTotal = 0;

                            foreach (DataRow row in dataTable.Rows)
                            {
                                gananciaTotal += Convert.ToDecimal(row["Monto"]);
                            }

                            lbl_profit.Text = $"Ganancia Total: {gananciaTotal:C}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular las ganancias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            cargarGanancias();
        }

    }
}
