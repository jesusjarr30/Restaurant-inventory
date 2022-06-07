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
    public partial class v_admi : Form
    {

        ConexionPostgreSql conectandose;
        
        public v_admi(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
 
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private Form activeForm = null;
        private void openChilForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_admi.Controls.Add(childForm);
            panel_admi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_ingreso_Click(object sender, EventArgs e)
        {
            openChilForm(new new_usuario(conectandose));
        }

        private void btn_registra_Click(object sender, EventArgs e)
        {
            openChilForm(new lis_usuario(conectandose));
        }

        private void btn_notifica_Click(object sender, EventArgs e)
        {
            openChilForm(new Eliminar(conectandose));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_notifica_Click_1(object sender, EventArgs e)
        {
            openChilForm(new Eliminar(conectandose));
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChilForm(new listado_s(conectandose));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChilForm(new modificar_user(conectandose));
        }
    }
}
