using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ProjetoMarketing
{
    public class ClassPrincipal
    {
        //Funçao que exporta Dados para o Excel
        public void ExportarDados(DataGridView datalist)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Arquivo Excel";
                sfd.Filter = "Excel File | *.xlsx,*.xls";

                sfd.FileName = "Resultado";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                    excel.Application.Workbooks.Add(true); //Com isso colocamos uma folha no Excel para exportar os arquivos
                    int IndiceColuna = 0;
                    foreach (DataGridViewColumn columna in datalist.Columns) //Aquí comezamos a ler as colunas do listado a exportar
                    {
                        IndiceColuna++;
                        excel.Cells[1, IndiceColuna] = columna.Name;
                    }
                    int IndiceLinha = 0;
                    foreach (DataGridViewRow fila in datalist.Rows) //Aquí lemos as linhas das colunas lídas
                    {
                        IndiceLinha++;
                        IndiceColuna = 0;
                        foreach (DataGridViewColumn columna in datalist.Columns)
                        {
                            IndiceColuna++;
                            excel.Cells[IndiceLinha + 1, IndiceColuna] = fila.Cells[columna.Name].Value;
                        }
                    }
                    excel.Visible = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro.! " + e.Message);
            }
        }
        // Reset all the controls to the user's default Control color. 
        public void ResetAllControlsBackColor(Control control)
        {
            control.BackColor = SystemColors.Control;
            control.ForeColor = SystemColors.ControlText;
            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }
        public void SaveToCSV(DataGridView DGV)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Resultado.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Os dados serão exportados e você será notificado quando estiver pronto.");
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Não foi possível gravar os dados." + ex.Message);
                    }
                }
                int columnCount = DGV.ColumnCount;
                string columnNames = string.Empty;
                string[] output = new string[DGV.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += DGV.Columns[i].Name.ToString() + ",";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < DGV.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += DGV.Rows[i - 1].Cells[j].Value.ToString() + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Seu arquivo foi gerado!.");
            }
        }
        //Função que abre o Site do Emoticons. 
        public void chamaEmotic()
        {
            System.Diagnostics.Process.Start("https://www.emojicopy.com/");
        }
    }
}
