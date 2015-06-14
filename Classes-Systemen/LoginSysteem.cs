using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class LoginSysteem
    {
        public Gebruiker Gebruiker { get; set; }

        public LoginSysteem()
        {

        }

        public bool Login(string gebruikersnaam, string wachtwoord)
        {
            return true;
        }

        public bool Loguit(Gebruiker gebruiker)
        {
            return true;
        }

        public bool Registreer(string gebruikersnaam, string wachtwoord, string email)
        {

        }
    }
}