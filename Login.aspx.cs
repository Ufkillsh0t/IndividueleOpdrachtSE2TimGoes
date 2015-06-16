using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected LoginSysteem Login;

        protected void Page_Load(object sender, EventArgs e)
        {
            Login = new LoginSysteem();
            if (Session["Inlog"] != null)
            {
                Response.Redirect("Index.aspx");
                Response.Write("U bent al ingelogd, log eerst uit wil je opnieuw kunnen inloggen.");
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            string wachtwoordHash = dm.VerkrijgWachtwoord(tbInlogGebruikersnaam.Text);
            if (wachtwoordHash != null)
            {
                if (Login.getHashSha256(tbInlogWachtwoord.Text) != wachtwoordHash)
                {
                    lblLoginInfo.Text = "U heeft een verkeerd wachtwoord ingevoerd!";
                }
                else
                {
                    Session["Inlog"] = tbInlogGebruikersnaam.Text;
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                lblLoginInfo.Text = "U heeft een verkeerde gebruikersnaam ingevoerd!";
            }
        }
    }
}