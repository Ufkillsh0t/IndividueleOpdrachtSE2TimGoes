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
                    Session["New"] = tbInlogGebruikersnaam.Text;
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