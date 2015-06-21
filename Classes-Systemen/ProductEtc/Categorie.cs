using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Categorie
    {
        public int ID { get; set; }

        public Categorie HoofdCategorie { get; set; }

        public string Naam { get; set; }

        public Categorie(int id, string naam)
        {
            this.ID = id;
            this.Naam = naam;
        }

        public Categorie(int id, Categorie hoofdCategorie, string naam)
        {
            this.ID = id;
            this.HoofdCategorie = hoofdCategorie;
            this.Naam = naam;
        }
    }
}