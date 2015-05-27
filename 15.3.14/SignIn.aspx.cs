using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SignInV2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userexists"] = null;
        Session["idtoupdate"] = null;
        Session["fnametoupdate"] = null;
        Session["lnametoupdate"] = null;
        Session["emailtoupdate"] = null;
        Session["phnumtoupdate"] = null;
        Session["userinfotoupdate"] = null;
        Session["usernametoupdate"] = null;
        Session["passwordtoupdate"] = null;
        Session["userinfo"] = null;
        Session["id"] = null;
        Session["fname"] = null;
        Session["lname"] = null;
        Session["email"] = null;
        Session["phnum"] = null;
        Session["username"] = null;
        Session["password"] = null;
        Session["payprice"] = null;
        Session["itemsInCart"] = null;
        Session["itemsNames"] = null;
        Application.Lock();
        if (Application["visitcount"] == null)
        {
            Application["visitcount"] = 0;
        }
        //Application["visitcount"] = (int)Application["visitcount"] + 1;
        Response.Write(Application["visitcount"]);
        Application.UnLock();
        string dbPath = this.MapPath("App_Data/ds1.accdb");
        Session["path"] = dbPath.ToString();
        SQLConnection connection = new SQLConnection(dbPath);
        string username = Request["username"];
        Session["username"] = username;
        string password = Request["password"];
        Session["password"] = password;
        string SQLSentence = "Select * from shoolhan where UserName='" + username + "' And PassWord='" + password + "'";
        DataSet ds = connection.GetData(SQLSentence);
        if (Request["sub"] != null)
        {
            if (connection.CheckExistance(SQLSentence))
            {
                Application.Lock();
                Application["visitcount"] = (int)Application["visitcount"] + 1;
                Application.UnLock();
                Session["userexists"] = "true";
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
                    Session["userinfo"] = row["userinfo"].ToString();
                    Session["id"] = row["ID"].ToString();
                    Session["fname"] = row["fname"].ToString();
                    Session["lname"] = row["lname"].ToString();
                    Session["email"] = row["email"].ToString();
                    Session["phnum"] = row["phone_number"].ToString();
                    Session["username"] = row["UserName"].ToString();
                    Session["password"] = row["PassWord"].ToString();
                    Session["payprice"] = row["price"].ToString();
                    Session["itemsInCart"] = row["itemsInCart"].ToString();
                    Session["itemsNames"] = row["itemsNames"].ToString();
                    Response.Redirect(Session["lastvisit"].ToString());
                }
            }
            else
            {
                badlogin.Text = "Incorrect Login, please try again or creat a new user";
            }
        }
    }
}