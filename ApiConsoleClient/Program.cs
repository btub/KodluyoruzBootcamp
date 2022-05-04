using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace ApiConsoleClient
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7065/api/products");
            
            if(response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            }
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public double Discount { get; set; }
        public int Stock { get; set; }
    }
}
