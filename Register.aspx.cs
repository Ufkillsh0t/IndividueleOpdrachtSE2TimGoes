using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected LoginSysteem Login;

        protected void Page_Load(object sender, EventArgs e)
        {
            Login = new LoginSysteem();
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            if (Login.Registreer(tbUserName.Text, Login.getHashSha256(tbPassword.Text), tbEmail.Text))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Write("Registratie is mislukt!");
            }
        }
    }
}