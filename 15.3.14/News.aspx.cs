using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class aspx_to_delete_V2 : System.Web.UI.Page
{
    public string stringi = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string XMLFile = Server.MapPath("XMLFileToDelete.xml");
        XmlDocument whatsupdoc = new XmlDocument();
        whatsupdoc.Load(XMLFile);
        XmlNodeList son1 = whatsupdoc.GetElementsByTagName("son1");
        XmlNodeList son2 = whatsupdoc.GetElementsByTagName("son2");
        int number = son1.Count;
        stringi = "<h1>News</h1>";
        for (int i = 0; i < number; i++)
        {
            stringi += "<p>";
            stringi += "<h3>" + son1[i].InnerText + "</h3>";
            stringi += son2[i].InnerText;
            stringi += "</p><br />";
        }
        if (Session["userexists"] != null)
        {
            if (Session["userinfo"].ToString() == "admin")
            {
                stringi += "<a href='NewPost.aspx'>Post</a>";
            }
        }
    }
}