using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private Shop shop;
        protected void Page_Load(object sender, EventArgs e)
        {
            string nr = Request.QueryString["nr"];
            if (nr != null)
            {
                shop = VerkrijgShop(Convert.ToInt32(nr));
                GenereerAlgemeneShopInformatie();
            }
            else
            {
                ShopInformatie.InnerHtml = "<H2>U heeft geen shop ingevult, ga terug naar het shoptab om een shop te selecteren!</H2>";
            }
        }

        private void GenereerAlgemeneShopInformatie()
        {
            string html = "<div id=\"ShopAlgemeen\" style=\"border:1px solid #000000;border-radius:10px;width:600px;\">"; //div benaming en stijl
            html = html + "<colgroup><col style=\"width:200px;\"><col style=\"width:400px;\"></colgroup>"; //tabel breedte per kolom
            html = html + "<table><th colspan=\"2\"><h2>ShopInformatie</h2></th>"; //breedte van de tabel header.
            html = html + "<tr><td style=\"width:200px;\">Bedrijfsnaam</td><td style=\"width:400px;\">" + shop.Naam + "</td></tr>"; //product merk rij.
            html = html + "<tr><td>KvK nummer</td><td>" + shop.KVK + "</td></tr>";
            html = html + "<tr><td>Straat</td><td>" + shop.Adress + "</td></tr>";
            html = html + "<tr><td>Postcode</td><td>" + shop.Postcode + "</td></tr>";
            html = html + "<tr><td>Plaats</td><td>" + shop.Plaats + "</td></tr>";
            html = html + "<tr><td>Algemeen e-mailadres</td><td>" + shop.AlgemeenEmail + "</td></tr>";
            html = html + "<tr><td>Algemeen telefoonnummer</td><td>" + shop.AlgemeenTelefoonNR + "</td></tr>";
            html = html + "<tr><td>Website</td><td><a href=\"" + shop.Website + "\">" + shop.Website + "</a></td></tr></table></div><br />"; //laatste rij

            ShopInformatie.InnerHtml = html;
        }

        private Shop VerkrijgShop(int shopNR)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgShop(shopNR);
        }
    }
}