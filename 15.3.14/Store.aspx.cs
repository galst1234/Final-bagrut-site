using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pagebody.Text = "";
        Session["lastvisit"] = "Store.aspx";
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        string SQLSentence;
        DataSet ds;
        string currentitems = "";
        int currentitemsnum = 0, currentprice = 0;
        string SQLSentenceProducts = "Select * from products";
        DataSet products = connection.GetData(SQLSentenceProducts);
        string sqlpurchase = "Select * from products where ";
        pagebody.Text += "<table cellspacing='1px'>";
        string updateusers, updateproducts;
        foreach (DataRow row in products.Tables[0].Rows)
        {
            gametobuy.Items.Add(new ListItem(row["name"].ToString(), row["makat"].ToString()));
            pagebody.Text += "<tr><td><img src='Pictures/" + row["picturename"] + "' height='180' width='127'/></td><td>" + row["name"] + "<br />" + row["quantity"] + " copies left</td><td>" + row["price"] + "₪</td></tr>";
        }
        pagebody.Text += "</table>";

        if (Request["addtocart"] != null)
        {
            if (Request["gamequantity"].ToString() != "")
            {
                bool isint = true;
                for (int i = 0; i < Request["gamequantity"].ToString().Length; i++)
                {
                    if ((char)Request["gamequantity"].ToString()[i] < '0' || (char)Request["gamequantity"].ToString()[i] > '9')
                    {
                        isint = false;
                    }
                }
                if (isint)
                {
                    if (Session["userexists"] != null)
                    {
                        SQLSentence = "Select * from shoolhan where UserName='" + Session["username"] + "'";
                        ds = connection.GetData(SQLSentence);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            currentprice = int.Parse(row["price"].ToString());
                            currentitems = row["ItemsNames"].ToString();
                            currentitemsnum = int.Parse(row["itemsInCart"].ToString());
                        }

                        sqlpurchase += "makat='" + gametobuy.SelectedValue + "'";
                        products = connection.GetData(sqlpurchase);

                        foreach (DataRow row in products.Tables[0].Rows)
                        {
                            int currentquantity = int.Parse(row["quantity"].ToString());
                            if (int.Parse(Request["gamequantity"].ToString()) > int.Parse(row["quantity"].ToString()) || int.Parse(Request["gamequantity"].ToString()) < 1)
                            {
                                purchaseerror.Text = "You cant buy this amount of copies of this game.";
                            }
                            else
                            {
                                Session["payprice"] = currentprice + int.Parse(Request["gamequantity"].ToString()) * int.Parse(row["price"].ToString());
                                Session["itemsInCart"] = currentitemsnum + int.Parse(Request["gamequantity"].ToString());
                                Session["itemNames"] = currentitems + row["name"] + " x" + Request["gamequantity"] + ", ";
                                updateusers = "Update shoolhan set price='" + Session["payprice"] + "', itemsInCart='" + Session["itemsInCart"] + "', itemsNames='" + Session["itemNames"] + "' where UserName='" + Session["username"] + "'";
                                updateproducts = "Update products set quantity='" + (int)(currentquantity - int.Parse(Request["gamequantity"].ToString())) + "' where makat='" + gametobuy.SelectedValue + "'";
                                connection.Update(updateusers);
                                connection.Update(updateproducts);
                                Response.Redirect("Store.aspx");
                            }
                        }
                    }
                    else
                    {
                        purchaseerror.Text = "To purchase a game please log in.";
                    }
                }
                else
                {
                    purchaseerror.Text = "Please enter a number.";
                }
            }
            else
            {
                purchaseerror.Text = "Please enter a number.";
            }
        }
    }
}