using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

public partial class aspx_to_delete_II_V2 : System.Web.UI.Page
{
    public void XML(string son1, string son2)
    {
        XmlElement fatherEle, son1Ele, son2Ele;
        XmlDocument doc = new XmlDocument();
        string XMLfile = Server.MapPath("XMLFileToDelete.xml");
        doc.Load(XMLfile);
        //יצירת הרכיבים
        fatherEle = doc.CreateElement("father");
        son1Ele = doc.CreateElement("son1");
        son2Ele = doc.CreateElement("son2");

        son1Ele.InnerText = son1;
        son2Ele.InnerText = son2;

        fatherEle.AppendChild(son1Ele);
        fatherEle.AppendChild(son2Ele);
        //הכנסת הרכיב לקובץ כרכיב ראשון
        doc.DocumentElement.InsertBefore(fatherEle, doc.DocumentElement.FirstChild);
        // סגירת העדכון בקובץ והפיכתו לשמיש בעתיד
        FileStream fsxml = new FileStream(XMLfile, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
        doc.Save(fsxml);
        fsxml.Close();
        Response.Redirect("News.aspx");
    }
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
        if (Request["bt"] != null)
        {
            XML(Request["son1"], Request["son2"]);
        }
    }
}