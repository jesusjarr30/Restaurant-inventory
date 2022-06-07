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
    public partial class v_ven : Form
    {
        ConexionPostgreSql conectandose;
        public v_ven(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose=vinculo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void v_ven_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txb_nombre.Text.Length!= 0 && txb_compania.Text.Length != 0 && txb_precio.Text.Length !=0 && txb_proveedor.Text.Length !=0 &&
                txb_stock.Text.Length !=0)
            {
                string precio_s = txb_precio.Text;
               
                    decimal asd = System.Convert.ToDecimal(precio_s);
                    int regreso = conectandose.nuevo_producto(txb_nombre.Text, txb_compania.Text, asd, txb_proveedor.Text, txb_stock.Text);
                    string cadena = "El id del producto registrado es " + regreso + ".";
                    MessageBox.Show(cadena);
       
            }
            else
            {
                
                MessageBox.Show("Favor de llenar todos los campos");
            }
            txb_compania.Clear();
            txb_nombre.Clear();
            txb_precio.Clear();
            txb_proveedor.Clear();
            txb_stock.Clear();
            this.Close();

        }
    }
}
