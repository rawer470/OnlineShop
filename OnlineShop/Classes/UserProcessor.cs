using Newtonsoft.Json;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Classes
{
    public class UserProcessor
    {
        private static HttpClient client = new HttpClient();
        public static async Task<User[]> GetAllUsersAsync()
        {
            string url = $"https://fakestoreapi.com/users";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
                User[] users = JsonConvert.DeserializeObject<User[]>(responceString);
                return users;
            }
        }
        public static async Task<User> GetFromId(int id)
        {
            string url = $"https://fakestoreapi.com/users/{id}";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(responceString);
                return user;
            }
        }
    }
}
