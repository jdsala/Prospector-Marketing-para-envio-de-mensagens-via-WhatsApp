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
using System.IO;

namespace ProjetoMarketing
{
    public partial class FrmBonus : Form
    {
        private string fileName;

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

        private void FrmBonus_Load(object sender, EventArgs e)
        {

            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");   //("dd/MM/yyyy");



        }

        private void FrmBonus_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Close();

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            /* OpenFileDialog fdlg = new OpenFileDialog();

              fdlg.Title = "Select file";
              fdlg.InitialDirectory = @"c:\";
              fdlg.FileName = txtNomePlanilha.Text;
              fdlg.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
              fdlg.FilterIndex = 1;
              fdlg.RestoreDirectory = true;

              if (fdlg.ShowDialog() == DialogResult.OK)
              {
                  txtNomePlanilha.Text = fdlg.FileName;
                  //Import();

                  Application.DoEvents();
              }

            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtCaminho.Text = openfile1.FileName;
                }
                {
                    string pathconn = "Provider = Microsoft.jet.OLEDB.4.0; Data source=" + txtCaminho.Text + ";Extended Properties=\"Excel 8.0;HDR= yes;\";";
                    OleDbConnection conn = new OleDbConnection(pathconn);
                    OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter("Select * from [" + txtNomePlanilha.Text + "$]", conn);
                    DataTable dt = new DataTable();
                    MyDataAdapter.Fill(dt);
                    dgvNumeros.DataSource = dt;
                }
            }
            catch { }

            
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                string pathconn = " = "XML Files(*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) | *.xml; *.xls; *.xlsx; *.xlsm; *.xlsb; *.ods | All Files(*.*) | *.* ";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
                openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory 

                if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                {
                    string pathName = openFileDialog1.FileName;
                    fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    string sheetName = fileName;

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                    }
                    OleDbConnection cnnxls = new OleDbConnection(strConn);
                    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                    oda.Fill(tbContainer);

                    dgvNumeros.DataSource = tbContainer;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }*/         


            
        }
    }
}
