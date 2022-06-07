using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Npgsql;

namespace control
{
    public partial class inicio : Form
    {
        ConexionPostgreSql conectandose = new ConexionPostgreSql();
        public inicio()
        {
            
            InitializeComponent();
            conectandose.Conectar();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void inicio_secion_Click(object sender, EventArgs e)
        {
            string nombre = txb_nombre.Text;
            string password = txb_password.Text;
            string llave = "admi";
            if(llave == nombre)
            {
                if (password == "admi")
                {
                    using (v_admi menu_p = new v_admi(conectandose))
                        menu_p.ShowDialog();
                }
            }
            else//Sin no  entro en administrador noa vamos a los usurios
            {


                bool resp =  conectandose.inicioSeccion(nombre, password);
                if (resp)
                {
                    using (Principal menu_p = new Principal(nombre,conectandose))
                        menu_p.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ingrese datos validos");
                }
                
            }
            /*txt box clear*/
            txb_nombre.Clear();
            txb_password.Clear();
            nombre = "";
            password = "";
        }
       
        private void inicio_Load(object sender, EventArgs e)
        {
            /*poner aqui el codigo de la censura de string*/
            txb_password.PasswordChar = '*';
        }
        private void usuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            conectandose.desconectar();
            this.Close();
        }

        private void txb_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
