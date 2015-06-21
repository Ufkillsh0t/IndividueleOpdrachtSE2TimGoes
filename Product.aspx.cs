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
        private List<Specificatiesoort> specificatieSoorten;
        private List<ProductShop> productShop;

        protected void Page_Load(object sender, EventArgs e)
        {
            string productID = Request.QueryString["id"];
            if (productID != null)
            {
                ProductSpecificaties.Visible = false;
                ProductPrijsShops.Visible = false;
                prod = VerkijgProduct(Convert.ToInt32(productID));
                productShop = VerkrijgProductShops(prod);
                ProductTabs.InnerHtml = "<a href=\"ProductTab.aspx\">ProductTab</a>" + "<a href=\"ProductGroep.aspx?id=" + prod.ProductGroep.ID.ToString() + "\" style=\"margin-left:20px;\">" + prod.ProductGroep.Naam + "</a>";
                GenereerAlgemeneProductInformatie();
                GenereerTabelSpecificaties();
                GenereerProductShopTabel();
            }
            else
            {
                ProductTabs.InnerHtml = "<a href=\"ProductTab.aspx\">ProductTab</a>";
                ProductInformatie.InnerHtml = "<h2>Er kon geen product worden gevonden!</h2>";
            }
        }

        protected void btnPrijzen_Click(object sender, EventArgs e)
        {
            ProductSpecificaties.Visible = false;
            ProductPrijsShops.Visible = true;
        }

        protected void btnSpecificaties_Click(object sender, EventArgs e)
        {
            ProductSpecificaties.Visible = true;
            ProductPrijsShops.Visible = false;
        }

        private Product VerkijgProduct(int productID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProduct(productID);
        }

        private List<ProductShop> VerkrijgProductShops(Product p)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProductShops(p);
        }

        private void GenereerProductShopTabel()
        {
            if (productShop != null && productShop.Count != 0)
            {
                ProductPrijsShops.InnerHtml = ProductShopTabel();
            }
            else
            {
                ProductPrijsShops.InnerHtml = "<B>Dit product wordt momenteel nergens aangeboden!</B>";
            }
        }

        private string ProductShopTabel()
        {
            string html = "<div id=\"ShopPrijzen\" style=\"border:1px solid #000000;border-radius:10px;width:600px;\">"; //div benaming en stijl
            html = html + "<colgroup><col style=\"width:300px;\"><col style=\"width:100px;\"><col style=\"width:200px;\"><col style=\"width:200px;\"><col style=\"width:200px;\"><col style=\"width:100px;\"></colgroup>"; //tabel breedte per kolom
            html = html + "<table><th colspan=\"6\">Prijzen/Shops</th>";
            html = html + "<tr><td style=\"width:300px;\">ShopNaam</td><td style=\"width:100px;\">Rating</td><td style=\"width:200px;\">Voorraad</td><td style=\"width:200px;\">Prijs</td><td style=\"width:200px;\">Prijs (inc Verzending)</td><td style=\"width:100px;\">ShopNR</td></tr>";

            foreach (ProductShop ps in productShop)
            {
                html = html + "<tr><td>" + ps.Shop.Naam + "</td>";
                html = html + "<td>" + ps.Shop.Rating + "</td>";
                html = html + "<td>" + ps.Voorraad + "</td>";
                html = html + "<td>" + ps.Prijs + "</td>";
                html = html + "<td>" + ps.TotaalPrijs + "</td>";
                html = html + "<td><a href=\"Shop.aspx?nr=" + ps.Shop.ShopNR + "\">" + ps.Shop.ShopNR +  "</a></td></tr>";
            }

            html = html + "</table></div>";

            return html;
        }

        private void GenereerAlgemeneProductInformatie()
        {
            string html = "<div id=\"ProductAlgemeen\" style=\"border:1px solid #000000;border-radius:10px;width:600px;\">"; //div benaming en stijl
            html = html + "<colgroup><col style=\"width:200px;\"><col style=\"width:400px;\"></colgroup>"; //tabel breedte per kolom
            html = html + "<table><th colspan=\"2\"><h2>ProductInformatie</h2></th>"; //breedte van de tabel header.
            html = html + "<tr><td style=\"width:200px;\">Merk</td><td style=\"width:400px;\">" + prod.Merk + "</td></tr>"; //product merk rij.
            html = html + "<tr><td>Productnaam</td><td>" + prod.Naam + "</td></tr>";
            html = html + "<tr><td>Productcode</td><td>" + prod.Code + "</td></tr>"; 
            html = html + "<tr><td>EAN code</td><td>" + prod.EANcode + "</td></tr>"; 
            html = html + "<tr><td>Getest op</td><td>" + prod.TestDatum.ToString() + "</td></tr>"; 
            html = html + "<tr><td>Fabrikant website</td><td><a href=\"" + prod.FabrikantSite + "\">" + prod.FabrikantSite + "</a></td></tr></table></div><br />"; //laatste rij

            ProductInformatie.InnerHtml = html;
        }

        private void GenereerTabelSpecificaties()
        {
            if (prod.Specificaties != null && prod.Specificaties.Count != 0)
            {
                specificatieSoorten = VerkrijgSpecificatieSoorten();

                string innerHTML = "<div id=\"ProductSpecificaties\" style=\"overflow:auto;\">";

                foreach (Specificatiesoort s in specificatieSoorten)
                {
                    innerHTML = innerHTML + SpecificatieSoortTabel(s) + "<br />";
                }

                ProductSpecificaties.InnerHtml = innerHTML + "</div>";
            }
            else
            {
                ProductSpecificaties.InnerHtml = "<B>Dit product heeft momenteel nog geen specificaties in de database staan!</B>";
            }
        }

        private string SpecificatieSoortTabel(Specificatiesoort specSoort)
        {
            string html = "<div id=\"" + specSoort.Naam + "\" style=\"border:1px solid #000000;border-radius:10px;width:900px;\">" + "<table>";

            //html voor kolombreedte van de tabel.
            html = html + "<colgroup><col style=\"width:200px;\"><col style=\"width:300px;\"><col style=\"width:400px;\"></colgroup>";

            //tableheader met een breedte van de hele colspan.
            html = html + "<th colspan=\"3\">" + specSoort.Naam + "</th>";

            //table rijen en kolommen met de specificataties
            foreach (Specificatie s in prod.Specificaties)
            {
                html = html + "<tr>";
                html = html + "<td>" + s.Naam + "</td>";
                html = html + "<td>" + s.Waarde +"</td>";
                html = html + "<td>";
                if (s.Omschrijving != null && s.Omschrijving != "")
                {
                    html = html + "<b>" + s.Naam + ":</b>" + s.Omschrijving;
                }
                html = html + "</td>";
                html = html + "</tr>";
            }
            html = html + "</table></div>";

            return html;
        }

        private string GenereerSpecificatieSoortString(string inner, List<Specificatiesoort> specSoort)
        {
            string generated = inner;
            foreach (Specificatiesoort s in specSoort)
            {
                generated = generated + "<br />" + "<B>" + s.Naam + "</B>";
            }
            return generated;
        }

        private List<Specificatiesoort> VerkrijgSpecificatieSoorten()
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