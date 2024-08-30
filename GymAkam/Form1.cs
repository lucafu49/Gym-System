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
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }

        private void btn_renew_Click(object sender, EventArgs e)
        {
            Contabilidad c = new Contabilidad();
            c.Show();
        }
    }
}
