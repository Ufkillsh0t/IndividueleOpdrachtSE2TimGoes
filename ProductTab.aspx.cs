﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private List<Categorie> hoofdCategorieen;
        private List<MenuItem> hoofdMenuItems;
        private Productsysteem ps;

        private string[] child = new string[5] { "ChildChild1", "ChildChild2", "ChildChild3", "ChildChild4", "ChildChild5" };
        protected void Page_Load(object sender, EventArgs e)
        {
            ps = new Productsysteem();
            if (!IsPostBack)
            {
                hoofdCategorieen = ps.VerkrijgHoofdCats();
                VulHoofdMenuItems();

                foreach (MenuItem m in hoofdMenuItems)
                {
                    ProductCatMenu.Items.Add(m);
                }
            }
        }

        private void VulHoofdMenuItems()
        {
            hoofdMenuItems = new List<MenuItem>();
            if (hoofdCategorieen != null)
            {
                foreach (Categorie c in hoofdCategorieen)
                {
                    if (c != null)
                    {
                        MenuItem menuCat = ChildsMenuItems(ps.VerkrijgSubCats(c), new MenuItem(c.Naam));
                        hoofdMenuItems.Add(menuCat);
                    }
                }
            }
        }

        private MenuItem ChildsMenuItems(List<Categorie> cats, MenuItem menu)
        {
            foreach (Categorie c in cats)
            {
                MenuItem subCat = ProductGroepMenuItems(ps.VerkrijgProductGroepen(c), new MenuItem(c.Naam));
                menu.ChildItems.Add(subCat);
            }
            return menu;
        }

        private MenuItem ProductGroepMenuItems(List<Productgroep> producGroepen, MenuItem menu)
        {
            foreach (Productgroep p in producGroepen)
            {
                MenuItem productGroep = new MenuItem(p.Naam);
                productGroep.NavigateUrl = "ProductGroep.aspx?id=" + p.ID.ToString();
                menu.ChildItems.Add(productGroep);
            }
            return menu;
        }
    }
}