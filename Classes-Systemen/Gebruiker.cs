using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Gebruiker
    {
        public string Naam { get; set; }

        public string Email { get; set; }

        public DateTime RegistratieDatum { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public string Website { get; set; }

        public string Woonplaats { get; set; }

        public string Beroep { get; set; }

        public bool Verbannen { get; set; }

        public Gebruiker(string naam, string email)
        {
            this.Naam = naam;
            this.Email = email;
        }

        public Gebruiker(string naam, string email, DateTime registratieDatum, DateTime geboorteDatum, string website, string woonplaats, string beroep, bool verbannen)
        {
            this.Naam = naam;
            this.Email = email;
            this.RegistratieDatum = registratieDatum;
            this.GeboorteDatum = geboorteDatum;
            this.Website = website;
            this.Woonplaats = woonplaats;
            this.Beroep = beroep;
            this.Verbannen = verbannen;
        }
    }
}