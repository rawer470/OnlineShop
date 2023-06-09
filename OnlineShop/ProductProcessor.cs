using Newtonsoft.Json;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public static class ProductProcessor
    {
        private static HttpClient client = new HttpClient();
        public static async Task<Product[]> GetAllProductAsync()
        {
            string url = $"https://fakestoreapi.com/products";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
                Product[] product = JsonConvert.DeserializeObject<Product[]>(responceString);
                return product;
            }
        }
        public static async Task<Product> GetFromId(int id)
        {
            string url = $"https://fakestoreapi.com/products/{id}";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
                Product product = JsonConvert.DeserializeObject<Product>(responceString);
                return product;
            }
        }
        public static async Task<List<Product>> FromTitle(string title)
        {
            Product[] products = await GetAllProductAsync();
            List<Product> needprod = new List<Product>();
            foreach (var item in products)
            {
                if (item.Title == title)
                {
                    needprod.Add(item);
                }
            }
            return needprod;
        }
        public static async Task<List<Product>> GetFromCategory(string category)
        {
            string url = $"https://fakestoreapi.com/products/category/{category}";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
               Product[] product = JsonConvert.DeserializeObject<Product[]>(responceString);
                return product.ToList<Product>();
            }
        }
    }
}
