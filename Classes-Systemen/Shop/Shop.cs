using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Shop
    {
        public int ShopNR { get; set; }

        public int Rating { get; set; }

        public string KVK { get; set; }

        public string Naam { get; set; }

        public List<Afhaalpunt> afhaalpunten { get; set; }

        public Shop(int shopNR, string naam, int rating)
        {
            this.ShopNR = shopNR;
            this.Naam = naam;
            this.Rating = rating;
        }

        public Shop(int shopNR, string kvk, string naam, int rating)
        {
            this.ShopNR = shopNR;
            this.KVK = kvk;
            this.Naam = naam;
            this.Rating = rating;
        }
    }
}