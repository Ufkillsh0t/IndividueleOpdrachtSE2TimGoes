using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Productgroep
    {
        public int ID { get; set; }

        public Categorie Categorie { get; set; }

        public string Naam { get; set; }

        public string Link { get; set; }

        public string Plaatje { get; set; }

        public List<Specificatiesoort> Specificatiesoorten { get; set; }

        public Productgroep(int id, Categorie categorie, string naam, string link, string plaatje, List<Specificatiesoort> specificatieSoorten)
        {
            this.ID = id;
            this.Categorie = categorie;
            this.Naam = naam;
            this.Link = link; 
            this.Plaatje = plaatje;
            this.Specificatiesoorten = specificatieSoorten;
        }

    }
}