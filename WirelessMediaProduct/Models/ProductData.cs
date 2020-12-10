using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WirelessMediaProduct.Models
{
    public class ProductData
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Morate upisati id proizvoda")]
        public int id { get; set; }

        [Display(Name ="Naziv prozivoda")]
        [Required(ErrorMessage ="Morate upisati naziv proizvoda")]
        public string naziv { get; set; }
        [Display(Name = "Opis prozivoda")]
        [Required(ErrorMessage = "Morate upisati opis proizvoda")]
        public string opis { get; set; }

        [Display(Name = "Kategorija proizvoda")]
        [Required(ErrorMessage = "Morate upisati kategoriju")]
        public string kategorija { get; set; }
        public string proizvodjac { get; set; }
        public string dobavljac { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Morate upisati cenu proizvoda")]
        public int cena { get; set; }
    }
}
