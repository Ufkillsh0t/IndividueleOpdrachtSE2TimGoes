using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Zoeksysteem
    {
        public Zoeksysteem()
        {

        }
        public List<Product> VerkrijgProducten(string zoekString)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProducten(zoekString);
        }

        public List<Shop> VerkrijgShops(string zoekString)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgShops(zoekString);
        }
    }
}