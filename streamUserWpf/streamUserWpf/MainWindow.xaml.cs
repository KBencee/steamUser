using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace streamUserWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Jatek> jatekokList; 
        private string filePath = "steamUser.csv";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            jatekokList = new List<Jatek>();
            foreach (var item in File.ReadAllLines(filePath, Encoding.UTF8).Skip(1))
            {
                try
                {
                    string[] parts = item.Split(';');
                    string nev = parts[0];
                    int id = Convert.ToInt32(parts[1]);
                    int ertekeles = Convert.ToInt32(parts[2]);
                    int ertekelokSzama = Convert.ToInt32(parts[3]);
                    DateOnly kiadas = DateOnly.Parse(parts[4]);
                    Jatek ujJatek = new(nev, id, ertekeles, ertekelokSzama, kiadas);
                    jatekokList.Add(ujJatek);
                }
                catch
                {
                    continue;
                }
            }
            dgJatekok.ItemsSource = jatekokList;
        }

        private void btnBestRated_Click(object sender, RoutedEventArgs e)
        {
            if (jatekokList == null || jatekokList.Count == 0)
            {
                MessageBox.Show("Nincs betöltött játéklista!");
                return;
            }

            var bestRated = jatekokList.MaxBy(j => j.Ertekeles);
            if (bestRated != null)
            {
                MessageBox.Show($"A legjobban értékelt játék: {bestRated.Nev} ({bestRated.Ertekeles} pont)");
            }
            else
            {
                MessageBox.Show("Nem található legjobban értékelt játék.");
            }
        }

        private void btnWorstRated_Click(object sender, RoutedEventArgs e)
        {
            if (jatekokList == null || jatekokList.Count == 0)
            {
                MessageBox.Show("Nincs betöltött játéklista!");
                return;
            }

            var worstRated = jatekokList.MinBy(j => j.Ertekeles);
            if (worstRated != null)
            {
                MessageBox.Show($"A legrosszabbul értékelt játék: {worstRated.Nev} ({worstRated.Ertekeles} pont)");
            }
            else
            {
                MessageBox.Show("Nem található legrosszabbul értékelt játék.");
            }
        }

        private void btnFirstReleased_Click(object sender, RoutedEventArgs e)
        {
            if (jatekokList == null || jatekokList.Count == 0)
            {
                MessageBox.Show("Nincs betöltött játéklista!");
                return;
            }

            var minDate = jatekokList.Min(j => j.Kiadas);
            var firstReleased = jatekokList.Where(j => j.Kiadas == minDate).ToList();

            var msg = $"Elsőként kiadott játék(ok) ({minDate}):\n" +
                      string.Join("\n", firstReleased.Select(j => j.Nev));
            MessageBox.Show(msg);
        }

        private void btnLastReleased_Click(object sender, RoutedEventArgs e)
        {
            if (jatekokList == null || jatekokList.Count == 0)
            {
                MessageBox.Show("Nincs betöltött játéklista!");
                return;
            }

            var maxDate = jatekokList.Max(j => j.Kiadas);
            var lastReleased = jatekokList.Where(j => j.Kiadas == maxDate).ToList();

            var msg = $"Utolsóként kiadott játék(ok) ({maxDate}):\n" +
                      string.Join("\n", lastReleased.Select(j => j.Nev));
            MessageBox.Show(msg);
        }
    }
}