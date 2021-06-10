using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMarketing
{
    class ImportarExcel
    {
        //Importar Excel
        public DataView ImportarDados(string nomearquivo)
        {

            string conection = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0;'", nomearquivo);

            OleDbConnection conn = new OleDbConnection(conection);

            conn.Open();
            DataTable dtSchema;
            dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string nomePlanilha = dtSchema.Rows[0]["TABLE_NAME"].ToString();
            conn.Close();

            OleDbCommand odb = new OleDbCommand("select * from [" + nomePlanilha + "]", conn);

            OleDbDataAdapter oda = new OleDbDataAdapter
            {
                SelectCommand = odb
            };

            DataSet ds = new DataSet();

            oda.Fill(ds);

            conn.Close();

            return ds.Tables[0].DefaultView;
        }

    }
}
