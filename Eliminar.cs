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
    public partial class Eliminar : Form
    {
        ConexionPostgreSql conectandose;
        public Eliminar(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Eliminar_Load(object sender, EventArgs e)
        {
 
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            data_im.DataSource = conectandose.consultar(txb_id.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conectandose.baja_user(txb_id.Text);
            this.Close();
        }
    }
}
