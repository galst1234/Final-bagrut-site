using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SignUpV2 : System.Web.UI.Page
{
    public string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = (string)Session["id"];
        string sqlsentence;
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        string checkused = "Select * from shoolhan where ID='" + Request["id"] + "' Or UserName='" + Request["username"] + "'";
        DataSet ds;
        if (Request["sub"] != null)
        {
            ds = connection.GetData(checkused);
            if (connection.CheckExistance(checkused))
            {
                used.Text = "Sorry but the username or id is already in use. Please try another one.";
            }
            else
            {
                sqlsentence = "insert into shoolhan (fname,lname,[ID],email,phone_number,userinfo,[UserName],[PassWord],price,itemsInCart) values ('" + Request["fname"] + "', '" + Request["lname"] + "', '" + Request["id"] + "', '" + Request["email"] + "', '" + Request["phnum"] + "', 'user', '" + Request["username"] + "', '" + Request["password"] + "', '0', '0')";
                connection.Insert(sqlsentence);
                Response.Redirect("SignIn.aspx");
            }
        }
    }
}