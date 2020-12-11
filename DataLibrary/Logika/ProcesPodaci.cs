using DataLibrary.Models;
using DataLibrary.PristupPodacima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logika
{
    public static class ProcesPodaci
    {
        public static int NoviProizvod(int id, string naziv, string opis, string kategorija, string proizvodjac,
            string dobavljac, int cena)
        {
            ProductData data = new ProductData
            {
                Id = id,
                Naziv = naziv,
                Opis = opis,
                Kategorija = kategorija,
                Proizvodjac = proizvodjac,
                Dobavljac = dobavljac,
                Cena = cena
            };

            

            string sql = @"insert into dbo.Products(Id, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values(@Id, @Naziv, @Opis, @Kategorija, @Proizvodjac, @Dobavljac, @Cena);";
            return SqlPristupPodacima.SacuvajPodatke(sql, data);
        }

        public static List<ProductData> UcitajPodatke()
        {
            string sql = @"select Id, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena
from dbo.Products;";

            return SqlPristupPodacima.UcitajPodatke<ProductData>(sql);
        }
    }
}
