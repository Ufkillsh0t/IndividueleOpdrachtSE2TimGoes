using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class ProductShop
    {
        public Product Product { get; set; }

        public string Voorraad { get; set; }

        public Shop Shop { get; set; }

        public int Prijs { get; set; }

        public int TotaalPrijs { get; set; }

        public ProductShop(Product product, string voorraad, Shop shop, int prijs, int totaalPrijs)
        {
            this.Product = product;
            this.Voorraad = voorraad;
            this.Shop = shop;
            this.Prijs = prijs;
            this.TotaalPrijs = totaalPrijs;
        }
    }
}