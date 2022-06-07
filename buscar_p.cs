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
    public partial class buscar_p : Form
    {
        ConexionPostgreSql conectandose;
        public buscar_p(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txb_codigo.Text);
            data_producto.DataSource = conectandose.busqueda_lotes(codigo);
        }

        private void buscar_p_Load(object sender, EventArgs e)
        {
            data_todo.DataSource = conectandose.suma_productos();
        }

        private void data_todo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
