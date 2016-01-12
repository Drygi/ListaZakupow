using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.IO;

namespace ListaZakupow
{
    public partial class MainPage : PhoneApplicationPage
    {
      

      //  public static TextDecorationCollection ST;
       

        public ObservableCollection<string> list = new ObservableCollection<string>();


        IsolatedStorageFile files = IsolatedStorageFile.GetUserStoreForApplication();
        IsolatedStorageSettings name = IsolatedStorageSettings.ApplicationSettings;

        private string nameOfList;
    


        public MainPage()
        {
            InitializeComponent();

            ListOfProducts.ItemsSource = list;
            ListOfProducts.SelectionChanged += ListBox_SelectionChanged;
            
               
          
        }
        // Use the default font values for the strikethrough text decoration. 
        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
           
        }
        private void AddItem(object sender, RoutedEventArgs e)
        {
            
            if(! String.IsNullOrWhiteSpace(AddingProduct.Text)) {
            list.Add(AddingProduct.Text);
          
            
                }
            AddingProduct.Text = "";
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {

            int zaznaczonyProdukt = ListOfProducts.SelectedIndex;
            if (zaznaczonyProdukt != -1)

                list.RemoveAt(zaznaczonyProdukt);
     
           
        }

       

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (list.Count != 0)
            {
                saver.Visibility = Visibility.Visible;
                ok.Visibility = Visibility.Visible;
                AddingProduct.Visibility = Visibility.Collapsed;
                Save.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Lists.Visibility = Visibility.Collapsed;
                ListOfProducts.Visibility = Visibility.Collapsed;
               
            }
            else
                MessageBox.Show("Brak produktów do zapisania");

        }


        private void Load_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {


            if ((!String.IsNullOrWhiteSpace(saver.Text)))
            {

                if (name.Contains("nazwaListy"))
                {
                    name.Remove("nazwaListy");
                    name.Add("nazwaListy", saver.Text);
                    nameOfList = name["nazwaListy"].ToString();

                }
                else
                {  
                    name.Add("nazwaListy", saver.Text);
                    nameOfList = name["nazwaListy"].ToString();
       
            }
                

                saver.Visibility = Visibility.Collapsed;
                ok.Visibility = Visibility.Collapsed;
                AddingProduct.Visibility = Visibility.Visible;
                saver.Text = "Podaj nazwę listy";
                Save.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
                Delete.Visibility = Visibility.Visible;
                Lists.Visibility = Visibility.Visible;
                ListOfProducts.Visibility = Visibility.Visible;
               

                NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
               
              

          
            
           //zapisywanie listy
           
            IsolatedStorageFile file1 = IsolatedStorageFile.GetUserStoreForApplication();
            
               file1.CreateDirectory("MyList");


               using (var isoFileStream = new IsolatedStorageFileStream("MyList/" + nameOfList + ".txt", System.IO.FileMode.OpenOrCreate, file1))
                 {
             using (var isoFileWriter = new StreamWriter(isoFileStream))
                             {
                                foreach(string x in list)
                                 {
                                   isoFileWriter.WriteLine(x.ToString());

                                 }
                
               
                        }

        }
         
              ///////////////////////////////////////
            ///zapisywanie nazwy listy.//////////
            /////////////////////////////////////////////
            
                IsolatedStorageFile file2 = IsolatedStorageFile.GetUserStoreForApplication();

               
            file2.CreateDirectory("NameOfList"); 


                using (var isoFileStream2 = new IsolatedStorageFileStream("NameOfList/"+ nameOfList, System.IO.FileMode.OpenOrCreate, file2))
                {
                    using (var isoFileWriter2 = new StreamWriter(isoFileStream2))
                    {
                       
                        isoFileWriter2.WriteLine(nameOfList);

                    }

                }
            }
            else
                MessageBox.Show("Nazwa listy nie została podana, spóbuj ponownie!");
             
        }

        private void saver_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void saver_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            saver.Text = "";
        }

       

       

      

    

       

       
    }

       

    }
