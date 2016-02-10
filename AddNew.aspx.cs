using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class AddNew : System.Web.UI.Page
{
    //Initiate DB variables
    public String SQL;
    public SqlConnection oConn;
    public SqlCommand oCmd;
    public String connStr = "server=sotdev4.tech.purdue.edu;uid=cgt4562f;pwd=Slinkily2f447;database=cgt4562f";  //SQL server connection string
    public SqlDataReader rdr;
    //End Initiate DB variables
    public string fileName;


    protected void Page_Load(object sender, EventArgs e)
    {
        AutoPopulateFields();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.fuComicImage.HasFile)
        {
            fuComicImage.SaveAs(Server.MapPath("~/FrontEnd/images/titles/" + fuComicImage.FileName.ToString()));
            fileName = fuComicImage.FileName.ToString();
        }


        oConn = new SqlConnection(connStr);
        SQL = "INSERT INTO tblComicInfoProject3 VALUES ('" + tbID.Text.ToString() + "', '" + tbName.Text.ToString() + "', '" + tbDesc.Text.ToString() + "', '" + ddlRate.SelectedValue.ToString() + "', '" + tbUpdate.Text.ToString() + "', '" + tbURL.Text.ToString() + "', '" + fileName + "', '" + tbAuthor.Text + "', '" + ddlGenre.SelectedValue.ToString() + "', '" + ddlSubGenre.SelectedValue.ToString() + "' );";
        //SQL = "INSERT INTO tblComicInfoProject3 VALUES ('0505', '1', '1', '1', '1', 'google.com', 'filename', 'Author', 'Action', 'Comedy' );";
        oCmd = new SqlCommand(SQL, oConn);
        oConn.Open();
        oCmd.ExecuteReader();
        //Response.Write(SQL);
        test.Text = SQL;
    }
    public void AutoPopulateFields()
    {
        oConn = new SqlConnection(connStr);
        SQL = "SELECT MAX(ComicId) FROM tblComicInfoProject3";
        oCmd = new SqlCommand(SQL, oConn);
        oConn.Open();
        //oCmd.ExecuteReader();
        using (SqlDataReader rdr = oCmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                tbID.Text = (Convert.ToInt32(rdr[0].ToString()) + 1).ToString();
                tbID.ReadOnly = true;
            }
        }
        oConn.Close();
    }
}
