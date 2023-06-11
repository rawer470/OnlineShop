using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Automation.Peers;

namespace OnlineShop.Classes
{
    public static class LoadPage
    {
        public static Button ObrazecProduct { get; set; }
        public static Button Korzina { get; set; }

        public static async Task<List<Uri>> LoadImage(List<Product> products)
        {
            List<Uri> ret = new List<Uri>();
            foreach (Product product in products)
            {
                Uri uri = new Uri(product.Image);
                ret.Add(uri);
            }
            return ret;
        }
       
        public static Button LoadProductButton(Product product)
        {

            StackPanel st = new StackPanel();
            st.Orientation = Orientation.Vertical;

            //Добавление изображения
            Image image = new Image();
            Uri uri = new Uri(product.Image);
            image.Source = new BitmapImage(uri);
            image.Width = 280;
            image.Height = 200;
            image.Margin = new Thickness(10);
            st.Children.Add(image);

            //Добавление Цены
            Label labelPrice = new Label();
            labelPrice.Content = $"{product.Price}$";
            labelPrice.FontSize = 25;
            st.Children.Add(labelPrice);

            //Добавление рейтинга
            Label labelRat = new Label();
            labelRat.Content = $"Рейтинг: {product.Rating.Rate}, отзывов: {product.Rating.Count}";
            labelRat.FontSize = 18;
            st.Children.Add(labelRat);

            //Добавление заголовка
            TextBlock labelTitle = new TextBlock();
            labelTitle.Text = product.Title;
            labelTitle.FontSize = 20;
            labelTitle.TextWrapping = TextWrapping.Wrap;
            st.Children.Add(labelTitle);

            //Добавление описания
            TextBlock labelDiscr = new TextBlock();
            if (product.Description.Length>90)
            {
                string Dis = $"{Microsoft.VisualBasic.Strings.Left(product.Description, 90)}...";
                labelDiscr.Text = Dis;
            }
            else
            {
                labelDiscr.Text = product.Description;
            }
            labelDiscr.FontSize = 16;
            labelDiscr.TextWrapping = TextWrapping.Wrap;
            st.Children.Add(labelDiscr);


            Button kor = new Button();
            kor.Content = Korzina.Content;
            kor.FontSize = Korzina.FontSize;
            kor.Width = Korzina.Width;
            kor.Height = Korzina.Height;
            kor.Background = Korzina.Background;
            st.Children.Add(kor);

            st.Width = 400;
            st.Height = 500;
            st.Margin = new Thickness(10);
            //wr.Children.Clear();
            Button button = new Button();
            button.Content = st;
            button.Width = 400;
            button.Height = 500;
            button.Margin = new Thickness(40);
            return button;
        }

        public static async Task<List<WrapPanel>> LoadCategoryPage(string category)
        {
            return null;
        }
    }
}
