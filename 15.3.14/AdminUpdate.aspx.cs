using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminUpdateV2 : System.Web.UI.Page
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
        //משתמשים
        pagebody.Text = "";
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        string id = Request["ID"];
        string SQLSentence = "Select * from shoolhan where ID='" + id + "'";
        DataSet ds = connection.GetData(SQLSentence);
        if (Request["sub"] != null)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Session["idtoupdate"] = row["ID"];
                Session["fnametoupdate"] = row["fname"].ToString();
                Session["lnametoupdate"] = row["lname"].ToString();
                Session["emailtoupdate"] = row["email"].ToString();
                Session["phnumtoupdate"] = row["phone_number"].ToString();
                Session["userinfotoupdate"] = row["userinfo"].ToString();
                Session["usernametoupdate"] = row["UserName"].ToString();
                Session["passwordtoupdate"] = row["PassWord"].ToString();
                Response.Redirect("UserUpdateInf.aspx");
            }
        }
        string SQLSentenceGetFullTable = "Select * from shoolhan";
        DataSet fulltable = connection.GetData(SQLSentenceGetFullTable);
        pagebody.Text += "<table border='5' bordercolor='red' style='border-radius:10px' cellspacing='5px'><tr><td>id</td><td>first name</td><td>last name</td><td>email</td><td>phone number</td><td>user info</td><td>username</td><td>password</td><td>items in cart</td><td>price</td></tr>";
        //Response.Write("<table border='1'><tr><td>id</td><td>first name</td><td>last name</td><td>email</td><td>phone number</td><td>user info</td></tr>");
        foreach (DataRow row in fulltable.Tables[0].Rows)
        {
            pagebody.Text += "<tr><td>" + row["id"] + "</td><td>" + row["fname"] + "</td><td>" + row["lname"] + "</td><td>" + row["email"] + "</td><td>" + row["phone_number"] + "</td><td>" + row["userinfo"] + "<td>" + row["username"] + "</td><td>" + row["password"] + "</td><td>"+row["itemsInCart"]+"</td><td>"+row["price"]+"₪</td></tr>";
            //Response.Write("<tr><td>" + row["id"] + "</td><td>" + row["fname"] + "</td><td>" + row["lname"] + "</td><td>" + row["email"] + "</td><td>" + row["phone_number"] + "</td><td>" + row["userinfo"] + "</tr>");
        }
        pagebody.Text += "</table><br />";
        //Response.Write("</table>");
        string SQLSentenceDeleteRow = "Delete * from shoolhan where id='" + id + "'";
        if (Request["delete"] != null)
        {
            connection.Update(SQLSentenceDeleteRow);
            Response.Redirect("AdminUpdate.aspx");
        }//סוף משתמשים
        

        //מוצרים
        string SQLSentenceProducts = "Select * from products";
        DataSet products = connection.GetData(SQLSentenceProducts);
        //Response.Write("<table border='1'><tr><td>makat</td><td>name</td><td>quantity</td><td>price</td><td>picture</td></tr>");
        pagebody.Text += "<table border='5' bordercolor='red' style='border-radius:10px' cellspacing='5px'><tr><td>makat</td><td>name</td><td>quantity</td><td>price</td><td>picture</td></tr>";
        foreach (DataRow row in products.Tables[0].Rows)
        {
            //Response.Write("<tr><td>" + row["makat"] + "</td><td>" + row["name"] + "</td><td>" + row["quantity"] + "</td><td>" + row["price"] + "₪</td><td><img src='Pictures/" + row["picturename"] + "'/></td></tr>");
            pagebody.Text += "<tr><td>" + row["makat"] + "</td><td>" + row["name"] + "</td><td>" + row["quantity"] + "</td><td>" + row["price"] + "₪</td><td><img src='Pictures/" + row["picturename"] + "' height='180' width='127'/></td></tr>";
        }
        //Response.Write("</table>");
        pagebody.Text += "</table>";
        string makat = Request["makat"];
        string SQLItemSentence = "Select * from products where makat='" + makat + "'";
        DataSet SelectedProduct = connection.GetData(SQLItemSentence);
        if (Request["newitem"] != null)
        {
            Response.Redirect("NewItem.aspx");
        }
        if (Request["updateitem"] != null)
        {
            foreach (DataRow row in SelectedProduct.Tables[0].Rows)
            {
                Session["makat"] = row["makat"];
                Session["name"] = row["name"];
                Session["quantity"] = row["quantity"];
                Session["price"] = row["price"];
                Session["picturename"] = row["picturename"];
                Response.Redirect("UpdateItem.aspx");
            }
        }
        string SQLItemDelete = "Delete * from products where makat='" + makat + "'";
        if (Request["deleteitem"] != null)
        {
            connection.Update(SQLItemDelete);
            Response.Redirect("AdminUpdate.aspx");
        }
    }
}