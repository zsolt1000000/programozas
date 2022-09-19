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
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szinesz
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
        List<adatok> sziniszek = new List<adatok>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("Oscar.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                sziniszek.Add(new adatok(sorok[i]));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> csillagDarab = new Dictionary<string, int>();
            for (int i = 0; i < sziniszek.Count; i++)
            {
                if (csillagDarab.ContainsKey(sziniszek[i].csillagjegy))
                {
                    csillagDarab[sziniszek[i].csillagjegy] += sziniszek[i].oscarDij;
                }
                else
                {
                    csillagDarab.Add(sziniszek[i].csillagjegy, sziniszek[i].oscarDij);
                }
            }
            listBox.ItemsSource = csillagDarab;
        
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int db = 0;
            for (int i = 0; i < sziniszek.Count; i++)
            {
                if (sziniszek[i].oscarDij>0)
                {
                    db++;
                }


            }
            label.Content = db + "Oscar dijas szinész van";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int maxIndex = 0;
            for (int i = 0; i < sziniszek.Count; i++)
            {
                if (sziniszek[i].szuletett >sziniszek[maxIndex].szuletett)
                {
                    maxIndex = i;
                }

            }
            label2.Content = sziniszek[maxIndex].csillagjegy;
        }
    }
    class adatok
    {
        public string nev;
        public DateTime szuletett;
        public string csillagjegy;
        public int oscarDij;
        public adatok(string sor)
        {
            string[] vag = sor.Split("\t");
            nev = vag[0];
            szuletett = Convert.ToDateTime(vag[1]);
            csillagjegy = vag[2];
            if (vag.Length==3 || vag[3]=="")
            {
                oscarDij =0;
            }
            else
            {
                oscarDij = Convert.ToInt32(vag[3]);
            }

        }
    }
}
