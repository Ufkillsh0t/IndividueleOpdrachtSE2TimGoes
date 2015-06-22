using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class ShopSysteem
    {
        public ShopSysteem()
        {

        }

        public Shop VerkrijgShop(int shopNR)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgShop(shopNR);
        }

        public List<Shop> VerkrijgAlleShops()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAlleShops();
        }
    }
}