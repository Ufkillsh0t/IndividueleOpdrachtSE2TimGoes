using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Specificatiesoort
    {
        public int ID { get; set; }

        public Productgroep ProductGroep { get; set; }

        public string Naam { get; set; }

        public Specificatiesoort(int id, string naam)
        {
            this.ID = id;
            this.Naam = naam;
        }

        public Specificatiesoort(int id, Productgroep productGroep, string naam)
        {
            this.ID = id;
            this.ProductGroep = productGroep;
            this.Naam = naam;
        }
    }
}