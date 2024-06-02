using System;
using System.Threading.Tasks;

namespace SlaptazodzioAtkurimas
{
    public class BruteForce
    {
        private Slaptazodziai slaptazodziai; // Pavyzdys, skirtas slaptazodziams tikrinti
        private readonly char[] simboliai = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray(); // Simboliu rinkinys Brute force metodui
        private readonly int maxilgis = 7; // Maksimalus atkuriamo slaptazodzio ilgis
        private string AtkurtasSlaptazodis; // Kintamasis, kuriame saugomas atkurtas slaptazodis

        public BruteForce()
        {
            slaptazodziai = new Slaptazodziai(); // Sukuriamas slaptazodio kodavimo klases egzempliorius
        }
        // Metodas, skirtas slaptazodzio atkurimui
        public string AtkurtiSlaptazodi(string UzkoduotasSlaptazodis)
        {
            AtkurtasSlaptazodis = null;
            Parallel.For(1, maxilgis + 1, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, ilgis =>
            {
                if (AtkurtasSlaptazodis == null)
                {
                    Rekursija(new char[ilgis], 0, ilgis, UzkoduotasSlaptazodis);
                }
            });

            return AtkurtasSlaptazodis;
        }
        // Metodas, skirtas slaptazodzio kombinaciju generavimui ir testavimui
        private void Rekursija(char[] prefix, int pozicija, int ilgis, string UzkoduotasSlaptazodis)
        {
            if (AtkurtasSlaptazodis != null || pozicija == ilgis)
            {
                return; // Stabdoma, jei rastas slaptazodis arba pasiektas maksimalus atkuriamo slaptazodzio ilgis
            }

            foreach (char character in simboliai)
            {
                prefix[pozicija] = character;
                string attempt = new string(prefix);
                if (slaptazodziai.Patikrinti(attempt, UzkoduotasSlaptazodis))
                {
                    AtkurtasSlaptazodis = attempt;
                    return;
                }
                if (AtkurtasSlaptazodis == null)
                {
                    Rekursija(prefix, pozicija + 1, ilgis, UzkoduotasSlaptazodis);
                }
            }
        }
    }
}
