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
        private ShopSysteem ss;

        protected void Page_Load(object sender, EventArgs e)
        {
            string nr = Request.QueryString["nr"];
            ss = new ShopSysteem();
            if (nr != null)
            {
                shop = ss.VerkrijgShop(Convert.ToInt32(nr));
                if (shop != null)
                {
                    GenereerAlgemeneShopInformatie();
                    GenereerAfhaalpuntInformatie();
                }
                else
                {
                    ShopInformatie.InnerHtml = "<H2>De gegeven shop bestaat niet, zoek naar een nieuwe in het shoptab!</H2>";
                }
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

        private void GenereerAfhaalpuntInformatie()
        {
            //AfhaalpuntInformatie
            if (shop.Afhaalpunten != null && shop.Afhaalpunten.Count != 0)
            {
                string innerHTML = "<h1>Afhaalpunten</h1><br /><div id=\"Afhaalpunten\" style=\"overflow:auto;\">";

                foreach (Afhaalpunt a in shop.Afhaalpunten)
                {
                    innerHTML = innerHTML + GenereerAfhaalpuntTabel(a) + "<br />";
                }

                AfhaalpuntInformatie.InnerHtml = innerHTML + "</div>";
            }
            else
            {
                AfhaalpuntInformatie.InnerHtml = "<B>Deze shop heeft op dit moment nog geen afhaalpunten!</B>";
            }
        }

        private string GenereerAfhaalpuntTabel(Afhaalpunt a)
        {
            string html = "<div id=\"Afhaalpunt" + a.ID + "\" style=\"border:1px solid #000000;border-radius:10px;width:900px;\">" + "<table>";

            //html voor kolombreedte van de tabel.
            html = html + "<colgroup><col style=\"width:200px;\"><col style=\"width:300px;\"><col style=\"width:200px;\"><col style=\"width:300px;\"></colgroup>";

            //tableheader met een breedte van de hele colspan.
            html = html + "<th colspan=\"4\">" + a.Plaats + " " + a.Adres + "</th>";

            html = html + "<tr><td>Straat HuisNR</td><td>" + a.Adres + "</td></tr>";
            html = html + "<tr><td>Postcode</td><td>" + a.Postcode + "</td></tr>";
            html = html + "<tr><td>Plaats</td><td>" + a.Plaats + "</td></tr>";
            html = html + "<tr><td>Email</td><td>" + a.Email + "</td></tr>";
            html = html + "<tr><td>TelefoonNR</td><td>" + a.TelefoonNR + "</td></tr></table><table>";

            html = html + "<colgroup><col style=\"width:200px;\"><col style=\"width:300px;\"><col style=\"width:200px;\"><col style=\"width:300px;\"></colgroup>";

            //tableheader met een breedte van de hele colspan.
            html = html + "<th colspan=\"4\">Openingstijden " + a.Plaats + " " + a.Adres + "</th>"; 
           
            foreach (Openingstijd o in a.Openingstijden)
            {
                html = html + "<tr><td>";
                html = html + o.Dag;
                html = html + "</td><td>";
                html = html + o.Open + " - " + o.Sluit;
                html = html + "</td></tr>";
            }

            html = html + "</table></div>"; //</td></tr>

            return html;
        }
    }
}