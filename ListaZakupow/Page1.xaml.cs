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
    public partial class Page1 : PhoneApplicationPage
    {
      public ObservableCollection <string> Lists = new ObservableCollection<string>();
      IsolatedStorageFile MyFile = IsolatedStorageFile.GetUserStoreForApplication();
     
      

        public Page1()
        {
           

           
            InitializeComponent();
//dodawanie do tablicy stringow nazw listy
       
            {
                MyFile.CreateDirectory("NameOfList");
            string[] subdirs = MyFile.GetFileNames("NameOfList/");
            foreach(string z in subdirs)
                {

                    myLists.ItemsSource = subdirs;
                    myLists.SelectionChanged += myLists_SelectionChanged;
                }
             
        }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void myLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }
 

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            if(myLists.SelectedIndex != -1) {
               
                string name = myLists.SelectedItem.ToString();
                obj.NAME = name;
                NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
            }
                else
                { 
                    MessageBox.Show("Lista nie zostala zaznaczona");
                    }


        
        }

        private void NewList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Page1.xaml?" + DateTime.Now.Ticks, UriKind.Relative));
             if(myLists.SelectedIndex != -1) {
         int selectedProduct = myLists.SelectedIndex;
         if (selectedProduct != -1)

            
           
         MyFile.DeleteFile("NameOfList/"+ myLists.SelectedItem.ToString());
  

        }
             else
                {
                 MessageBox.Show("Lista nie została zaznaczona");
                }
                
    
        }

        

    }


}

