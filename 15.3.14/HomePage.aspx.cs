using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["lastvisit"] = "HomePage.aspx";
        string dbPath = this.MapPath("App_Data/ds1.accdb");
        Session["path"] = dbPath.ToString();
    }
}