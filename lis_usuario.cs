﻿using System;
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
    public partial class lis_usuario : Form
    {
        ConexionPostgreSql conectandose;
        public lis_usuario(ConexionPostgreSql vinculo)
        {
            InitializeComponent();
            conectandose = vinculo;
            data_im.DataSource = conectandose.consultar();            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lis_usuario_Load(object sender, EventArgs e)
        {

        }

        private void data_im_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
