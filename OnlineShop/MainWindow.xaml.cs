using OnlineShop.Classes;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public int scrolll = 0;
        private List<Product> elecronics;
        private List<Product> jewelery;
        private List<Product> mensClothing;
        private List<Product> WomansClothing;
        public MainWindow()
        {
            InitializeComponent();
            LoadProduct();
            LoadPage.ObrazecProduct = Elecronic1;
            LoadPage.Korzina = ButtonKorzina;


        }



        public async void LoadProduct()
        {
            elecronics = await ProductProcessor.GetFromCategory("electronics");
            jewelery = await ProductProcessor.GetFromCategory("jewelery");
            mensClothing = await ProductProcessor.GetFromCategory("men's clothing");
            WomansClothing = await ProductProcessor.GetFromCategory("women's clothing");


            List<Uri> imel = await LoadPage.LoadImage(elecronics);
            foreach (Uri uri in imel)
            {
                Image image = new Image();
                image.Width = 150;
                image.Height = 150;
                image.Source = new BitmapImage(uri);
                image.Margin = new Thickness(10);
                ElMain.Children.Add(image);
            }
            List<Uri> imj = await LoadPage.LoadImage(jewelery);
            foreach (Uri uri in imj)
            {
                Image image = new Image();
                image.Width = 150;
                image.Height = 150;
                image.Source = new BitmapImage(uri);
                image.Margin = new Thickness(10);
                JMain.Children.Add(image);
            }
            List<Uri> imen = await LoadPage.LoadImage(mensClothing);
            foreach (Uri uri in imen)
            {
                Image image = new Image();
                image.Width = 150;
                image.Height = 150;
                image.Source = new BitmapImage(uri);
                image.Margin = new Thickness(10);
                MenMain.Children.Add(image);
            }
            List<Uri> imewo = await LoadPage.LoadImage(WomansClothing);
            foreach (Uri uri in imewo)
            {
                Image image = new Image();
                image.Width = 150;
                image.Height = 150;
                image.Source = new BitmapImage(uri);
                image.Margin = new Thickness(10);
                WomenMain.Children.Add(image);
            }
        }



        private void GoCatalog(object sender, RoutedEventArgs e)
        {
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = true;
            JeweleryPage.IsSelected = false;
            MensPage.IsSelected = false;
            WomensPage.IsSelected = false;
        }

        private void GoMainPage(object sender, RoutedEventArgs e)
        {
            MainLogic.Visibility = Visibility.Visible;
            MainSearch.Visibility = Visibility.Collapsed;
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = true;
            CatalogPage.IsSelected = false;
            JeweleryPage.IsSelected = false;
            MensPage.IsSelected = false;
            WomensPage.IsSelected = false;
        }
        private async void ElectronicPage(object sender, RoutedEventArgs e)
        {

            ElectronicsPage.IsSelected = true;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = false;
            JeweleryPage.IsSelected = false;
            MensPage.IsSelected = false;
            WomensPage.IsSelected = false;
            Electronics.Children.Clear();
            for (int i = 0; i < elecronics.Count; i++)
            {
                Electronics.Children.Add(LoadPage.LoadProductButton(elecronics[i]));
            }
        }
        private void GoJeweleryPage(object sender, RoutedEventArgs e)
        {
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = false;
            JeweleryPage.IsSelected = true;
            MensPage.IsSelected = false;
            WomensPage.IsSelected = false;
            Jewelerys.Children.Clear();
            for (int i = 0; i < jewelery.Count; i++)
            {
                Jewelerys.Children.Add(LoadPage.LoadProductButton(jewelery[i]));
            }
        }
        private void GoMensPage(object sender, RoutedEventArgs e)
        {
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = false;
            JeweleryPage.IsSelected = false;
            MensPage.IsSelected = true;
            WomensPage.IsSelected = false;
            Mens.Children.Clear();
            for (int i = 0; i < mensClothing.Count; i++)
            {
                Mens.Children.Add(LoadPage.LoadProductButton(mensClothing[i]));
            }
        }
        private void GoWomenPage(object sender, RoutedEventArgs e)
        {
          
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = false;
            JeweleryPage.IsSelected = false;
            MensPage.IsSelected = false;
            WomensPage.IsSelected = true;
            Womens.Children.Clear();
            for (int i = 0; i < WomansClothing.Count; i++)
            {
                Womens.Children.Add(LoadPage.LoadProductButton(WomansClothing[i]));
            }
        }

        private async void StartSearch(object sender, RoutedEventArgs e)
        {  
            if (Search.Text != "")
            {
                MainLogic.Visibility = Visibility.Collapsed;
                MainSearch.Visibility = Visibility.Visible;
                MainSearch.Children.Clear();
                List<Product> products = await ProductProcessor.FromTitle(Search.Text);
                if (products.Count!=0)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        MainSearch.Children.Add(LoadPage.LoadProductButton(products[i]));
                    }
                }
                else
                {
                    Label label= new Label();
                    label.FontSize = 40;
                    label.Background = Brushes.DarkGray;
                    label.Content = "Ничего не нашлось.  :(";
                    MainSearch.Children.Add(label);
                }
            }
        }
    }
}
