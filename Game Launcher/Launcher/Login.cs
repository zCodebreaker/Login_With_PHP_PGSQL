using Game_Launcher.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Launcher
{
    public partial class Login : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private string savePath = "infos.txt";

        public Login()
        {
            InitializeComponent();
            CarregarLogin();
        }
        private void BT_CLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async Task<Tuple<string, string>> CheckLogin(string usuario, string senha, string hwid)
        {
            var loginData = new Dictionary<string, object>
            {
                { "usuario", usuario },
                { "senha", senha },
                { "hwid", hwid }
            };

            string json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost/api/login.php", content);
            string responseString = await response.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);
                if (!result.ContainsKey("status"))
                {
                    return new Tuple<string, string>("Erro ao processar resposta!", null);
                }

                int status = Convert.ToInt32(result["status"]);
                string erro = result.ContainsKey("erro") ? result["erro"].ToString() : "";

                string mensagem;
                if (status == 200 || status == 201)
                {
                    mensagem = $"Usuário {usuario} logado com sucesso.";
                    return new Tuple<string, string>(mensagem, usuario);
                }
                else if (status == 400)
                {
                    mensagem = "Erro: Campos obrigatórios ausentes.";
                }
                else if (status == 401)
                {
                    mensagem = "Usuário ou senha estão inválidos.";
                }
                else if (status == 403)
                {
                    if (erro == "senha_errada")
                        mensagem = "Usuário ou senha estão inválidos";

                    else if (erro == "banido")
                        mensagem = "Sua conta está bloqueada, entre em contato com o suporte.";

                    else if (erro == "hwid_errado")
                        mensagem = "HWID não autorizado ou está diferente.";
                    else
                        mensagem = "Erro: Acesso negado.";
                }
                else
                {
                    mensagem = "Erro desconhecido. Código: " + status;
                }

                return new Tuple<string, string>(mensagem, null);
            }
            catch (Exception ex)
            {
                return new Tuple<string, string>($"Erro ao processar resposta do servidor!\n{ex.Message}", null);
            }
        }

        private async void BT_LOGIN_Click_1(object sender, EventArgs e)
        {
            string usuario = LoginTxT.Text;
            string senha = SenhaTxT.Text;
            string hwid = GetHWID.GetUserHWID();

            var resultado = await CheckLogin(usuario, senha, hwid);
            string mensagem = resultado.Item1;
            string usuarioLogado = resultado.Item2;

            if (!string.IsNullOrEmpty(usuarioLogado))
            {
                Message.Mostrar(mensagem, "Your Project");

                if (Lembrar_Senha.Checked)
                {
                    SalvarLogin(usuario, senha);
                }
                else
                {
                    DeleteInfos();
                }

                Form1 optimizerForm = new Form1();
                optimizerForm.Show();
                Close();
            }
            else
            {
                Message.Mostrar(mensagem, "Your Project");
            }
        }
        private void SalvarLogin(string username, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            File.WriteAllText(savePath, username + "|" + hashedPassword);
        }
        private void CarregarLogin()
        {
            if (File.Exists(savePath))
            {
                string[] data = File.ReadAllText(savePath).Split('|');
                if (data.Length == 2)
                {
                    LoginTxT.Text = data[0];
                    Lembrar_Senha.Checked = true;
                }
                else
                {
                    MessageBox.Show("Arquivo de credenciais inválido, será apagado.");
                    DeleteInfos();
                }
            }
        }
        private void DeleteInfos()
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }
    }
}
