using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Afhaalpunt
    {
        public int ID { get; set; }

        public string Adres { get; set; }

        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public string TelefoonNR { get; set; }

        public string Email { get; set; }

        public List<Openingstijd> Openingstijden { get; set; }

        public Afhaalpunt(int id, string adres, string postcode, string plaats, string telefoonNR, string email, List<Openingstijd> openingstijden)
        {
            this.ID = id;
            this.Adres = adres;
            this.Postcode = postcode;
            this.Plaats = plaats;
            this.TelefoonNR = telefoonNR;
            this.Email = email;
            this.Openingstijden = openingstijden;
        }
    }
}