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
using System.Collections.Generic;
using System.Linq;

namespace Urhajok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Urhajok
        {
            public string Név { get; set; }
            public int Legénység { get; set; }
            public int MaxHatótáv { get; set; }
            public int ÜzemanyagSzint { get; set; }
            public string Gyártó { get; set; }
            public string KüldetésStátusz { get; set; }
            public int IndításÉve { get; set; }

            public Urhajok(string név, int legénység, int maxHatótáv, int üzemanyagSzint, string gyártó, string küldetésStátusz, int indításÉve)
            {
                Név = név;
                Legénység = legénység;
                MaxHatótáv = maxHatótáv;
                ÜzemanyagSzint = üzemanyagSzint;
                Gyártó = gyártó;
                KüldetésStátusz = küldetésStátusz;
                IndításÉve = indításÉve;
            }

        }
        List<Urhajok> urhajoLista = new List<Urhajok>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void betolt_Click(object sender, RoutedEventArgs e)
        {
            urhajoLista = new List<Urhajok>()
            {
                new Urhajok("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020),
                new Urhajok("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023),
                new Urhajok("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019),
                new Urhajok("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018),
                new Urhajok("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022),
                new Urhajok("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017),
                new Urhajok("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024),
                new Urhajok("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021),
                new Urhajok("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016),
                new Urhajok("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020)
            };
            datagrid.ItemsSource = urhajoLista;
        }

        private void urhajokszama_Click(object sender, RoutedEventArgs e)
        {
            if (urhajoLista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve az űrhajók");
                return;
            }
            MessageBox.Show("Űrhajók száma: " + urhajoLista.Count);
        }

        private void hatotav_Click(object sender, RoutedEventArgs e)
        {
            if (urhajoLista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve az űrhajók");
                return;
            }
            var legnagyobb = urhajoLista.OrderByDescending(u => u.MaxHatótáv).First();
            MessageBox.Show("A legnagyobb hatótávú űrhajó: " + legnagyobb.Név + " " + legnagyobb.MaxHatótáv + " km");

        }

        private void kuldetes_Click(object sender, RoutedEventArgs e)
        {
            if (urhajoLista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve az űrhajók");
                return;
            }
            var sikeresek = urhajoLista.Where(u => u.KüldetésStátusz == "Sikeres").Select(u => u.Név);
            MessageBox.Show("Sikeres küldetések:\n" + string.Join("\n", sikeresek));

        }

        private void atlag_Click(object sender, RoutedEventArgs e)
        {
            if (urhajoLista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve az űrhajók");
                return;
            }
            double atlag = urhajoLista.Average(u => u.Legénység);
            MessageBox.Show($"Átlagos legénység: {atlag:F2} fő");
        }

    

        private void gyartok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kereses_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}