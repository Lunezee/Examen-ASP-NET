using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationExam
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            // Déconnecter l'utilisateur en effaçant la session
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }


    }
}