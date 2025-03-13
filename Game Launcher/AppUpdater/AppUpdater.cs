using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUpdater
{
    public partial class AppUpdater : Form
    {
        private string updateUrl;
        private string patchFile;
        private string fullDownloadUrl;
        private string savePath;
        private string extractPath;

        public AppUpdater()
        {
            InitializeComponent();
            Shown += async (s, e) => await CheckUpdate();
        }
        private async Task CheckUpdate()
        {
            lblstatus.Text = "Verificando atualizações...";
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string launcherVersion = version != null ? version.ToString() : "0.0.0.0";

            string apiUrl = $"http://localhost/api/api.php?version={launcherVersion}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string responseData = await response.Content.ReadAsStringAsync();

                    JObject jsonResponse = JObject.Parse(responseData);

                    if (jsonResponse["status"].ToString() == "error" && jsonResponse.ContainsKey("new_version"))
                    {
                        updateUrl = jsonResponse["update_url"].ToString().TrimEnd('/');
                        patchFile = jsonResponse["patch_file"].ToString();
                        fullDownloadUrl = $"{updateUrl}/{patchFile}";

                        if (!string.IsNullOrEmpty(updateUrl) && !string.IsNullOrEmpty(patchFile))
                        {
                            savePath = Path.Combine(Directory.GetCurrentDirectory(), patchFile);
                            extractPath = Directory.GetCurrentDirectory();

                            lblstatus.Text = $"Nova atualização disponível: {patchFile}";

                            await DownloadUpdate(fullDownloadUrl, savePath);
                        }
                        else
                        {
                            lblstatus.Text = "Nenhuma atualização foi encontrada.";
                        }
                    }
                    else
                    {
                        lblstatus.Text = "Nenhuma atualização foi encontrada.";
                        await Task.Delay(450);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao acessar API: {ex.Message}", "Erro");
                    Close();
                }
            }
        }       
        private async Task DownloadUpdate(string url, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    lblstatus.Text = "Baixando atualização...";
                    DOWNLOAD_BAR.Value = 0;

                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var receivedBytes = 0L;
                    byte[] buffer = new byte[8192];

                    using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        int bytesRead;
                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            receivedBytes += bytesRead;

                            if (totalBytes > 0)
                            {
                                DOWNLOAD_BAR.Value = (int)((receivedBytes * 100) / totalBytes);
                            }
                        }
                    }
                    lblstatus.Text = "Download concluído!";
                    await Task.Delay(1000);
                    ExtractUpdate();
                }
                catch (Exception ex)
                {
                    lblstatus.Text = $"Erro ao baixar: {ex.Message}";
                    await Task.Delay(2000);
                    Close();
                }
            }
        }
        private void ExtractUpdate()
        {
            try
            {
                lblstatus.Text = "Extraindo atualização...";

                if (!File.Exists(savePath))
                {
                    MessageBox.Show($"Erro: Arquivo ZIP não encontrado.\nPath: {savePath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tempExtractPath = Path.Combine(Path.GetTempPath(), "UpdateTemp");

                if (Directory.Exists(tempExtractPath))
                {
                    Directory.Delete(tempExtractPath, true);
                }
                Directory.CreateDirectory(tempExtractPath);

                ZipFile.ExtractToDirectory(savePath, tempExtractPath);

                lblstatus.Text = "Extração concluída!";
                MoveExtractedFiles(tempExtractPath, extractPath);
                File.Delete(savePath);

                lblstatus.Text = "Instalando atualização...";
                Process.Start("Launcher.exe");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao extrair atualização: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Task.Delay(2000).Wait();
                Close();
            }
        }
        private void MoveExtractedFiles(string sourceDir, string targetDir)
        {
            try
            {
                foreach (var file in Directory.GetFiles(sourceDir))
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFile = Path.Combine(targetDir, fileName);

                    if (File.Exists(destinationFile))
                    {
                        try
                        {
                            File.Delete(destinationFile);
                        }
                        catch (IOException)
                        {
                            string backupFile = destinationFile + ".old";
                            if (File.Exists(backupFile)) File.Delete(backupFile);
                            File.Move(destinationFile, backupFile);
                        }
                    }

                    File.Move(file, destinationFile);
                }
                Directory.Delete(sourceDir, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao mover arquivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BT_CLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
