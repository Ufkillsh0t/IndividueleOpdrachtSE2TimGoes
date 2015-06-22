using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //protected LoginSysteem login;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Inlog"] != null)
            {
                btLogInUit.Text = "Loguit";
                lblGebruikersnaam.Text = Session["Inlog"].ToString();
            }
            else
            {
                btLogInUit.Text = "Login";
                lblGebruikersnaam.Text = "";
            }
        }

        protected void btLogInUit_Click(object sender, EventArgs e)
        {
            if (Session["Inlog"] != null)
            {
                Session["Inlog"] = null;
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btZoek_Click(object sender, EventArgs e)
        {
            if (tbZoekBalk.Text != "")
            {
                Response.Redirect("Zoek.aspx?zoek=" + tbZoekBalk.Text);
            }
        }
    }
}