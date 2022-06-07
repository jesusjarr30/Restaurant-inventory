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
    public partial class password : Form
    {
        ConexionPostgreSql conectandose;
        string id_usuario;
        public password(ConexionPostgreSql vinculo,string identificador)
        {
            InitializeComponent();
            conectandose = vinculo;
            id_usuario = identificador;
        }

        private void password_Load(object sender, EventArgs e)
        {
            txb_actual.PasswordChar = '*';
            txb_nueva.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txb_actual.Text.Length != 0 && txb_nueva.Text.Length !=0)
            {
                conectandose.cambio_password(id_usuario, txb_actual.Text, txb_nueva.Text);
            }
            this.Close();
        }
    }
}
