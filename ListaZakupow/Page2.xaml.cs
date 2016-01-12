using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.IO;

namespace ListaZakupow
{
    public partial class Page2 : PhoneApplicationPage
    {
        public ObservableCollection<string> newLists = new ObservableCollection<string>();

        public Page2()
        {
            InitializeComponent();
            var obj = App.Current as App;

            string name = obj.NAME;
            NameOfLists.Text = name;

            IsolatedStorageFile MyFile = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                using (var isoFileStream = new IsolatedStorageFileStream("MyList/" + name + ".txt", System.IO.FileMode.Open, MyFile))
                {
                    using (var isoFileReader = new StreamReader(isoFileStream))
                    {

                   
                        for (int i = 0; i < isoFileStream.Length; i++ )
                        {
                            newLists.Add(isoFileReader.ReadLine());
                        }

                        
                        actualList.ItemsSource = newLists;
                       actualList.SelectionChanged += actualList_SelectionChanged;


                    }


                }
            }
            catch
            {
                MessageBox.Show("Brak pliku");
            }
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

        private void actualList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NewList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

       
        
    }
}