using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace control
{
    public partial class new_usuario : Form
    {
        ConexionPostgreSql conectandose;


        public new_usuario(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_usuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre=txb_nombre.Text;
            string rfc = txb_rfc.Text;
            string direccion = txb_direccion.Text;
            string seguro = txb_social.Text;
            if( nombre.Length != 0 && rfc.Length != 0 && direccion.Length !=0 && seguro.Length != 0)
            {
                int identificador =conectandose.registroUsuario(nombre, rfc, direccion, seguro);
                string mensaje = "El usuario quedo registrado como "+nombre+" quedo registrado con el id:"+identificador;
                MessageBox.Show(mensaje);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los datos");
            }
            txb_nombre.Clear();
            txb_rfc.Clear();
            txb_direccion.Clear();
            txb_social.Clear();
        }
    }
}
