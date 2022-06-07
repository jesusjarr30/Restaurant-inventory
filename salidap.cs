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
    public partial class salidap : Form
    {
        ConexionPostgreSql conectandose;
        string cadena;
        public salidap(ConexionPostgreSql vinculo,string id)
        {
            InitializeComponent();
            conectandose = vinculo;
            cadena = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void salidap_Load(object sender, EventArgs e)
        {
            data_todo.DataSource = conectandose.suma_productos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void data_todo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = Convert.ToInt32(txb_piezas.Text);
                int id_producto = Convert.ToInt32(txb_codigo.Text);
                conectandose.salida(id_producto, cantidad,cadena);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese datos validos ");
            }

            this.Close();
               
        }
    }
}
