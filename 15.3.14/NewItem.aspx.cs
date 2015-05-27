using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewItemV2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userinfo"] == null)
        {
            Response.Redirect(Session["lastvisit"].ToString());
        }
        if (Session["userinfo"].ToString() != "admin")
        {
            Response.Redirect(Session["lastvisit"].ToString());
        }
        string makatexistencechecksentence;
        string sqlsentence;
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        if (Request["sub"] != null)
        {
            makatexistencechecksentence = "Select * from products where makat='" + Request["makat"] + "'";
            if (connection.CheckExistance(makatexistencechecksentence))
            {
                usedMakat.Text = "This makat is already taken, please try another one.";
            }
            else
            {
                sqlsentence = "insert into products (makat,name,quantity,price,picturename) values ('" + Request["makat"] + "','" + Request["name"] + "','" + Request["quantity"] + "','" + Request["price"] + "','" + Request["picturename"] + "')";
                connection.Insert(sqlsentence);
                Response.Redirect("AdminUpdate.aspx");
            }
        }
    }
}