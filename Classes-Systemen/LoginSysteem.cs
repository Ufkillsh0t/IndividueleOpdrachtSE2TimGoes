using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

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


        /// <summary>
        /// Verkrijgt de Sha256 hash van het ingevoerde wachtwoord.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text); //Slaat het text op als UTF-8 byte code.
            SHA256Managed hashstring = new SHA256Managed(); //Verkrijgen van de SHA256 hashstring.
            byte[] hash = hashstring.ComputeHash(bytes); //Berekent de hashwaarde voor de specifieke bytes reeks van de array bytes.
            string hashString = string.Empty;
            foreach (byte x in hash) //Doorloopt iedere byte in de array hash.
            {
                hashString += String.Format("{0:x2}", x); //De byte in hash wordt gedecodeerd naar dat specifieke format.
            }
            return hashString;
        }
    }
}