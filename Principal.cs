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
    public partial class Principal : Form
    {
        string id_usuario;
        ConexionPostgreSql conectandose;
        public Principal(string nombre,ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            customDesigner();
            id_usuario = nombre;
            conectandose = vinculo;
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
        private void customDesigner()
        {
            pan_sub_acerca.Visible = false;
        
        }
        private void hideMenu()
        {
            if (pan_sub_acerca.Visible == true)
                pan_sub_acerca.Visible = false;
        }
        private void showSubMenu(Panel submm)
        {
            if (submm.Visible == false)
            {
                hideMenu();
                submm.Visible = true;
            }
            else
                submm.Visible = false;
        }

        private void btn_acerca_Click(object sender, EventArgs e)
        {
            openChilForm(new listado_p(conectandose));
            //codigo
            hideMenu();
        }

        private void btn_version_Click(object sender, EventArgs e)
        {
            openChilForm(new acerca_de());
            //codigo
            hideMenu();
        }

        private void btn_creditos_Click(object sender, EventArgs e)
        {
            openChilForm(new creditos());
            //codigo
            hideMenu();
        }

        private void btn_ingreso_Click(object sender, EventArgs e)
        {
            openChilForm(new ingreso_p(conectandose));
            hideMenu();// cerra las otras ventanas

        }

        private void btn_registra_Click(object sender, EventArgs e)
        {
            hideMenu();// cerra las otras ventanas
            openChilForm(new v_ven(conectandose));
        }

        private void btn_notifica_Click(object sender, EventArgs e)
        {
            hideMenu();// cerra las otras ventanas
            openChilForm(new v_notificaciones(conectandose));
        }

        private void btn_salida_Click(object sender, EventArgs e)
        {
            hideMenu();// cerra las otras ventanas
            openChilForm(new salidap(conectandose,id_usuario));
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
            panelhijo.Controls.Add(childForm);
            panelhijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelhijo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(pan_sub_acerca);
        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_busqueda_p_Click(object sender, EventArgs e)
        {
            openChilForm(new buscar_p(conectandose));
            //codigo
            hideMenu();
        }

        private void btn_cambiopass_Click(object sender, EventArgs e)
        {
            openChilForm(new password(conectandose, id_usuario));
            //codigo
            hideMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChilForm(new modificar_registro(conectandose));
            hideMenu();
        }
    }
}
