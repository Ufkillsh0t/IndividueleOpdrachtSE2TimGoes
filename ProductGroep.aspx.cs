using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        private Productgroep huidigProductGroep;
        private List<Product> producten;

        protected void Page_Load(object sender, EventArgs e)
        {
            string productGroepID = Request.QueryString["id"];
            huidigProductGroep = VerkrijgProductGroep(Convert.ToInt32(productGroepID));

            if (huidigProductGroep != null)
            {
                lblProductGroepNaam.Text = "<H2>" + huidigProductGroep.Naam + "</H2>";
                producten = VerkrijgProducten(huidigProductGroep.ID);
                if (producten != null)
                {
                    lvwProducten.DataSource = producten;
                    lvwProducten.DataBind();
                }
                else
                {
                    Response.Write("Geen producten voor de gegeven categorie gevonden!");
                }

            }
            else
            {
                lblProductGroepNaam.Text = "<H2>U heeft geen productgroep geselecteerd! Ga terug naar het productgroep tab en selecteer een productgroep!</H2>";
            }
        }

        private Productgroep VerkrijgProductGroep(int ProductGroepID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProductGroep(ProductGroepID);
        }

        private List<Product> VerkrijgProducten(int ProductGroepID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VekrijgProducten(ProductGroepID);
        }
    }
}