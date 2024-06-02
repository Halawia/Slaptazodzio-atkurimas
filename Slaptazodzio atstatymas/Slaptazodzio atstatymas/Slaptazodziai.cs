using System;
using System.Security.Cryptography;
using System.Text;

namespace SlaptazodzioAtkurimas
{
    // Klase, kuri skirta slaptazodio kodavimui 
    public class Slaptazodziai
    {
        private static readonly string salt = "reiksme"; // Statine salt reiksme
        // Metodas slaptazodzio kodavimui naudojant SHA256
        public string KoduotiSlaptazodi(string slaptazodis)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltedSlaptazodis = Encoding.UTF8.GetBytes(slaptazodis + salt);
                byte[] hash = sha256.ComputeHash(saltedSlaptazodis);
                return Convert.ToBase64String(hash);
            }
        }
        // Metodas, skirtas patikrinti ar uzkoduotas slaptazodis atitinka duotam slaptazodziui
        public bool Patikrinti(string slaptazodis, string UzkoduotasSlaptazodis)
        {
            return KoduotiSlaptazodi(slaptazodis) == UzkoduotasSlaptazodis;
        }
    }
}
