using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WirelessMediaProduct.Models
{
    public class ProductData
    {
        public int id { get; set; }
        public string naziv { get; set; }

        public string opis { get; set; }


        public string kategorija { get; set; }
        public string proizvodjac { get; set; }
        public string dobavljac { get; set; }
        public int cena { get; set; }
    }
}
