using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ProjetoMarketing
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }
        
       //Botão Login
       //Valida se o usuario esta regitrado para Logar
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmBonus frmbonus = new FrmBonus();
            string aviso = "Atenção!";
            LoadData();
           /* 
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) && (string.IsNullOrWhiteSpace(txtSenha.Text)))
            {
                MessageBox.Show(aviso +" Os campos Usuário e Senha não podem ficar em branco");
                txtUsuario.Focus();
                return; 

            }
            
            if ((txtUsuario.Text == "Diego") && (int.Parse(txtSenha.Text) == 1234))
            {
                MessageBox.Show("Bem vindo ao Sistema Prospect Marketing da Bônus");
                frmbonus.ShowDialog();
                txtUsuario.Text = string.Empty;
                txtSenha.Text = string.Empty;       
            }

            else           
            {
                MessageBox.Show("Ops! Usuário ou Senha incorreta");
                txtUsuario.Focus();
                return;

            }*/
           

        }

        //Botâo Sair
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o Sistema?", "Confirmando Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

            {
                Application.Exit();
            }  
        }

        //Fecha o Sistema com a tecla ESC
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                if (MessageBox.Show("Deseja realmente fechar o Sistema?", "Confirmando Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                {
                    this.Close();
                }
                
            }

        }
        //Seta o Focu no campo de Usuário
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Select();
            RetornaPictureCir();
            
            
        }

        private void ofdImagem_FileOk(object sender, CancelEventArgs e)
        {
            picImagem.Image = Image.FromFile(ofdImagem.FileName);
        }

        //Funçao que retorna PictureBox de forma circular
        public void RetornaPictureCir()
        {
            
            // System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            GraphicsPath gp = new GraphicsPath(); 
            gp.AddEllipse(0, 0, picImagem.Width - 10, picImagem.Height - 2);              
            Region rg = new Region(gp);
            picImagem.Region = rg;
             

            //Opção Retangular
            /*  Rectangle r = new Rectangle(0, 0, picImagem.Width, picImagem.Height);
               int d = 50;
               gp.AddArc(r.X, r.Y, d, d, 180, 90);
               gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
               gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
               gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
               picImagem.Region = new Region(gp);*/

        }

        private void mtAvatar_Click(object sender, EventArgs e)
        {
           
            ofdImagem.FileName = "Avatar";
            ofdImagem.Title = "Selecione um Avatar";
            ofdImagem.InitialDirectory = "C:\\Users\\NomedoPC\\Pictures";
            ofdImagem.Filter = "image files (*.jpg)|*.jpg|All files(*.*)|*.*"; //"JPEG|*.JPG|PNG|*.png";
            ofdImagem.ShowDialog();
            
        }

        public void LoadData()
        {
            try
            {
                using (var conn = new SQLiteConnection(@"Data Source=C:\Crystal Management\Crystal Management\bin\Debug\Konaku.db;Version=3"))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("SELECT Username,Password FROM LoginData WHERE Username='@username' AND Password = '@password'", conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsuario.Text);
                        cmd.Parameters.AddWithValue("@password", txtSenha.Text);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var count = 0;
                            while (reader.Read())
                            {
                                count = count + 1;
                            }
                            if (count == 1)
                            {
                                FrmBonus login = new FrmBonus();
                                login.Show();
                                Hide();
                            }
                            else if (count == 0)
                            {
                                MessageBox.Show("Ops! Usuário ou Senha incorreta");
                                txtUsuario.Focus();
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     }
}
