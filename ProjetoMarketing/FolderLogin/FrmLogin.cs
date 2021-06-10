using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Drawing;

namespace ProjetoMarketing
{
    public partial class FrmLogin : Form
    {
        //Frm instanciado
        FrmRegistrarU registra = new FrmRegistrarU(); 
        ConnectClass conn = new ConnectClass();

        public FrmLogin()
        {
            InitializeComponent(); 
        }
        //variabel que pega o usuario Logado
        public static  string usuarioLogado;

        //Botão Login
        //Valida se o usuario esta regitrado para Logar
        private void btnLogin_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(txtUsuario.Text) || (string.IsNullOrEmpty(txtSenha.Text)))
            {
                MessageBox.Show("Ops! Campo Usuário ou Senha esta vazio");
                txtUsuario.Focus();
                return;
            }
           
            // Se a internet esta conectada
            if (conn.IsConnected() == false)
            {
                btnLogin.BackColor = Color.Red;
                MessageBox.Show("Não exite conexão ativa com a internet.", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                btnLogin.BackColor = Color.Goldenrod;
                return;
            }
            if (chkRemember.Checked == true)
            {
                Properties.Settings.Default.UserName = txtUsuario.Text;
                Properties.Settings.Default.Password = txtSenha.Text;
                Properties.Settings.Default.Save();
            }

            ValidaUsuario(txtUsuario.Text, txtSenha.Text);    
        }
        #region Valida Usúario
        //Devolve usuario ja registrado
        public DataTable ValidaUsuario(string usuario, string senha)
        {
            SQLiteDataAdapter sda = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = registra.DbConnection().CreateCommand())
                {
                    FrmBonus bonus = new FrmBonus();
                    cmd.CommandText = "SELECT * FROM usuario where usuario =? AND senha = ?";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    sda = new SQLiteDataAdapter(cmd.CommandText, registra.DbConnection());
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    // sda.Fill(dt);  

                    int count = 0;
                    while (dr.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        txtUsuario.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                         
                        FrmLogin.usuarioLogado = usuario; //Pega o nome de Usuario
                        bonus.ShowDialog();    
                    }
                    if (count == 0)
                    {
                        btnLogin.BackColor = Color.Red;
                        MessageBox.Show("Usuário ou Senha não cadastrado!", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtSenha.Text = string.Empty;
                        this.txtUsuario.Focus();
                        btnLogin.BackColor = Color.Goldenrod;
                    }
                    return dt; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro!!: " + ex.Message); //throw ex;
            }
        }
        #endregion

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
        }
        
        private void mtRegistrarU_Click(object sender, EventArgs e)
        {
            FrmRegistrarU registrar = new FrmRegistrarU();
            registrar.ShowDialog();
        }

        private void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarSenha.Checked == true)
            {
                txtSenha.PasswordChar = '\u0000';
            }
            else
            {
                txtSenha.PasswordChar = '*';
            }

        }
    }
}
