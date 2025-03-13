using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Game_Launcher.Config
{
    public class GetHWID
    {
        public static string GetUserHWID()
        {
            try
            {
                string cpuId = GetProcessorId();
                string diskSerial = GetDiskSerialNumber();
                string combined = cpuId + diskSerial;

                return ComputeSha256Hash(combined);
            }
            catch (Exception ex)
            {
                return "Erro ao obter HWID: " + ex.Message;
            }
        }

        private static string GetProcessorId()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["ProcessorId"].ToString();
                }
            }
            catch { }
            return "CPU_NOT_FOUND";
        }

        private static string GetDiskSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["SerialNumber"].ToString().Trim();
                }
            }
            catch { }
            return "DISK_NOT_FOUND";
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
