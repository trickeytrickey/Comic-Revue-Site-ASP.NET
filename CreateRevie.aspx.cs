using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class CreateReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(MapPath("ComicReviews.xml"));


        //XmlElement elem = doc.CreateElement("test");
        //elem.InnerText = "it worked!";

        //XmlNode oldCd;
        XmlElement root = doc.DocumentElement;
        //oldCd = root.SelectSingleNode("/catalog/cd[title='Hide your heart']");
        XmlElement newCd = doc.CreateElement("ComicReview");
        //newCd.SetAttribute("country", "Country.text");

        newCd.InnerXml = "<ComicName>" + txtComicName.Text + "</ComicName> <ReviewerName>" + txtReviewer.Text + "</ReviewerName> <Rating>" + txtRating.Text + "</Rating> <Genre1>" + txtGenre1.Text + "</Genre1> <Genre2>" + txtGenre2.Text + "</Genre2> <Status>" + txtURL.Text + "</Status> <Quality>" + txtQuality.Text + "</Quality>";
        //root.ReplaceChild(newCd, oldCd);
        root.PrependChild(newCd);
        Response.Write(doc.ToString());
        doc.Save(MapPath("ComicReviews.xml"));
    }
}
