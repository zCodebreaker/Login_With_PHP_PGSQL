using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Launcher
{
    public partial class Init : Form
    {
        public Init()
        {
            InitializeComponent();
            Shown += async (s, e) => await LoadApp();
        }
        private async Task<bool> CheckConnection()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string launcherVersion = version != null ? version.ToString() : "0.0.0.0";

            string apiUrl = $"http://localhost/api/api.php?version={launcherVersion}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string responseData = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        Message.Mostrar("Erro", "[ERRO]: API Inacessível.");
                        return false;
                    }

                    JObject jsonResponse = JObject.Parse(responseData);

                    if (jsonResponse["status"].ToString() == "success")
                    {
                        string address = jsonResponse.ContainsKey("address") ? jsonResponse["address"].ToString() : "Desconhecido";
                        string appStatus = jsonResponse.ContainsKey("appstatus") ? jsonResponse["appstatus"].ToString() : "Desconhecido";
                        return true;
                    }
                    else if (jsonResponse["status"].ToString() == "error" && jsonResponse.ContainsKey("new_version"))
                    {
                        string newVersion = jsonResponse["new_version"].ToString();
                        lblstatus.Text = "Atualização disponível";

                        Message.Mostrar("Atualização disponível", "Uma nova versão está disponível. O atualizador será iniciado.");

                        try
                        {
                            Process.Start("AppUpdater.exe");
                            Environment.Exit(0);
                        }
                        catch (Exception ex)
                        {
                            Message.Mostrar("Erro", $"Falha ao iniciar o atualizador: {ex.Message}");
                        }

                        return false;
                    }
                    else if (jsonResponse["status"].ToString() == "error" && jsonResponse.ContainsKey("expected_ip"))
                    {
                        string expectedIp = jsonResponse["expected_ip"].ToString();
                        string actualIp = jsonResponse["actual_ip"].ToString();
                        Message.Mostrar("Erro", $"[ERRO]: Erro de configuração.\nIP esperado: {expectedIp}\nIP real: {actualIp}");
                        return false;
                    }
                    else if (jsonResponse["status"].ToString() == "error" && jsonResponse["message"].ToString() == "O servidor está OFFLINE.")
                    {
                        Message.Mostrar("Não foi possível conectar ao servidor.", "Erro");
                        return false;
                    }
                    else
                    {
                        Message.Mostrar("Erro", jsonResponse["message"].ToString());
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Message.Mostrar("Erro", $"Falha ao acessar a API: {ex.Message}");
                    return false;
                }
            }
        }
        private async Task LoadApp()
        {
            bool isConnected = await CheckConnection();

            if (!isConnected)
            {
                Application.Exit();
                return;
            }
            Thread.Sleep(35);
            Hide();
            Login Login = new Login();
            Login.Show();
        }
    }
}
