using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cart : System.Web.UI.Page
{
    public string fname;
    public string lname;
    public string phone;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userinfo"] == null)
        {
            Response.Redirect(Session["lastvisit"].ToString());
        }
        fname = Session["fname"].ToString();
        lname = Session["lname"].ToString();
        phone = Session["phnum"].ToString();
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        if (Request["clear"] != null)
        {
            connection.Update("Update shoolhan set price='0', itemsInCart='0', itemsNames=NULL Where ID='" + Session["id"] + "'");
            Session["itemsInCart"] = 0;
            Response.Redirect("cart.aspx");
        }
        string SQLSentence = "Select * from shoolhan where ID='" + Session["id"] + "'";
        DataSet ds = connection.GetData(SQLSentence);
        string itemsincart;
        int lastidexof = -1;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            if (int.Parse(row["itemsInCart"].ToString()) > 0)
            {
                itemsincart = row["itemsNames"].ToString();
                lastidexof = itemsincart.LastIndexOf(",");
                //itemsincart = itemsincart.Remove(lastidexof);
                itemsincart = itemsincart.Remove(lastidexof) + ".";
                showcart.Text = "You have " + row["itemsInCart"] + " items in your cart, with a total cost of " + row["price"] + "₪.<br />The items are: " + itemsincart + "<br />To purchase them please fill the next form.";
            }
        }
        if (Request["sub"] != null)
        {
            connection.Update("Update shoolhan set price='0', itemsInCart='0', itemsNames=NULL Where ID='" + Session["id"] + "'");
            Session["itemsInCart"] = 0;
            Response.Redirect("cart.aspx");
        }
    }
}