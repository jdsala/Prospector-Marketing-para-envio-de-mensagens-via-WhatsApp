using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MySqlConnector;
using System.IO;

namespace ProjetoMarketing
{
    class ConnectClass
    {
        //Método da API que verifica conexao
        [DllImport("wininet.dll")]
        private static extern Boolean InternetGetConnectedState(out int Description, int ReservedValue);
       
        // Um método que verifica se esta conectado a Internet
        public  Boolean IsConnected()

        {

            int Description;

            return InternetGetConnectedState(out Description, 0);

        }

        public void ReadFromFile(string filename)
        {
            string line;
            File.Exists(filename);
            Stream saida = File.OpenWrite(filename);
            saida.Close();
            using (StreamReader sr = File.OpenText(filename))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }
    }

}

        
      
    




