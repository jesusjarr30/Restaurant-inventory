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
    public partial class v_notificaciones : Form
    {
        ConexionPostgreSql conectandose;
        public v_notificaciones(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void v_notificaciones_Load(object sender, EventArgs e)
        {
            //aqui el codigo

             data_stock.DataSource = conectandose.stock();
            //data_caducar.DataSource = conectandose.caducar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void data_stock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
