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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Szeva");
            More.Content = ("Kacsa");
        }
        Random rand = new Random();
        List<int> szamok = new List<int>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int szam = rand.Next(1000);

            szamok.Add(szam);
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider1.Content = (int)sliderfo.Value;
        }

        private void Buttonbal_Click(object sender, RoutedEventArgs e)
        {
            sliderfo.Value--;
        }

        private void buttonjobb_Click(object sender, RoutedEventArgs e)
        {
            sliderfo.Value++;
        }

        private void buttonjobb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sliderfo.Value++;

        }
    }
}
