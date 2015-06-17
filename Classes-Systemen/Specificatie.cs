using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Specificatie
    {
        public int ID { get; set; }

        public Specificatiesoort SpecificatieSoort { get; set; }

        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        public string Waarde { get; set; }

        public Product Product { get; set; }

        public Specificatie(int id, Specificatiesoort specificatieSoort, string naam, string omschrijving, string waarde, Product product)
        {
            this.ID = id;
            this.SpecificatieSoort = specificatieSoort;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Waarde = waarde;
            this.Product = product;
        }
    }
}