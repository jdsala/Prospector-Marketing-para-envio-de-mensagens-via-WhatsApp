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
    public partial class FrmImportArquivo : Form
    {
        //Class
        FrmBonus bonus = new FrmBonus();

        ConnectClass conec = new ConnectClass();
        ClassPrincipal principal = new ClassPrincipal();
        ImportarExcel import = new ImportarExcel();

        public FrmImportArquivo()
        {
            InitializeComponent();
        }
        private void tsmSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void configuraDataGrid()
        {
            dgvListas.Columns[0].HeaderText = "Status";
            dgvListas.Columns[1].HeaderText = "Nome";
            dgvListas.Columns[2].HeaderText = "Número";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if ((dgvListas.Rows.Count == 0) || (dgvListas.Rows.Count > 1))
            {
                if (MessageBox.Show("Deseja cancelar a importação de Listas?", "Confirmando!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    dgvListas.DataSource = null;
                    txtCaminho.Text = string.Empty;
                    Close();
                }
                
            }
            
        }
    }
}
