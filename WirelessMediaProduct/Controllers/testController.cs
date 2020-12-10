using System.Net;
using System.Linq;
using System.Threading.Tasks;
using WirelessMediaProduct.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace WirelessMediaProduct.Controllers

{
    public class testController:Controller
    {
        
        public IActionResult Index()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\Iv\source\repos\WirelessMediaTest\WirelessMediaProductTest\WirelessMediaProduct\wwwroot\lib\ProductJson\product.json");
            var products = JsonConvert.DeserializeObject<Products>(json);
            return View(products);
        }



    }
}
