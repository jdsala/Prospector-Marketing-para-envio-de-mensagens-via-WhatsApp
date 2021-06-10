using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoMarketing
{
    public partial class FrmRegistroN : Form
    {
        string password;
        public FrmRegistroN()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumerodeCelular.Text)) 
            {
                MessageBox.Show("Por favor ingresar o número de celular.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumerodeCelular.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNome.Text)) 
            {
                MessageBox.Show("Por favor ingresar o seu Nome.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            if (WhatsAppApi.Register.WhatsRegisterV2.RequestCode(txtNumerodeCelular.Text, out password, "sms"))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    Save();
                }
                else
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("Não foi possivel gerar a Senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void Save() 
        {
            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = false;
            Properties.Settings.Default.NumeroCelular = txtNumerodeCelular.Text;
            Properties.Settings.Default.Senha = password;
            Properties.Settings.Default.Nome = txtNome.Text;
            Properties.Settings.Default.Save();

            if (Global.DB.Accounts.FindByAccountId(txtNumerodeCelular.Text) == null)
            {
                AppData.AccountsRow row = Global.DB.Accounts.NewAccountsRow();
                row.AccountId = txtNumerodeCelular.Text;
                row.Nome = txtNome.Text;
                row.Senha = password;
                Global.DB.Accounts.AddAccountsRow(row);
                Global.DB.Accounts.AcceptChanges();
                Global.DB.Accounts.WriteXml(string.Format("{0}\\accounts.dat", Application.StartupPath));
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;


        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSmsCodigo.Text)) 
            {
                MessageBox.Show("Por favor ingresar o codigo recevido via SMS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSmsCodigo.Focus();
                return;
            }
            password = WhatsAppApi.Register.WhatsRegisterV2.RegisterCode(txtNumerodeCelular.Text, txtSmsCodigo.Text);
            Save();

        }
    }
}
