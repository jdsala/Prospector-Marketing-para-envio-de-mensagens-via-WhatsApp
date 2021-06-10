using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ProjetoMarketing
{
    public partial class FrmRegistrarU : Form
    {
        private static SQLiteConnection sqliteConnection;
        
        public FrmRegistrarU()
        {
            InitializeComponent();   
        }
        //Botão Adicionar Usuario
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DbConnection();
            if (txtSenhaDois.Text != txtSenhaUm.Text)
            {
                MessageBox.Show("A confirmação de senha não e igual a Senha definida");
                txtSenhaDois.Focus();
                return;
            }

            if (Validar(txtSenhaUm.Text, txtSenhaDois.Text))
            {
                Add(txtUsuario.Text, txtSenhaUm.Text);
                MessageBox.Show("Usuario adicionado com sucesso!");
                Close();
            }
            
            else
            {
                MessageBox.Show("A senha deve conter letras e números");
            }
        }
        //Valida os campos SenhaUm e Senha dois para que não sejam usados caracteres especiais
        public bool Validar(string senhaUm, string senhaDois) 
        {
            if ((senhaUm.Where(c => char.IsLetter(c)).Count() > 0) && (senhaUm.Where(c => char.IsNumber(c)).Count() > 0))
            {
                return true;
            }
            if ((senhaDois.Where(c => char.IsLetter(c)).Count() > 0) && (senhaDois.Where(c => char.IsNumber(c)).Count() > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Conexão com SQLLite
        public SQLiteConnection DbConnection()
        {
            string dbcon = @"Data Source=dados.db;";
            sqliteConnection = new SQLiteConnection(dbcon); //("Data Source=banco.db;");//("Data Source=C:\\Usuarios\\Bonuscred.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        //Cria o Banco de Dados
        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"C:\Source\database\banco.db");  //(@"C:\dados\Cadastro.sqlite");
            }
            catch
            {
                throw;
            }
        }  
        //Insert que Adiciona novo usuario
        public  void Add(string usuario, string senha)
        {  
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO usuario(usuario, senha) values (@usuario, @senha)";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        //Botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Check Box para visualizar senha
        private void ckbVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbVisualizar.Checked == true)
            {
                txtSenhaUm.PasswordChar = '\u0000';
            }
            else
            {
                txtSenhaUm.PasswordChar =  '*';
            }
            
        }
    }
}
