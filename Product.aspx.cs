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
            string productID = Request.QueryString["id"];
            if (productID != null)
            {
                prod = VerkijgProduct(Convert.ToInt32(productID));
                ProductTabs.InnerHtml = "<a href=\"ProductTab.aspx\">ProductTab</a>" + "<a href=\"ProductGroep.aspx?id=" + prod.ProductGroep.ID.ToString() + "\" style=\"margin-left:20px;\">" + prod.ProductGroep.Naam + "</a>";
                if (prod.Specificaties != null && prod.Specificaties.Count != 0)
                {
                    ProductSpecificaties.InnerHtml = "<H2>Test</H2><BR /> <B>" + prod.Specificaties[0].Naam.ToString();
                }
            }
            else
            {
                ProductTabs.InnerHtml = "<a href=\"ProductTab.aspx\">ProductTab</a>";
            }
        }

        private Product VerkijgProduct(int productID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProduct(productID);
        }
    }
}