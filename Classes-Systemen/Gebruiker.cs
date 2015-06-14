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

        //Wachtwoord wordt geencrypt met SHA-256.
        public string Wachtwoord { get; set; }

        public Gebruiker(string naam, string email, string wachtwoord)
        {
            this.Wachtwoord = wachtwoord;
            this.Naam = naam;
            this.Email = email;
        }
    }
}