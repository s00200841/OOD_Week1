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

namespace OOD_Week1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Band> allBands = new List<Band>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Creation
            Band b1 = new Band() { BandName = "Nirvana", YearFormed = 1987, Members = "Kurt Cobain, Krist Novoselic, Dave Grohl" };
            Band b2 = new Band() { BandName = "The foo Fighters", YearFormed = 1994, Members = "Dave Grohl, Nate Mendel , Rami Jaffee" };
            Band b3 = new Band() { BandName = "Metalica", YearFormed = 1981, Members = "James hetfield, Lars Ulrich, Kirk Hammett" };
            Band b4 = new Band() { BandName = "Arctic Monkeys", YearFormed = 2002, Members = "Alex Turner, Matt Helders, Jamie Cook" };
            Band b5 = new Band() { BandName = "The Strokes", YearFormed = 1998, Members = "Julian Casablancas, nick Valensi, Fabrizio Moretti, Albert Hammond Jr" };
            Band b6 = new Band() { BandName = "ACDC", YearFormed = 1973, Members = "Angus Young, Malcolm Young, Bon Scott, Brian Johnson" };


            // Addition
            allBands.Add(b1);
            allBands.Add(b2);
            allBands.Add(b3);
            allBands.Add(b4);
            allBands.Add(b5);
            allBands.Add(b6);

            // Sort
            allBands.Sort();

            // Display
            lbxBands.ItemsSource = allBands;
        }
    }
}
