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
    /// Student ID : S00200841
    /// Student Name : Andrew Casey
    /// 27/01/2021 Note : as far as parts 12-13, exausted and need a break have the week to finish so will get back to try them 
    /// 02/02/2021 5:00 have some time to try and do last 2 parts before sending.
    /// Cant be sure if save works correctly but its there now .EDIT : It Works... Great
    /// Got TimeDate Working as it should also
    /// Realy didnt think i would get time to finish this 
    /// Also added functionality for saving bands and albums in one file
    /// 02/02/2021 7:10 Done 
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
            // Combobox setup
            string[] genres = { "All", "Grunge", "Rock", "Metal" };
            cbxGenre.ItemsSource = genres;


            // Creat Bands
            GrungeBand b1 = new GrungeBand() { BandName = "Nirvana", YearFormed = 1987, Members = "Kurt Cobain, Krist Novoselic, Dave Grohl" };

            RockBand b2 = new RockBand() { BandName = "The Foo Fighters", YearFormed = 1994, Members = "Dave Grohl, Nate Mendel , Rami Jaffee" };
            RockBand b3 = new RockBand() { BandName = "Arctic Monkeys", YearFormed = 2002, Members = "Alex Turner, Matt Helders, Jamie Cook" };
            RockBand b4 = new RockBand() { BandName = "The Strokes", YearFormed = 1998, Members = "Julian Casablancas, Nick Valensi, Fabrizio Moretti, Albert Hammond Jr" };

            MetalBand b5 = new MetalBand() { BandName = "ACDC", YearFormed = 1973, Members = "Angus Young, Malcolm Young, Bon Scott, Brian Johnson" };
            MetalBand b6 = new MetalBand() { BandName = "Metalica", YearFormed = 1981, Members = "James Hetfield, Lars Ulrich, Kirk Hammett" };

            // Create albums
            Random rand = new Random();

            // Nirvana
            Album a1 = new Album("Greatest Hits", new DateTime(rand.Next(1995, 2020), rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));
            Album a2 = new Album("Nevermind", new DateTime(1991,04,11), rand.Next(100000, 10000000));

            // Foo Fighters
            Album a3 = new Album("Greatest Hits", new DateTime(rand.Next(2004, 2020),rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));
            Album a4 = new Album("One By One", new DateTime(2002, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));

            // Arctic Monkeys
            Album a5 = new Album("Whatever People say I Am, thats what im not", new DateTime(2006, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));
            Album a6 = new Album("Favourite Worst Nightmare", new DateTime(rand.Next(1995, 2020),rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));

            // The Strokes
            Album a7 = new Album("Is This it", new DateTime(2001, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));

            // ACDC
            Album a8 = new Album("Greatest Hits", new DateTime(rand.Next(1995, 2020),rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));
            Album a9 = new Album("ACDC Live", new DateTime(1992, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));

            // Metalica
            Album a10 = new Album("Metalica", new DateTime(1991, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));
            Album a11 = new Album("Master of Puppets", new DateTime(1986, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));
            Album a12 = new Album("Kill 'Em All", new DateTime(1983, rand.Next(1, 12), rand.Next(1, 31)), rand.Next(100000, 10000000));

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

        // Filters bands based on the ComboBox
        private void cbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // whats selected
            string selectedGenre = cbxGenre.SelectedItem as string;

            // filter list
            List<Band> filteredList = new List<Band>();

            switch (selectedGenre)
            {
                case "All":
                    lbxBands.ItemsSource = allBands;
                    break;

                case "Grunge":
                    foreach(Band band in allBands)
                    {
                        if (band is GrungeBand)
                            filteredList.Add(band);
                    }
                    lbxBands.ItemsSource = filteredList;
                    break;

                case "Rock":
                    foreach (Band band in allBands)
                    {
                        if (band is RockBand)
                            filteredList.Add(band);
                    }
                    lbxBands.ItemsSource = filteredList;
                    break;

                case "Metal":
                    foreach (Band band in allBands)
                    {
                        if (band is MetalBand)
                            filteredList.Add(band);
                    }
                    lbxBands.ItemsSource = filteredList;
                    break;
            }
        }

        // Having some issue on my side with the IO.Reader not having permissions to save file but i think this is correct
        // Edit: fixed and works quite well.
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool noErrorMessage = true;
            // have "Band Information" in tblkBandInfo.Text so i say if its not that then do something
            if (tblkBandInfo.Text != "Band Information")
            {
                // Attempt to save
                // try catch is just stoping any crash if it can't save.                
                try
                {
                    var list = new List<string>();
                    foreach(var item in lbxAlbums.Items)
                    {
                        list.Add(item.ToString());
                    }
                    System.IO.File.WriteAllText(@"C:\Users\New User\Desktop\IT Sligo\Y2 S2\OOP\Sample.txt", $"{tblkBandInfo.Text}\nAlbums\n");
                    System.IO.File.AppendAllLines(@"C:\Users\New User\Desktop\IT Sligo\Y2 S2\OOP\Sample.txt", list);
                }
                catch (Exception error)
                {
                    // MessageBox to say Can Not Save if there is an issue
                    MessageBox.Show("Can Not Save Correctly\n" + error.Message);
                    noErrorMessage = false;
                }
                // If i get an error this wont show, time wise i thought this would suit me since i had errors to fix for a while
                if (noErrorMessage)
                {
                    MessageBox.Show("File Has Been Saved");
                }
            }
        }
    }
}
