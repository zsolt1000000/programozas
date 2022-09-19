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

namespace eutazas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<adatok> adatLista = new List<adatok>();
        private void Beolvas_Click(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("utasadat.txt");
            
            for (int i = 0; i < sorok.Length; i++)
            {
                adatLista.Add(new adatok(sorok[i]));
            }
            adatok_db.Content = adatLista.Count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _2_feladat.Content = "A buszra " + adatLista.Count + " utas akart felszálni";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int db = 0;
            for (int i = 0; i < adatLista.Count; i++)
            {
                if (!adatLista[i].ervenyesE())
                {
                    db++;
                }
            }

            Feladat_3.Content = db;
        }

        private void Feladat_4_Click(object sender, RoutedEventArgs e)
        {
            int[] felszallok = new int[ 30];


            for (int i = 0; i < adatLista.Count; i++)
            {
                felszallok[adatLista[i].megallo]++;
            }
            int maxIndex = 0;
            for (int i = 0; i < felszallok.Length; i++)
            {
                if (felszallok[maxIndex]<felszallok[i])
                {
                    maxIndex = i;
                }
            }
            Feladat_4.Content = maxIndex;
            Feladat_4.i
        }
    }
    class adatok
        {
        public int megallo;
        public DateTime datum;
        public int kartyaId;
        public string tipus;
        public int darab;
        public DateTime ervenyes;
        public bool jegy;
        public bool ervenyesE()
        {
            if (darab==0)
            {
                return false;
            }
            if (ervenyes.AddDays(1)<datum)
            {
                return false;
            }
            return true;
        }
        public adatok(string sor)
        {
            string[] vag = sor.Split(" ");
            megallo = Convert.ToInt32(vag[0]);
            datum = new DateTime(Convert.ToInt32(vag[1].Substring(0, 4)),
                                Convert.ToInt32(vag[1].Substring(4, 2)),
                                Convert.ToInt32(vag[1].Substring(6, 2)),
                                Convert.ToInt32(vag[1].Substring(9, 2)),
                                Convert.ToInt32(vag[1].Substring(11,2)),
            0
            );
            kartyaId = Convert.ToInt32(vag[2]);
            tipus = vag[3];
            if (vag[4].Length>2)
            {
                ervenyes = new DateTime(Convert.ToInt32(vag[4].Substring(0, 4)),
                                Convert.ToInt32(vag[4].Substring(4, 2)),
                                Convert.ToInt32(vag[4].Substring(6, 2)),
                                0,
                                0,
                                0
            );
                darab = -1;
                jegy = false;
            }
            else
            {
                ervenyes = Convert.ToDateTime("0001-01-01");
                jegy = true;
                darab = Convert.ToInt32(vag[4]);
            }


        }
        }
}
