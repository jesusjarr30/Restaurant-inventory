using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control
{
    public partial class modificar_user : Form
    {
        ConexionPostgreSql conectandose;
        public modificar_user(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void modificar_user_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.DataSource = conectandose.consultar(txb_id.Text);
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            conectandose.modificar_user(txb_id.Text,txb_nombre.Text,txb_dirreccion.Text,txb_rfc.Text,txb_seguro.Text);
            MessageBox.Show("Se realizaon las actulizaciones necesarias");
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
