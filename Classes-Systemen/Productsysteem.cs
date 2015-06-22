using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Productsysteem
    {
        public Productsysteem()
        {

        }

        public Productgroep VerkrijgProductGroep(int ProductGroepID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProductGroep(ProductGroepID);
        }

        public List<Product> VerkrijgProducten(int ProductGroepID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VekrijgProducten(ProductGroepID);
        }

        public Product VerkijgProduct(int productID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProduct(productID);
        }

        public List<ProductShop> VerkrijgProductShops(Product p)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProductShops(p);
        }

        public List<Productgroep> VerkrijgProductGroepen(Categorie cat)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProductGroepen(cat);
        }

        public List<Categorie> VerkrijgSubCats(Categorie cat)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgSubCategorieen(cat);
        }

        public List<Categorie> VerkrijgHoofdCats()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgHoofdCategorieen();
        }

        public List<Specificatiesoort> VerkrijgSpecificatieSoorten(Product prod)
        {
            List<Specificatiesoort> specSoort = new List<Specificatiesoort>();

            foreach (Specificatie s in prod.Specificaties)
            {
                bool found = false;
                foreach (Specificatiesoort ss in specSoort)
                {
                    if (ss.Naam == s.SpecificatieSoort.Naam)
                    {
                        found = true;
                    }
                }

                if (!found) specSoort.Add(s.SpecificatieSoort);
            }
            return specSoort;
        }
    }
}