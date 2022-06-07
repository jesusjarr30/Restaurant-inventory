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
    public partial class listado_p : Form
    {
        ConexionPostgreSql conectandose;
        public listado_p(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void listado_p_Load(object sender, EventArgs e)
        {
            data_listado.DataSource = conectandose.listado_productos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void data_listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
