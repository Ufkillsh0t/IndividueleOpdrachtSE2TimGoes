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

        /// <summary>
        /// Zorgt er voor dat een gebruiker wordt ingelogt.
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool Login(string gebruikersnaam, string wachtwoord)
        {
            return true;
        }

        /// <summary>
        /// Logt een gebruiker uit de website.
        /// </summary>
        /// <param name="gebruiker"></param>
        /// <returns></returns>
        public bool Loguit(Gebruiker gebruiker)
        {
            return true;
        }

        /// <summary>
        /// Registreert een nieuwe gebruiker in de database m.b.v de DatabaseManager klasse.
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <param name="wachtwoord"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool Registreer(string gebruikersnaam, string wachtwoord, string email)
        {
            DatabaseManager dm = new DatabaseManager();
            if (dm.RegistreerGebruiker(gebruikersnaam, wachtwoord, email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}