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
    public partial class modificar_registro : Form
    {
        ConexionPostgreSql conectandose;
        public modificar_registro(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void modificar_registro_Load(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            //llamara funcion de busqueda 

            try
            {
                int id_producto = Convert.ToInt32(txb_id.Text);
                data.DataSource = conectandose.mostrar_producto(id_producto);
            }
            catch(Exception)
            {
                MessageBox.Show("Ingrese datos correctos");
                this.Close();
            }
            
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id_producto = Convert.ToInt32(txb_id.Text);
               
                conectandose.modificar_producto(id_producto, txb_nombre.Text, txb_precio.Text, txb_proveedor.Text, txb_compania.Text, txb_stock.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese datos validos");
            }
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
