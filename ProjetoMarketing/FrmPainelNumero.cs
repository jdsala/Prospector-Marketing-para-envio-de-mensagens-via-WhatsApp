using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace ProjetoMarketing
{
    public partial class FrmPainelNumero : Form
    {
        WhatsApp wa;
        public FrmPainelNumero()
        {
            InitializeComponent();
        }

        private void btnAssinar_Click(object sender, EventArgs e)
        {

        }

        private void ckbRelembrar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Relembrar = ckbRelembrar.Checked;
            Properties.Settings.Default.NumeroCelular = txtPhoneNumber.Text;
            Properties.Settings.Default.Senha = txtPassword.Text;
            Properties.Settings.Default.Save();

        }

        private void FrmPainelNumero_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            panel1.BringToFront();
            if (Properties.Settings.Default.Relembrar) 
            {
                txtPhoneNumber.Text = Properties.Settings.Default.NumeroCelular;
                txtPassword.Text = Properties.Settings.Default.Senha;
                ckbRelembrar.Checked = Properties.Settings.Default.Relembrar;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FrmRegistroN frm = new FrmRegistroN()) 
            {
                if (frm.ShowDialog() == DialogResult.OK) 
                {
                    txtPhoneNumber.Text = Properties.Settings.Default.NumeroCelular;
                    txtPassword.Text = Properties.Settings.Default.Senha;

                }
            }

        }
    }
}
