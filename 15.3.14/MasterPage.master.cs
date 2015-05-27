using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userexists"] != null)
        {
            pagetitle.Text = "Hello " + Session["username"];
            if (Session["userinfo"].ToString() == "admin")
            {
                pagetitle.Text += ", to get to the admin page <a href='AdminUpdate.aspx'>click here</a>";
            }
            pagetitle.Text += "<br /> You have " + Session["itemsInCart"] + " items in your <a href='cart.aspx'>cart</a><br /><h2 style='text-align:right'><a href='SignIn.aspx' style='color:Red'>Log Out</a></h2>";
        }
        else
        {
            pagetitle.Text = "Hello guest. Please <a href='SignIn.aspx' style='color:White'>sign in</a> or <a href='SignUp.aspx' style='color:White'>sign up</a> if you don't have an account";
        }
    }
}
