using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        private List<Shop> shops;

        protected void Page_Load(object sender, EventArgs e)
        {
            shops = VerkrijgAlleShops();

            if (shops != null && shops.Count != 0)
            {
                divShopInformatie.InnerHtml = "<h2>Gevonden shops</h2>";
                lvwShops.DataSource = shops;
                lvwShops.DataBind();
            }
            else
            {
                divShopInformatie.InnerHtml = "<h2>Er zijn geen shops gevonden! Probeer het overnieuw bij het shops tab!</h2>";
            }
        }

        private List<Shop> VerkrijgAlleShops()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAlleShops();
        }
    }
}