using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMarketing
{

    public class ClassPrincipal
    {

        public void SendWhatsApp(string number, string message)

        {
            try

            {

                if (string.IsNullOrWhiteSpace(number))

                {

                    MessageBox.Show("Campo de numeros esta Vacio!");
                }

                if (number.Length <= 10)

                {
                    MessageBox.Show("Falta numeros! Verificar");

                    number = "+55" + number;
                }

                number = number.Replace(" ", "");

                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);

            }

            catch (Exception ex)

            {

            }

        }
        public void ValidaExtensao(string file)
        {
            string extensao = Path.GetExtension(file);
            string[] extensoesValidas = new string[] { ".csv" };

            if (!extensoesValidas.Contains(extensao))
            {

                MessageBox.Show("Extensão de arquivo não e suportada", extensao);

                return;


            }
        }
        //Funçao que exporta Dados para o Excel
        public void ExportarDados(DataGridView datalist)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColuna = 0;
                foreach (DataGridViewColumn columna in datalist.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColuna++;
                    excel.Cells[1, IndiceColuna] = columna.Name;
                }
                int IndiceLinha = 0;
                foreach (DataGridViewRow fila in datalist.Rows) //Aquí leemos las filas de las columnas leídas
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
            catch (Exception)
            {
                MessageBox.Show("Erro.");
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
    }
}
