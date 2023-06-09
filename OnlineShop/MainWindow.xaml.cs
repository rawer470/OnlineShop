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
        }

       

        private void GoCatalog(object sender, RoutedEventArgs e)
        {
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = true;
        }

        private void GoMainPage(object sender, RoutedEventArgs e)
        {
            ElectronicsPage.IsSelected = false;
            MainPage.IsSelected = true;
            CatalogPage.IsSelected = false;
        }
        private async void ElectronicPage(object sender, RoutedEventArgs e)
        {
            ElectronicsPage.IsSelected = true;
            MainPage.IsSelected = false;
            CatalogPage.IsSelected = false;
            List<WrapPanel> prod = await LoadPage.LoadCategoryPage("electronics");
            Electronics.Children.Clear();
            for (int i = 0; i < prod.Count; i++)
            {
               
                Electronics.Children.Add(prod[i]);
            }
        }
    }
}
