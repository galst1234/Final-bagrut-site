using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateItemV2 : System.Web.UI.Page
{
    public string makat;
    public string name;
    public string quantity;
    public string price;
    public string picturename;

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
        makat = (string)Session["makat"];
        name = (string)Session["name"];
        quantity = Session["quantity"].ToString();
        price = Session["price"].ToString();
        picturename = (string)Session["picturename"];
        string sqlsentence;
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        if (Request["sub"] != null)
        {
            sqlsentence = "update products set makat='" + Request["makat"] + "', name='" + Request["name"] + "', quantity='" + Request["quantity"] + "', price='" + Request["price"] + "', picturename='" + Request["picturename"] + "' where makat='" + makat + "'";
            connection.Update(sqlsentence);
            Response.Redirect("AdminUpdate.aspx");
        }
    }
}