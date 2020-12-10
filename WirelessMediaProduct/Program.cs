using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WirelessMediaProduct
{
    public class Program
    {
        private string jsonFile = @"C:\Users\Iv\source\repos\WirelessMediaTest\WirelessMediaProductTest\WirelessMediaProduct\wwwroot\lib\ProductJson\product.json";
        private void CreateNew()
        {
            Console.WriteLine("Unesi id proizvoda : ");
            var id = Console.ReadLine();
            Console.WriteLine("\nUnesi naziv proizvoda : ");
            var name = Console.ReadLine();

            var noviProizvod = "{ 'id': " + id + ", 'name': '" + name + "'}";
            try
            {
                var json = File.ReadAllText(jsonFile);
                var jsonObj = JObject.Parse(json);
                var experienceArrary = jsonObj.GetValue("experiences") as JArray;
                var newCompany = JObject.Parse(noviProizvod);
                experienceArrary.Add(newCompany);

                jsonObj["experiences"] = experienceArrary;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
