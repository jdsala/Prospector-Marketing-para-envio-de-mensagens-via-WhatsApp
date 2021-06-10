using System;
using WhatsAppApi;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ProjetoMarketing
{
    class SendMessage
    {
        string url = "https://web.whatsapp.com/";
        ChromeDriver driver; Thread th;
        bool start = true;

        public void SendWhatsAp(string number, string titulo, string message)
        {

            WhatsApp wa = new WhatsApp(number, "CODIGO", "Teste", false, false);
            

            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Connected to WahtsApp...");

                wa.OnLoginSuccess += (phoneNumber, data) =>
                {
                    wa.SendMessage(number, titulo);
                    MessageBox.Show("Mensagem enviada!!");
                };

                wa.OnLoginFailed += (data) =>
                {
                    MessageBox.Show("Login Failed : {0}", data);
                };
                wa.Login();
            };

            wa.OnConnectFailed += (ex) =>
            {
                MessageBox.Show("Connection Failed...");
            };
            wa.Connect();
        }
        //Metodo que serve para enviar WhatsApp

        public void SendWhatsApp(string dgvnumber, string titulo, string message)
        {
            WhatsApp wa = new WhatsApp(dgvnumber, message, "Bonus", false, false);

            if (dgvnumber.Length == 13)
            {

                wa.OnConnectSuccess += () =>
                {
                    MessageBox.Show("Connected to WahtsApp...");
                    // wa.OnLoginSuccess += (phoneNumber, data) =>

                    {
                        System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + dgvnumber + "&text=" + message);
                        // wa.SendMessage(dgvnumber, message);
                    };
                    wa.OnLoginFailed += (data) =>
                    {
                        MessageBox.Show("Login Failed : {0}", data);
                    };
                    wa.Login();
                };
            }
            else
            {
                wa.OnConnectFailed += (ex) =>
                {
                    MessageBox.Show("Connection Failed...");
                };
            }
        }

        public void SendWhatsAppp(string number, string titulo, string message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(number))
                {
                    MessageBox.Show("Não foi adicionado números");
                }

                foreach (var phone in number)
                {
                    if (number.Length == 11)
                    {
                        MessageBox.Show("Codigo pais adicionado");
                        number = "+55" + number;
                        number = number.Replace(" ", "");
                    }
                    if (number.Length == 13)
                    {
                        var url = "https://web.whatsapp.com/ ";

                        ChromeDriver driver = new ChromeDriver();
                        driver.Navigate().GoToUrl(url);
                        driver.Manage().Window.Maximize();

                        Thread.Sleep(10000);

                        var envia = driver.FindElementByClassName("_251VP");   

                        envia.SendKeys(number);

                        Thread.Sleep(1000);

                        var numberEl = driver.FindElementByXPath(number);

                        numberEl.Click();

                        var SendEl = driver.FindElementByXPath($"//span[2data-icon='send']");

                        SendEl.Click();

                        System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone= " + phone + "&text=" + titulo + message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex);
            }
        }
    }
}
