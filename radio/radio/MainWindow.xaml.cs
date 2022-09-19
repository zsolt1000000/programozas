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

namespace radio
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

        List<adatok> veetel = new List<adatok>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("veetel.txt");
            for (int i = 0; i < sorok.Length; i+=2)
            {
                veetel.Add(new adatok(sorok[i],sorok[i+1]));
            }
          }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "Az első üzenet rögzítője: " + veetel[0].AmatorSorszam;
            textBlock2.Text = "\n Az utolsó üzenet rögzítője: " + veetel.Last().AmatorSorszam;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            foreach (adatok a in veetel)
            {
                if (a.vaneFarkas())
                {
                    listbox.Items.Add(a.nap +" nap: "+a.AmatorSorszam+" rádióamatürt");
                }
            }
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            string[] teljesSzoveg = new string[11];
            for (int i = 0; i < teljesSzoveg.Length; i++)
            {
                for (int k = 0; k < 90; k++)
                {
                    teljesSzoveg[i] += "#";
                }

            }
            for (int i = 0; i < veetel.Count; i++)
            {
                for (int k = 0; k < veetel[i].adas.Length; k++)
                {
                    if (teljesSzoveg[veetel[i].nap-1][k]=='#')
                    {
                        if (veetel[i].adas[k]!='#')
                        {
                            string jo = teljesSzoveg[veetel[i].nap - 1];
                            jo = jo.Substring(0, k - 1) + veetel[i].adas[k] + jo.Substring(k + 1);
                            teljesSzoveg[veetel[i].nap - 1] = jo;
                        }
                    }
                }
            }
            for (int i = 0; i < teljesSzoveg.Length; i++)
            {
                L_5_szoveg.ItemsSource+=teljesSzoveg[i]+"\n";

            }
        }
    }
    class adatok
    {

        public int nap;
        public int AmatorSorszam;
        public string adas;

        public adatok (string sor1,string sor2)
        {
            String[] vag = sor1.Split(" ");
            nap = Convert.ToInt32(vag[0]);
            AmatorSorszam = Convert.ToInt32(vag[1]);
            adas = sor2;
        }
        public bool vaneFarkas()
        {
            return adas.IndexOf("farkas")>-1;
        }
        public bool szame (string szo)
        {
            bool valasz = true;
            for (int i = 0; i < szo.Length; i++)
            {
                if (szo[i]<'0' || szo[i]>'9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }
        /*
         * Függvény szame(szo:karaktersorozat): logikai 
 valasz:=igaz 
 Ciklus i:=1-től hossz(szo)-ig 
 ha szo[i]<'0' vagy szo[i]>'9' akkor valasz:=hamis 
 Ciklus vége 
 szame:=valasz 
Függvény vége 
         */
    }
}
