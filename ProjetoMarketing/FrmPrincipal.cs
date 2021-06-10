using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Resources;
using System.IO;

namespace ProjetoMarketing
{
    public partial class FrmBonus : Form
    {

        public FrmBonus()
        {
            InitializeComponent();

        }
        
         //Botão Sair fecha o programa Prospect e a janela de Login
        private void btnSair_Click(object sender, EventArgs e)
        {
            
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Close();
            if (MessageBox.Show("Deseja realmente fechar o Sistema?", "Confirmando Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

            {
                Application.Exit();
            }

        }

        //Carrega data e Hora quando abre o Form
        private void FrmBonus_Load(object sender, EventArgs e)
        {

            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");   //("dd/MM/yyyy");
          //  System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("Res_PT");

        }

        //Botão de Importar Arquivo csv
        private void btnImportar_Click(object sender, EventArgs e)
        {
            /*ClassPrincipal principal = new ClassPrincipal();
            ofdImportar.ShowDialog();
            txtCaminho.Text = ofdImportar.FileName;

            dgvNumeros.Columns.Clear();
            principal.ValidaExtensao(txtCaminho.Text);
            dgvNumeros.Columns.Clear();

            ImportCsv(txtCaminho.Text);*/

            using (OpenFileDialog open = new OpenFileDialog())

            {
                open.Filter = "CSV Files(*.csv)|*.csv";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = open.FileName;
                    LoadData(strFileName);
                    return;
                }

            };
            // MessageBox.Show("Aç");
            ClassPrincipal principal = new ClassPrincipal();
            principal.ValidaExtensao(txtCaminho.Text);


        }
        //Botão que limpa o campo Mensagem
        private void btnLimparMensagem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMensagem.Text)) 
            {

                if (MessageBox.Show("Deseja limpar o campo de Mensagem?", "Confirmando Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    txtMensagem.Text = string.Empty;

                }
                return;
            }
            if ((string.IsNullOrEmpty(txtMensagem.Text)))
            {
                MessageBox.Show("Ops! Campo Mensagem esta vacío");

            }   
            
        }

        //Botão que limpa o campo de Anexar
        private void btnExcluirAnexos_Click(object sender, EventArgs e)
        {
            if (pbiAnexar.Image != null)
            {

                if (MessageBox.Show("Deseja excluir a imagen anexada?", "Confirmando Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    pbiAnexar.Image = null;

                }
                return;
            }
            if (pbiAnexar.Image == null)
            {
                MessageBox.Show("Ops! Campo de Anexar Imagen esta vacía");

            }
        }

        //Botão que limpa o DataGridView de numeros
        private void btnLimparNumeros_Click(object sender, EventArgs e)
        {
            // dgvNumeros.Rows.Clear();
            if (dgvNumeros.Rows.Count >= 1)
            {
                if (MessageBox.Show("Deseja limpar o campo de Números?", "Confirmando Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    dgvNumeros.DataSource = null;
                    txtCaminho.Text = string.Empty;

                }
                return;

            }
            if(dgvNumeros.Rows.Count == 0)
            {
                MessageBox.Show("Ops! Campo Números esta vacío!");
            }
           
             
        }

        //Botão que limpa o DataGridView de Registros de Envios
        private void btnLimparRegistro_Click(object sender, EventArgs e)
        {
            if (dgvRegistrosDeEnvio.Rows.Count >= 1) 
            {
                if (MessageBox.Show("Deseja limpar o campo de Registros?", "Confirmando!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    dgvRegistrosDeEnvio.DataSource = null;

                }
                return;
            }
            if (dgvRegistrosDeEnvio.Rows.Count == 0)
            {
                MessageBox.Show("Ops! Campo Registros de Envio esta vacío!");

            }  
            
        }

        //Metodo para importar Excel.(Não esta sendo usado)
        DataView ImportarDatos(string nomearchivo) 
        {
           
            string connection = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0;'", nomearchivo);

            OleDbConnection conector = new OleDbConnection(connection);

            conector.Open();

            
            OleDbCommand consulta = new OleDbCommand("select * from [Plan1$]", conector);

            OleDbDataAdapter adaptador = new OleDbDataAdapter
            {
                SelectCommand = consulta
            };

            DataSet ds = new DataSet();

            adaptador.Fill(ds);

            conector.Close();

            return ds.Tables[0].DefaultView;
        }

        //Função de Importar CSV
        private void LoadData(string strFilePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(strFilePath);
            if (lines.Length > 0)
            {
                //Header
                string strfirstLine = lines[0];
                string[] headerLabels = strfirstLine.Split(',', ';');
                foreach (string strheader in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(strheader));
                }
                //Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] strData = lines[i].Split(',', ';');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string strheader in headerLabels)
                    {
                        dr[strheader] = strData[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                dgvNumeros.DataSource = dt;
            }
        }

        //Botão de Enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ClassPrincipal principal = new ClassPrincipal();

            if ((dgvNumeros.Rows.Count >= 1) && (!string.IsNullOrEmpty(txtMensagem.Text)))
            {
                principal.SendWhatsApp(dgvNumeros.ToString(), txtMensagem.Text);

            }
            else if (dgvNumeros.Rows.Count == 0 )
            {
                MessageBox.Show("Campo Numeros esta vacío!.");
                return;
            }
            else if  (string.IsNullOrEmpty(txtMensagem.Text))
            {
                MessageBox.Show("Campo Mensagem esta vacío!.");
                return;
            }

        }

        //Botão Emoji, direciona no site dos Emojis
        private void btnEmoji_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.emojicopy.com/");
        }

        //Suporte via suporte bonuscred. Abre Chamado
        private void tspSuporteC_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://suporte.bonuscred.com.br/");

        }

        //Suporte Via Skype
        private void tspSuporteS_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://join.skype.com/invite/zkBUkKcroaK1/");

        }

        //FormClosin X, pergunta pro Usuario se deseja fechar o Sistema
        private void FrmBonus_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(this, "Você tem certeza que deseja fechar o Sistema?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else 
                {
                    e.Cancel = true;
                }
            }

        }

        //Botão Slavar Registros
        private void btnSalvarRegistros_Click(object sender, EventArgs e)
        {

            ClassPrincipal principal = new ClassPrincipal();


            if (dgvRegistrosDeEnvio.Rows.Count >= 1)
            {
                principal.ExportarDados(dgvNumeros);

            }
            else if (dgvRegistrosDeEnvio.Rows.Count == 0)
            {
                MessageBox.Show("Não tem Registros a Exportar.");
                return;
            }
            
        }

        //Botôes TEMA........................................................
        private void tspSistema_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.Highlight;
            grbCampoMensagem.BackColor = SystemColors.Highlight;
            pnlPrincipal.BackColor = SystemColors.Highlight;
        }

        private void tspClaro_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
            grbCampoMensagem.BackColor = Color.White;
            pnlPrincipal.BackColor = Color.White;

        }

        private void tspOscuro_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.ActiveCaptionText;
            grbCampoMensagem.BackColor = SystemColors.ActiveCaptionText;
            pnlPrincipal.BackColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

        }

        //Botão Fonte Bold(Negrito)
        private void btnB_Click(object sender, EventArgs e)
        {
           
            txtMensagem.Font = new Font(this.Font, FontStyle.Bold);
          
        }

        //Botão Fonte Regular
        private void btnR_Click(object sender, EventArgs e)
        {
            txtMensagem.Font = new Font(this.Font, FontStyle.Regular);

        }

        //Botão Fonte Underline
        private void btnS_Click(object sender, EventArgs e)
        {
            txtMensagem.Font = new Font(this.Font, FontStyle.Underline);
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            ofdAnexar.FileName = "Imagem";
            ofdAnexar.Title = "Selecione uma Imagem";
            ofdAnexar.InitialDirectory = "C:\\Users\\NomedoPC\\Pictures";
            ofdAnexar.Filter = "image files (*.jpg)|*.jpg|All files(*.*)|*.*"; //"JPEG|*.JPG|PNG|*.png";
            ofdAnexar.ShowDialog();
        }

        private void ofdAnexar_FileOk(object sender, CancelEventArgs e)
        {
            pbiAnexar.Image = Image.FromFile(ofdAnexar.FileName);
        }

        private void tspEspanol_Click(object sender, EventArgs e)
        {
            IdiomasClass idioma = new IdiomasClass();
            idioma.AjustaCultura(this, "es-MX");
        }
    }
}
