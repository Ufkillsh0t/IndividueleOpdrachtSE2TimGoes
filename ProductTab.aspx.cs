using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private MenuItem Main;
        private MenuItem Child1;
        private MenuItem Child2;

        private List<Categorie> hoofdCategorieen;
        private List<MenuItem> hoofdMenuItems;


        private string[] child = new string[5] { "ChildChild1", "ChildChild2", "ChildChild3", "ChildChild4", "ChildChild5" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hoofdCategorieen = VerkrijgHoofdCats();
                VulHoofdMenuItems();

                Main = new MenuItem("Main");
                Child1 = new MenuItem("Child");
                Child2 = new MenuItem("Child");

                Child1 = ChildChilds(Child1);
                Child2 = ChildChilds(Child2);

                Main.ChildItems.Add(Child1);
                Main.ChildItems.Add(Child2);

                ProductCatMenu.Items.Add(Main);
                ProductCatMenu.Items.Add(new MenuItem("Main1"));
                ProductCatMenu.Items.Add(new MenuItem("Main2"));

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
                        MenuItem menuCat = ChildsMenuItems(VerkrijgSubCats(c), new MenuItem(c.Naam));
                        hoofdMenuItems.Add(menuCat);
                    }
                }
            }
        }

        private MenuItem ChildsMenuItems(List<Categorie> cats, MenuItem menu)
        {
            foreach (Categorie c in cats)
            {
                menu.ChildItems.Add(new MenuItem(c.Naam));
            }
            return menu;
        }

        private List<Categorie> VerkrijgSubCats(Categorie cat)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgSubCategorieen(cat);
        }

        private List<Categorie> VerkrijgHoofdCats()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgHoofdCategorieen();
        }

        private MenuItem ChildChilds(MenuItem menuItem)
        {
            MenuItem UpdatedChilds = menuItem;
            foreach (string i in child)
            {
                UpdatedChilds.ChildItems.Add(new MenuItem(i));
            }
            return UpdatedChilds;
        }
    }
}