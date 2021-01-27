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
            // Creat Bands
            GrungeBand b1 = new GrungeBand() { BandName = "Nirvana", YearFormed = 1987, Members = "Kurt Cobain, Krist Novoselic, Dave Grohl" };

            RockBand b2 = new RockBand() { BandName = "The Foo Fighters", YearFormed = 1994, Members = "Dave Grohl, Nate Mendel , Rami Jaffee" };
            RockBand b3 = new RockBand() { BandName = "Arctic Monkeys", YearFormed = 2002, Members = "Alex Turner, Matt Helders, Jamie Cook" };
            RockBand b4 = new RockBand() { BandName = "The Strokes", YearFormed = 1998, Members = "Julian Casablancas, nick Valensi, Fabrizio Moretti, Albert Hammond Jr" };

            MetalBand b5 = new MetalBand() { BandName = "ACDC", YearFormed = 1973, Members = "Angus Young, Malcolm Young, Bon Scott, Brian Johnson" };
            MetalBand b6 = new MetalBand() { BandName = "Metalica", YearFormed = 1981, Members = "James hetfield, Lars Ulrich, Kirk Hammett" };

            // Create albums
            Random rand = new Random();

            // Nirvana
            Album a1 = new Album("Greatest Hits", rand.Next(1995, 2020), rand.Next(100000, 10000000));
            Album a2 = new Album("Nevermind", 1991, rand.Next(100000, 10000000));

            // Foo Fighters
            Album a3 = new Album("Greatest Hits", rand.Next(2004, 2020), rand.Next(100000, 10000000));
            Album a4 = new Album("One By One", 2002, rand.Next(100000, 10000000));

            // Arctic Monkeys
            Album a5 = new Album("Whatever People say I Am, thats what im not", 2006, rand.Next(100000, 10000000));
            Album a6 = new Album("Favourite Worst Nightmare", rand.Next(1995, 2020), rand.Next(100000, 10000000));

            // The Strokes
            Album a7 = new Album("Is This it", 2001, rand.Next(100000, 10000000));

            // ACDC
            Album a8 = new Album("Greatest Hits", rand.Next(1995, 2020), rand.Next(100000, 10000000));
            Album a9 = new Album("ACDC Live", 1992, rand.Next(100000, 10000000));

            // Metalica
            Album a10 = new Album("Metalica", 1991, rand.Next(100000, 10000000));
            Album a11 = new Album("Master of Puppets", 1986, rand.Next(100000, 10000000));
            Album a12 = new Album("Kill 'Em All", 1983, rand.Next(100000, 10000000));

            // Add Albums
            b1.AlbumList.Add(a1);
            b1.AlbumList.Add(a2);

            b2.AlbumList.Add(a3);
            b2.AlbumList.Add(a4);

            b3.AlbumList.Add(a5);
            b3.AlbumList.Add(a6);

            b4.AlbumList.Add(a7);

            b5.AlbumList.Add(a8);
            b5.AlbumList.Add(a9);

            b6.AlbumList.Add(a10);
            b6.AlbumList.Add(a11);
            b6.AlbumList.Add(a12);

            // Add Bands
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

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selectedBand = lbxBands.SelectedItem as Band;

            if (selectedBand != null)
            {
                lbxAlbums.ItemsSource = selectedBand.AlbumList;

                tblkBandInfo.Text = string.Format($"{selectedBand.BandName} Formed in : {selectedBand.YearFormed}" +
                                                  $"\nMembers : {selectedBand.Members}");
            }
        }
    }
}
