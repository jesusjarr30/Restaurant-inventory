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
    public partial class ingreso_p : Form
    {
        ConexionPostgreSql conectandose;
        public ingreso_p(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ingreso_p_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txb_cantidad.Text.Length != 0 && txb_codigo.Text.Length != 0 && txb_dia.Text.Length != 0 && txb_mes.Text.Length != 0 && txb_year.Text.Length != 0)
            {
                try
                {
                    string dia_s = txb_dia.Text;
                    string mes_s = txb_mes.Text;
                    string year_s = txb_year.Text;
                    string cantidad_s = txb_cantidad.Text;
                    string id_producto = txb_codigo.Text;
                    int dia = Convert.ToInt32(dia_s);
                    int mes = Convert.ToInt32(mes_s);
                    int year = Convert.ToInt32(year_s);
                    int id = Convert.ToInt32(id_producto);
                    int cantidad = Convert.ToInt32(cantidad_s);

                    bool validacion = conectandose.ingresar_producto(id, cantidad, dia, mes, year);
                    if (validacion)
                    {
                        MessageBox.Show("Se ingreso correctamente");
                        this.Close();
                    }
                }
                catch(Exception){
                    MessageBox.Show("Asegurese de ingresar correctamente ");
                }
            }
        
            else
            {
                MessageBox.Show("Asegurese de ingresar correctamente ");
            }
            txb_cantidad.Clear();
            txb_codigo.Clear();
            txb_dia.Clear();
            txb_mes.Clear();
            txb_year.Clear();
        }
    }
}
