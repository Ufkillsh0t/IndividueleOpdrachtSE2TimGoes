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

        private string[] child = new string[5] { "ChildChild1", "ChildChild2", "ChildChild3", "ChildChild4", "ChildChild5" };
        protected void Page_Load(object sender, EventArgs e)
        {
            Main = new MenuItem("Main");
            Child1 = new MenuItem("Child");
            Child2 = new MenuItem("Child");

            Child1 = ChildChilds(Child1);
            Child2 = ChildChilds(Child2);

            Main.ChildItems.Add(Child1);
            Main.ChildItems.Add(Child2);

            ProductCatMenu.Items.Add(Main);
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