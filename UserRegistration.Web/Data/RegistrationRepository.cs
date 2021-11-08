using System;
using System.IO;
using System.Text.Json;
using UserRegistration.Web.Models;

namespace UserRegistration.Web.Data
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public bool Register(UserModel user)
        {
            try
            {
                string path1 = Directory.GetCurrentDirectory();
                string path = path1 + @"\Data\Resigtrations.json";
                if (!File.Exists(path))
                {
                    using FileStream fileStream = File.Create(path);
                }
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonStr = JsonSerializer.Serialize(user, options);
                File.AppendAllText(path, jsonStr);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
