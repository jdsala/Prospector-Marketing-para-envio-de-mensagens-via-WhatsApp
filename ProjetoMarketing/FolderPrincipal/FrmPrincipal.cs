using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMarketing
{
    public partial class FrmBonus : Form
    {
        //Class instanciados

        ConnectClass conec = new ConnectClass();
        ClassPrincipal principal = new ClassPrincipal();
        ImportarExcel import = new ImportarExcel();
        FrmLogin login = new FrmLogin();
        SendMessage send = new SendMessage();

        //Metodos e variaveis do tipo Public
        public ThreadStart ts;
        public Thread tr;

        public DataGridView dgvDataNumeros;

        public FrmBonus()
        {
            InitializeComponent();
        }

        //Load do Form
        private void FrmBonus_Load(object sender, EventArgs e)
        {
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");   //("dd/MM/yyyy");
            txtUsuario.Text = FrmLogin.usuarioLogado;

            ts = new ThreadStart(Envia);
            tr = new Thread(ts);

            dgvRegistrosDeEnvio.SelectionMode = DataGridViewSelectionMode.CellSelect;
            login.Close();

            CheckForIllegalCrossThreadCalls = false;
        }

        //Botão que limpa o campo Mensagem
        private void btnLimparMensagem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbTitulo.Text))
            {
                if (MessageBox.Show("Deseja limpar o campo de Titulo?", "Confirmando Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    rtbTitulo.Text = string.Empty;
                }
                return;
            }
            if ((string.IsNullOrEmpty(rtbTitulo.Text)))
            {
                MessageBox.Show("Ops! Campo da Mensagem esta vazio");
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
                MessageBox.Show("Ops! Campo de Anexar Imagen esta vazio");
            }
        }

        //Botão que limpa o DataGridView de Registros de Envios
        private void btnLimparRegistro_Click(object sender, EventArgs e)
        {
            if (dgvRegistrosDeEnvio.Columns.Count >= 1)
            {
                if (MessageBox.Show("Deseja limpar o campo de Registros?", "Confirmando!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dgvRegistrosDeEnvio.Columns.Clear();
                    // dgvRegistrosDeEnvio.DataSource = null;
                }
                return;
            }
            if (dgvRegistrosDeEnvio.Rows.Count == 0)
            {
                MessageBox.Show("Ops! Campo Registros de Envio esta vazio!");
            }
        }

        //Metodo para enviar WhatsApp
        public void Envia()
        {
            for (int i = 0; i < dgvNumeros.Rows.Count;)
            {
                if (dgvNumeros.Rows[i].Cells[1].Value.ToString().Length == 13)
                {
                    //principal.SendWhatsApp(dgvNumeros.Rows[i].Cells[1].Value.ToString(), PreparaTexto(dgvNumeros.Rows[i]), lblAnexar.Text, rtbMensagem.Text);
                    send.SendWhatsApp(dgvNumeros.Rows[i].Cells[1].Value.ToString(), PreparaTexto(dgvNumeros.Rows[i]), rtbTitulo.Text);

                    Thread.Sleep(5000);
                    var row = (DataGridViewRow)dgvNumeros.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgvNumeros.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    Invoke(new MethodInvoker(() =>
                    {
                        dgvRegistrosDeEnvio.Rows.Add(row);
                        dgvNumeros.Rows.RemoveAt(i);
                        btnPausarEnvio.Visible = true;
                        btnContinuar.Visible = true;
                    }));
                }
                else
                {
                    i++;
                }
            }
        }
        //Botão de Enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (dgvNumeros.Rows.Count == 0)
            {
                MessageBox.Show("Campo Números esta vazio!.");
                return;
            }

            if (string.IsNullOrEmpty(rtbTitulo.Text))
            {
                MessageBox.Show("Campo Mensagem esta vazio!.");
                return;
            }
            tr.Start();
            progressBar1.Visible = true;
            TarefaEnviar();
            Envia();
            
        }

        //Prepara o texto para a mensagem e adiciona no Botão Nome
        public string PreparaTexto(DataGridViewRow g)
        {
            string strTitulo = rtbTitulo.Text;
            foreach (DataGridViewColumn h in dgvNumeros.Columns)
            {
                //Troca todas as ocorrencias das variaveis pelo valor da linha
                strTitulo = strTitulo.Replace($"[[{h.Name}]]", g.Cells[h.Name].Value.ToString());
            }
            return strTitulo;
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
            grbTitulo.BackColor = SystemColors.Highlight;
            grbAnexar.BackColor = SystemColors.Highlight;
            pnlPrincipal.BackColor = SystemColors.Highlight;
        }

        private void tspClaro_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
            grbTitulo.BackColor = Color.White;
            grbAnexar.BackColor = Color.White;
            pnlPrincipal.BackColor = Color.White;
        }

        private void tspOscuro_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.ActiveCaptionText;
            grbTitulo.BackColor = SystemColors.ActiveCaptionText;
            grbAnexar.BackColor = SystemColors.ActiveCaptionText;
            pnlPrincipal.BackColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        private void ofdAnexar_FileOk(object sender, CancelEventArgs e)
        {
            pbiAnexar.Image = Image.FromFile(ofdAnexar.FileName);
        }
        private void tspSair_Click(object sender, EventArgs e)
        {
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Close();
            if (MessageBox.Show("Deseja realmente sair do Sistema?", "Confirmando Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void tspSairSistema_Click(object sender, EventArgs e)
        {
            FrmBonus bonus = new FrmBonus();
            bonus.Close();
        }

        private void tspTituloEmoji_Click(object sender, EventArgs e)
        {
            principal.chamaEmotic();
        }

        private void tspTituloB_Click(object sender, EventArgs e)
        {
            if (tspTituloB.BackColor == SystemColors.Highlight)
            {
                tspTituloB.BackColor = SystemColors.ControlDark;
                rtbTitulo.SelectionFont = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                tspTituloB.BackColor = SystemColors.Highlight;
                rtbTitulo.SelectionFont = new Font(this.Font, FontStyle.Regular);
            }
        }
        private void tspTituloR_Click(object sender, EventArgs e)
        {
            rtbTitulo.SelectionFont = new Font(this.Font, FontStyle.Regular);
            tspTituloB.BackColor = SystemColors.Highlight;
            tspTituloS.BackColor = SystemColors.Highlight;
        }
        private void tspTituloS_Click(object sender, EventArgs e)
        {
            if (tspTituloS.BackColor == SystemColors.Highlight)
            {
                tspTituloS.BackColor = SystemColors.ControlDark;
                rtbTitulo.SelectionFont = new Font(this.Font, FontStyle.Underline);
            }
            else
            {
                tspTituloS.BackColor = SystemColors.Highlight;
                rtbTitulo.SelectionFont = new Font(this.Font, FontStyle.Regular);
            }
        }
        private void tsmAnexarImagen_Click(object sender, EventArgs e)
        {
            int index;
            string filename;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PNG|*.png|JPG|*.jpg|GIF|*.gif", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lblPath.Visible = true;
                    filename = ofd.FileName;
                    index = ofd.FilterIndex;
                    lblPath.Text = string.Format("Path: {0}", ofd.FileName);
                }
            }

            /*
            ofdAnexar.FileName = "Imagem";
            ofdAnexar.Title = "Selecione uma Imagem";
            ofdAnexar.InitialDirectory = "C:\\Users\\NomedoPC\\Pictures";
            ofdAnexar.Filter = "image files (*.jpg)|*.jpg|All files(*.*)|*.*"; //"JPEG|*.JPG|PNG|*.png";
            ofdAnexar.ShowDialog();*/
        }
        private void tspExcluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbTitulo.Text))
            {
                if (MessageBox.Show("Deseja Excluir o Titulo?", "Confirmando!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    rtbTitulo.Text = string.Empty;
                }
                return;
            }
            if (string.IsNullOrEmpty(rtbTitulo.Text))
            {
                MessageBox.Show("Ops! Campo Titulo esta vazio!");
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (lblPath.Visible == true)
            {
                if (MessageBox.Show("Deseja excluir a Imagem?", "Confirmando!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    pbiAnexar.Image = null;
                    lblPath.Visible = false;
                }
                return;
            }
            if (lblPath.Visible == false)
            {
                MessageBox.Show("Ops! Campo Imagem esta vazio!");
            }
        }
        private void tspConfigurar_Click(object sender, EventArgs e)
        {
            FrmConfig conf = new FrmConfig();
            conf.ShowDialog();
        }

        private void tsmConfigurar_Click(object sender, EventArgs e)
        {
            FrmConfig conf = new FrmConfig();
            conf.ShowDialog();
        }

        private void ChamaSalvarArquivo()
        {
            if (!string.IsNullOrEmpty(rtbTitulo.Text))
            {
                if ((MessageBox.Show("Deseja Salvar o arquivo ?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    Salvar_Arquivo();
                }
            }
        }
        private void Salvar_Arquivo()
        {
            SaveFileDialog svdlg = new SaveFileDialog();
            try
            {
                // Pega o nome do arquivo para salvar
                if (svdlg.ShowDialog() == DialogResult.OK)
                {
                    // abre um stream para escrita e cria um StreamWriter para implementar o stream
                    FileStream fs = new FileStream(svdlg.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.Flush();
                    // Escreve para o arquivo usando a classe StreamWriter
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    // escreve no controle richtextbox
                    m_streamWriter.Write(rtbTitulo.Text);
                    // fecha o arquivo
                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tspImprimir_Click(object sender, EventArgs e)
        {
            ptdImprimir_Registro.Print();
        }

        private void ptdImprimir_Registro_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvRegistrosDeEnvio.Width, this.dgvRegistrosDeEnvio.Height);
            dgvNumeros.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvRegistrosDeEnvio.Width, this.dgvRegistrosDeEnvio.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
        private void tsmLimpar_Click(object sender, EventArgs e)
        {
            // dgvNumeros.Rows.Clear();
            if ((dgvNumeros.Rows.Count >= 1) && (!string.IsNullOrEmpty(txtCaminho.Text)))
            {
                if (MessageBox.Show("Deseja limpar os campos?", "Confirmando Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    tspNome.DropDownItems.Clear();

                    dgvNumeros.DataSource = null;
                    txtContagem.Text = string.Empty;
                    txtCaminho.Text = string.Empty;
                }
                return;
            }
            if ((dgvNumeros.Rows.Count == 0) && (string.IsNullOrEmpty(txtCaminho.Text)))
            {
                MessageBox.Show("Ops! Campo Números esta vazio!");
            }
        }

        //Botao Configurar tempo de Mensagem
        private void tsmConfigurar_Click_1(object sender, EventArgs e)
        {
            FrmConfig conf = new FrmConfig();
            conf.ShowDialog();
        }

        //Botao para Sair do Sistema
        private void btnSairSistema_Click(object sender, EventArgs e)
        {
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Close();

            if (MessageBox.Show("Deseja realmente sair do Sistema?", "Confirmando Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Botao para Inserir Titulo
        private void tspInserir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            openFile1.Filter = "Text Files|*.txt";

            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                rtbTitulo.LoadFile(openFile1.FileName,
                RichTextBoxStreamType.PlainText);
        }

        //ContextMenu /Menu Contextual pra Colar 
        private void cmsColar_Click(object sender, EventArgs e)
        {
            if (rtbTitulo.Focused == true)
            {
                rtbTitulo.Paste();
            }
            if (rtbMensagem.Focused == true)
            {
                rtbMensagem.Paste();
            }
        }

        //ContextMenu /Menu Contextual pra Limpar
        private void cmsLimpar_Click(object sender, EventArgs e)
        {
            if (rtbTitulo.Focused == true)
            {
                rtbTitulo.Text = string.Empty;
            }
            if (rtbMensagem.Focused == true)
            {
                rtbMensagem.Text = string.Empty;
            }
        }

        //ContextMenu /Menu Contextual pra Copiar
        private void cmsCopiar_Click(object sender, EventArgs e)
        {
            if (rtbTitulo.Focused == true)
            {
                rtbTitulo.Copy();
            }
            if (rtbMensagem.Focused == true)
            {
                rtbMensagem.Copy();
            }
        }

        //Botao que exporta pro CSV
        private void tsmExportarCSV_Click(object sender, EventArgs e)
        {
            principal.SaveToCSV(dgvNumeros);
        }
        //Botao que exporta pro Excel
        private void tsmExportarExcel_Click_1(object sender, EventArgs e)
        {
            principal.ExportarDados(dgvNumeros);
        }

        //Botão que importa CVS
        private void tsmImportCVS_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "CSV Files(*.csv)|*.csv";
                open.Title = "Selecionar Arquivo";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = open.FileName;
                    txtCaminho.Text = open.FileName;
                    // CarregaCSV(strFileName);
                    DataView dv = CarregaCSV(strFileName);

                    dgvNumeros.DataSource = dv;
                    txtContagem.Text = dgvNumeros.RowCount.ToString();

                    AcrescentaBotoes(dv);
                }
            };
        }
        //Botão que importa Excel
        private void tsmImprtExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls;*.xlsx;",
                Title = "Selecionar Arquivo"
            };

            if ((openFileDialog.ShowDialog() == DialogResult.OK) && (!string.IsNullOrEmpty(openFileDialog.FileName)))
            {
                txtCaminho.Text = openFileDialog.FileName;
                DataView dv = import.ImportarDados(openFileDialog.FileName);
                dgvNumeros.DataSource = dv;
                txtContagem.Text = dgvNumeros.RowCount.ToString();
                AcrescentaBotoes(dv);
            }
        }
        //Função de Importar CSV
        private DataView CarregaCSV(string strFilePath)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            //  conec.ReadFromFile(strFilePath);
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
            return dt.DefaultView;

        }
        //Metodo que adiciona os botoes uma vez importado a planilha Excel ou CSV
        //Esses botoes pega os nomes de cada columna da planiha importada
        public void AcrescentaBotoes(DataView dt)
        {
            foreach (DataColumn col in dt.Table.Columns)
            {
                ToolStripMenuItem toolIten = new ToolStripMenuItem();
                toolIten.Text = col.ColumnName;
                toolIten.Click += (s, e) =>
                rtbTitulo.Text += $"[[{toolIten.Text}]]"; //Expresão Lambda
                tspNome.DropDownItems.Add(toolIten);

                //Cria coluna na segunda Tabela
                dgvRegistrosDeEnvio.Columns.Add("RE" + col.ColumnName, col.ColumnName);
            }
        }

        //BTN Pausar Envio
        private void btnPausarEnvio_Click(object sender, EventArgs e)
        {
            tr.Abort();
            progressBar1.Visible = false;
        }

        //BTN Continuar Envio
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            tr = new Thread(ts);
            tr.Start();
            progressBar1.Visible = true;
        }
        private void tspInserirMensagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            openFile1.Filter = "Text Files|*.txt";

            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                rtbMensagem.LoadFile(openFile1.FileName,
                RichTextBoxStreamType.PlainText);
        }

        private void tspExcluirMensagem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbMensagem.Text))
            {
                if (MessageBox.Show("Deseja excluir a Mensagem?", "Confirmando!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    rtbMensagem.Text = string.Empty;
                }
                return;
            }
            if (string.IsNullOrEmpty(rtbMensagem.Text))
            {
                MessageBox.Show("Ops! Campo Mensagem esta vazío!");
            }
        }

        private void tspEmojiMensagem_Click(object sender, EventArgs e)
        {
            principal.chamaEmotic();
        }

        private void tspB_Click(object sender, EventArgs e)
        {
            if (tspB.BackColor == SystemColors.Highlight)
            {
                tspB.BackColor = SystemColors.ControlDark;
                rtbMensagem.SelectionFont = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                tspB.BackColor = SystemColors.Highlight;
                rtbMensagem.SelectionFont = new Font(this.Font, FontStyle.Regular);
            }
        }

        private void tspI_Click(object sender, EventArgs e)
        {
            rtbMensagem.SelectionFont = new Font(this.Font, FontStyle.Regular);
            tspI.BackColor = SystemColors.Highlight;
            tspS.BackColor = SystemColors.Highlight;
        }

        private void tspS_Click(object sender, EventArgs e)
        {
            if (tspS.BackColor == SystemColors.Highlight)
            {
                tspS.BackColor = SystemColors.ControlDark;
                rtbMensagem.SelectionFont = new Font(this.Font, FontStyle.Underline);
            }
            else
            {
                tspS.BackColor = SystemColors.Highlight;
                rtbMensagem.SelectionFont = new Font(this.Font, FontStyle.Regular);
            }
        }

        private void tspSalvarMensagem_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
            rtbTitulo.Clear();
            rtbTitulo.Focus();
        }

        private void tspEditarM_Click(object sender, EventArgs e)
        {
            rtbTitulo.Focus();
        }

        private void tspEditarN_Click(object sender, EventArgs e)
        {
            rtbMensagem.Focus();
        }
        private void TarefaEnviar()
        {
            List<Task> tsk = new List<Task>();
            tsk.Add(new Task(new Action(() =>
            {
                Thread.Sleep(1000);
                progressBar1.Invoke(new Action(() => progressBar1.PerformStep()));

            })));

            progressBar1.Maximum = tsk.Count;
            progressBar1.Step = 1;

            for (int i = 0; i < tsk.Count; i++)
            {
                tsk[i].Start();
            }
        }
    }
}
