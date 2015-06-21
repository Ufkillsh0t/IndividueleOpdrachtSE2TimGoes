using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Openingstijd
    {
        public int ID { get; set; }

        public string Dag { get; set; }

        public string Open { get; set; }

        public string Sluit { get; set; }

        public Openingstijd(int id, string dag, string openingstijd, string sluitingstijd){
            this.ID = id;
            this.Dag = dag;
            this.Open = openingstijd;
            this.Sluit = sluitingstijd;
        }
    }
}