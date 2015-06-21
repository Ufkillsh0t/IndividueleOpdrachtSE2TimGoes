using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private Product prod;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductSpecificaties.InnerHtml = "<H2>Test</H2>";

            string productID = Request.QueryString["id"];
            prod = VerkijgProduct(Convert.ToInt32(productID));
        }

        private Product VerkijgProduct(int productID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProduct(productID);
        }
    }
}