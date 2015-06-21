using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Afhaalpunt
    {
        public int ID { get; set; }

        public Shop Shop { get; set; }

        public string Adres { get; set; }

        public string Postcode { get; set; }

        public string TelefoonNR { get; set; }

        public string Email { get; set; }

        public List<Openingstijd> Openingstijden { get; set; }

        public Afhaalpunt(int id, string adres, string postcode, string telefoonNR, string email)
        {
            this.ID = id;
            this.Adres = adres;
            this.Postcode = postcode;
            this.TelefoonNR = telefoonNR;
            this.Email = email;
        }
    }
}