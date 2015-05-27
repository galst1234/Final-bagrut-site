using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserUpdateInfV2 : System.Web.UI.Page
{
    public string id;
    public string fname;
    public string lname;
    public string email;
    public string phnum;
    public string userinfo;
    public string username;
    public string password;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string checkused = "Select * from shoolhan where ID='" + Request["id"] + "' Or UserName='" + Request["username"] + "'";
        DataSet ds;
        id = (string)Session["idtoupdate"];
        fname = (string)Session["fnametoupdate"];
        lname = (string)Session["lnametoupdate"];
        email = (string)Session["emailtoupdate"];
        phnum = (string)Session["phnumtoupdate"];
        userinfo = (string)Session["userinfotoupdate"];
        username = (string)Session["usernametoupdate"];
        password = (string)Session["passwordtoupdate"];
        string sqlsentence;
        if (Session["userexists"] != null)
        {
            if (Session["userinfo"].ToString() == "admin")
            {
                userinfolable.Text = "user info: <input value='" + userinfo + "' name='userinf'/><br />";
            }
        }
        SQLConnection connection = new SQLConnection((string)Session["path"]);
        if (Request["sub"] != null)
        {
            if (Session["userexists"] != null)
            {
                if (Session["userinfo"].ToString() == "admin")
                {
                    sqlsentence = "update shoolhan set fname='" + Request["fname"] + "', lname='" + Request["lname"] + "', ID='" + Request["id"] + "', email='" + Request["email"] + "', phone_number='" + Request["phnum"] + "', userinfo='" + Request["userinf"] + "', [UserName]='" + Request["username"] + "', [PassWord]='" + Request["password"] + "' where ID='" + id + "'";
                }
                else
                {
                    sqlsentence = "update shoolhan set fname='" + Request["fname"] + "', lname='" + Request["lname"] + "', ID='" + Request["id"] + "', email='" + Request["email"] + "', phone_number='" + Request["phnum"] + "', userinfo='user', [UserName]='" + Request["username"] + "', [PassWord]='" + Request["password"] + "' where ID='" + id + "'";
                }
                //ds = connection.GetData(checkused);
                bool idused = connection.CheckExistance("Select * from shoolhan where ID='" + Request["id"] + "'");
                bool usernameused = connection.CheckExistance("Select * from shoolhan where UserName='" + Request["username"] + "'");
                if (/*connection.CheckExistance(checkused) && (Session["idtoupdate"].ToString() != Request["id"].ToString() || Session["usernametoupdate"].ToString() != Request["username"].ToString())*/idused && Session["idtoupdate"].ToString() != Request["id"].ToString() || usernameused && Session["usernametoupdate"].ToString() != Request["username"].ToString())
                {
                    used.Text = "Sorry but the username or id is already in use. Please try another one.";
                }
                else
                {
                    connection.Update(sqlsentence);
                    //sqlsentence = "update shoolhan set [UserName]='" + Request["username"] + "', [PassWord]='" + Request["password"] + "' where [ID]='" + id + "'";
                    //connection.Update(sqlsentence);
                    if (Session["userinfo"].ToString() == "admin")
                    {
                        if (Session["id"].ToString() == Session["idtoupdate"].ToString())
                        {
                            Session["idtoupdate"] = Request["id"];
                            Session["fnametoupdate"] = Request["fname"].ToString();
                            Session["lnametoupdate"] = Request["lname"].ToString();
                            Session["emailtoupdate"] = Request["email"].ToString();
                            Session["phnumtoupdate"] = Request["phnum"].ToString();
                            Session["userinfotoupdate"] = Request["userinfo"].ToString();
                            Session["usernametoupdate"] = Request["username"].ToString();
                            Session["passwordtoupdate"] = Request["password"].ToString();
                        }
                        else
                        {
                            Session["idtoupdate"] = Session["id"];
                            Session["fnametoupdate"] = Session["fname"].ToString();
                            Session["lnametoupdate"] = Session["lname"].ToString();
                            Session["emailtoupdate"] = Session["email"].ToString();
                            Session["phnumtoupdate"] = Session["phnum"].ToString();
                            Session["userinfotoupdate"] = Session["userinfo"].ToString();
                            Session["usernametoupdate"] = Session["username"].ToString();
                            Session["passwordtoupdate"] = Session["password"].ToString();
                        }
                    }
                    else
                    {
                        Session["idtoupdate"] = Request["id"];
                        Session["fnametoupdate"] = Request["fname"].ToString();
                        Session["lnametoupdate"] = Request["lname"].ToString();
                        Session["emailtoupdate"] = Request["email"].ToString();
                        Session["phnumtoupdate"] = Request["phnum"].ToString();
                        Session["userinfotoupdate"] = Session["userinfo"].ToString();
                        Session["usernametoupdate"] = Request["username"].ToString();
                        Session["passwordtoupdate"] = Request["password"].ToString();
                    }
                    Response.Redirect(Session["lastvisit"].ToString());
                }
            }

            else
            {
                notlogedin.Text = "To update your information please log in";
            }
        }
    }
}