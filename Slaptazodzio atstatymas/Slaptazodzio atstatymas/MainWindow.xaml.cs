using SlaptazodzioAtkurimas;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Slaptazodzio_Atkurimas
{
    public partial class MainWindow : Window
    {
        private BruteForce BruteForce;
        private Slaptazodziai Slaptazodziai;
        public MainWindow()
        {
            InitializeComponent();
            Slaptazodziai = new Slaptazodziai();
            BruteForce = new BruteForce();
        }
        // Mygtuko 'Koduoti slaptazodi' paspaudimo ivykis
        private async void KoduotiButton_Click(object sender, RoutedEventArgs e)
        {
            string slaptazodis = SlaptazodisTextBox.Text; // Gaunamas ivestas slaptazodis
            string UzkoduotasSlaptazodis = Slaptazodziai.KoduotiSlaptazodi(slaptazodis); // Uzkoduojamas slaptazodis
            UzkoduotasTextBox.Text = UzkoduotasSlaptazodis; // Isvedamas gautas uzkoduotas slaptazodis
        }
        // Mygtuko 'Atkurti slaptazodi' paspaudimo ivykis
        private async void AtkurtiButton_Click(object sender, RoutedEventArgs e)
        {
            string UzkoduotasSlaptazodis = UzkoduotasTextBox.Text; // Gaunamas uzkoduotas slaptazodis
            DateTime Pradzia = DateTime.Now; // Gaunamas uzduoties startavimo laikas
            string crackedPassword = await Task.Run(() => BruteForce.AtkurtiSlaptazodi(UzkoduotasSlaptazodis)); // Atkuriamas uzkoduotas slaptazodis brute force metodu 
            TimeSpan Laikas = DateTime.Now - Pradzia; // Skaiciuojamas uzduoties vykdymo laikas
            string LaikasString = $"{Laikas.TotalSeconds:F2} sek"; // Gaunamas uzduoties vykdymo laikas
            AtkurtasTextBox.Text = crackedPassword; // Isvedamas gautas atkurtas slaptazodis
            VykdymoLaikasTextBox.Text = LaikasString; // Isvedamas gautas uzduoties vykdymo laikas
        }
    }
}
