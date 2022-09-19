using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szinkep
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
        List<adatok> szinek = new List<adatok>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("kep.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                szinek.Add ( new adatok(sorok[i]));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Ellenorzes_Click(object sender, RoutedEventArgs e)
        {
            adatok a = new adatok(RGB_beker.Text.Replace(",", " "));

            bool volt = false;
            for (int i = 0; i < szinek.Count; i++)
            {
                if (szinek[i].r==a.r && szinek[i].g == a.g &&szinek[i].b== a.b)
                {
                    volt = true;
                    break;
                }
            }

            if (volt)
            {
                kiirat.Content = "van ilyen szin";
            }
            else
            {
                kiirat.Content = "Nem volt ilyen";
            }
        }

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            int sor = Convert.ToInt32(Sor.Text);
            int oszlop = Convert.ToInt32(Oszlop.Text);
            int keresettIndx = (sor - 1) * 50 + (oszlop - 1);

            int darab1=0;
            int darab2=0;
            for (int i = (sor-1)*50; i < 50*sor; i++)
            {
                if (szinek[i].r ==szinek[keresettIndx].r && szinek[i].g == szinek[keresettIndx].g && szinek[i].b == szinek[keresettIndx].b)
                {
                    darab1++;
                }
            }
            for (int i = (oszlop - 1); i < szinek.Count; i+=50)
            {
                if (szinek[i].r == szinek[keresettIndx].r && szinek[i].g == szinek[keresettIndx].g && szinek[i].b == szinek[keresettIndx].b)
                {
                    darab2++;
                }
            }
            Keres_Eredmeny.Content = "Sor:" + darab1 + "db, oszlop" + darab2 + "db";
        }

        private void szinkeres_Click(object sender, RoutedEventArgs e)
        {
            adatok[] a = new adatok[3];

            a[0]=new adatok(PIROS.Text.Replace(",", " "));
            a[1]=new adatok(ZÖLD.Text.Replace(",", " "));
            a[2]=new adatok(KEK.Text.Replace(",", " "));

            int[] db = new int[3];


            for (int i = 0; i < szinek.Count; i++)
            {
                for (int k = 0; k < a.Length; k++)
                {
                    if (szinek[i].r == a[k].r && 
                        szinek[i].g == a[k].g && 
                        szinek[i].b == a[k].b)
                    {
                        db[k]++;
                    }
                }
            }

            int maxIndex = 0;
            for (int i = 0; i < db.Length; i++)
            {
                if (db[maxIndex]<db[i])
                {
                    maxIndex = i;
                }
            }
            PIROS.Background = Brushes.Transparent;
            ZÖLD.Background = Brushes.Transparent;
            KEK.Background = Brushes.Transparent;

            if (maxIndex==0)
            {
                PIROS.Background = Brushes.Red;
            }
            if (maxIndex == 1)
            {
                ZÖLD.Background = Brushes.LimeGreen;
            }
            if (maxIndex == 2)
            {
                KEK.Background = Brushes.Blue;
            }
           

        }
        List<adatok> keretesSzinek = new List<adatok>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            keretesSzinek.Clear();
            adatok fekete = new adatok("0 0 0");
            for (int i = 0; i < 3*56; i++)
            {
                keretesSzinek.Add(fekete);
            }

            for (int i = 0; i < szinek.Count; i++)
            {
                if (i%50==0)
                {
                    keretesSzinek.Add(fekete);
                    keretesSzinek.Add(fekete);
                    keretesSzinek.Add(fekete);

                }
                keretesSzinek.Add(szinek[i]);
                if (i % 50 == 49)
                {
                    keretesSzinek.Add(fekete);
                    keretesSzinek.Add(fekete);
                    keretesSzinek.Add(fekete);

                }
            }

            for (int i = 0; i < 3 * 56; i++)
            {
                keretesSzinek.Add(fekete);
            }
        }

        private void HATODIK_FELADAT_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter ir = new StreamWriter("keretes.txt");

            foreach (var item in keretesSzinek)
            {
                ir.WriteLine(item);
            }

            ir.Close();
        }

        private void SARGA_Click(object sender, RoutedEventArgs e)
        {
            adatok sarga = new adatok("255 255 0");
            int elso = -1;
            int utolso = -1;
            int db = 0;
            for (int i = 0; i < szinek.Count; i++)
            {
                if (szinek[i].r == sarga.r && szinek[i].g == sarga.g && szinek[i].b == sarga.b)
                {
                    if (elso ==-1)
                    {
                        elso = i;
                    }
                    utolso = i;

                    db++;
                }
            }
        }
    }
    class adatok
    {
        public int r,g,b;


        public adatok (string sor)
        {
            string[] vag = sor.Split(" ");
            r = Convert.ToInt32(vag[0]);
            g = Convert.ToInt32(vag[1]);
            b = Convert.ToInt32(vag[2]);
        }
        public override string ToString()
        {
            return r+" "+g+" "+b+" "; 
        }
    }

}
