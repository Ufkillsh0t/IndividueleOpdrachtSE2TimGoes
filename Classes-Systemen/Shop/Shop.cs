using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Shop
    {
        public int ShopNR { get; set; }

        public string Naam { get; set; }

        public string Website { get; set; }

        public string Adress { get; set; }

        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public int KVK { get; set; }

        public int Rating { get; set; }

        public string AlgemeenEmail { get; set; }

        public string AlgemeenTelefoonNR { get; set; }

        public string Logo { get; set; }

        public List<Afhaalpunt> Afhaalpunten { get; set; }

        public Shop(int shopNR, string naam, int rating)
        {
            this.ShopNR = shopNR;
            this.Naam = naam;
            this.Rating = rating;
        }

        public Shop(string website, string naam, int rating, int shopNR)
        {
            this.Website = website;
            this.Naam = naam;
            this.Rating = rating;
            this.ShopNR = shopNR;
        }

        public Shop(int nr, string naam, string website, string adress, string postcode, string plaats, int kvk, int rating, string algemeenEmail, string algemeenTelefoonNR, string logo, List<Afhaalpunt> afhaalpunten)
        {
            this.ShopNR = nr;
            this.Naam = naam;
            this.Website = website;
            this.Adress = adress;
            this.Postcode = postcode;
            this.Plaats = plaats;
            this.KVK = kvk;
            this.Rating = rating;
            this.AlgemeenEmail = algemeenEmail;
            this.AlgemeenTelefoonNR = algemeenTelefoonNR;
            this.Logo = logo;
            this.Afhaalpunten = afhaalpunten;
        }
    }
}