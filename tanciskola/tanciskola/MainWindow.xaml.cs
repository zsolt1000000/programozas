using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tanciskola
{    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<adatok> adatlista = new List<adatok>();
        private void Beolvas_Click(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("tancrend.txt");
            for (int i = 0; i < sorok.Length; i+=3)
            {
                adatlista.Add(new adatok(sorok[i],sorok[i+1],sorok[i+2]));
                ellenorzesek.Content = adatlista.Count+" db sort olvasott be";
            }
            ellenorzes.ItemsSource = sorok;

        }

        private void elso_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
            első_Tanc.Content=adatlista[i].tanc;
            }
        }

        private void Utolso_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < adatlista.Count; i++)
            {
                utolso_Tanc.Content = adatlista[i].tanc;
            }
        }

        private void Feladat_3_Click(object sender, RoutedEventArgs e)
        {
            int SzambaPar(string tanc)
            {
                int db = 0;
                for (int i = 0; i < adatlista.Count; i++)
                {
                    if (adatlista[i].tanc == "samba")
                    {
                        db++;
                    }
                }
                return db;

            }
            parok.Content = SzambaPar("tanc");


            for (int i = 0; i < adatlista.Count; i++)
            {

                parok_neve.Items.Add(    adatlista[i].fiu + " és " + adatlista[i].lany + " ");

            }
          
        }

        private void Feladat_4_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < adatlista.Count; i++)
            {
                if (adatlista[i].lany=="Vilma")
                {
                    Feladatok_4.Items.Add(adatlista[i].tanc);
                }
            }
        }

        private void Feladat_5_Click(object sender, RoutedEventArgs e)
        {
            string tanc =Convert.ToString( beker_2);
            string nev = Convert.ToString(Lany_neve);
            for (int i = 0; i < adatlista.Count; i++)
            {

                if (adatlista[i].tanc == tanc)
                {
                    if (adatlista[i].lany == nev)
                    {
                        visszad_2.Items.Add("A "+tanc+"bemutatóján " +nev+" párja "+adatlista[i].fiu+" volt");
                    }
                    else
                    {
                        visszad_2.Items.Add(nev+" nem táncolt " + tanc + "-t");
                    }
                }
                
            }
        }

    }

    class adatok
    {
        public string tanc;
        public string lany;
        public string fiu;

        public adatok(string tanc,string lany, string fiu)
        {

            this.tanc = tanc;
            this.lany = lany;
            this.fiu = fiu;
                
             
          
        }


    }
}
