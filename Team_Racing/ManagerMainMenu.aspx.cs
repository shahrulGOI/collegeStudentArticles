using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using System.IO;

namespace Team_Racing
{
    public partial class ManagerMainMenu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
            Database database = new Database();

            try
            {
                database.GetConnection().Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT ROW_NUMBER() OVER(ORDER BY `article_date`) AS `no`, `name`, `user`.`username`, `article_title`, `article_description`, `faculty`.`faculty_name`, `image`.`image_name` " +
                    "FROM `user`, `article`, `faculty`, `image` WHERE `user`.`user_ID` = `article`.`user_ID` AND `article`.`image_ID` = `image`.`image_ID`" +
                    "AND `user`.`faculty_ID` = `faculty`.`faculty_ID` AND `article`.`publication` = @publication ORDER BY `article_date`;", database.GetConnection());
                command.Parameters.Add("@publication", MySqlDbType.VarChar).Value = "Yes";
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    gridView1.DataSource = table;
                    gridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                database.GetConnection().Close();
            }
        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are logged out!')", true);
                Response.Redirect("~/login.aspx");
            }
            else
            {
                Response.Redirect("~/ManagerMainMenu.aspx");
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string studentName = (string)button.Attributes["data-name"];
            string articleName = (string)button.Attributes["data-article"];

            global.students_name = studentName;
            global.articles_name = articleName;

            Response.Redirect("~/ManagerArticleReview.aspx");


        }

        //download one selected contributions
        protected void download1Button_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string studentUsername = (string)button.Attributes["data-username"];
            string articledescription = (string)button.Attributes["data-description"];
            string image_name = (string)button.Attributes["data-image"];

            using (ZipFile zip = new ZipFile())
            {
                string filepath = Server.MapPath("~/Files/" + studentUsername + "/" + articledescription);
                string filepath2 = Server.MapPath("~/Files/" + studentUsername + "/" + image_name);
                zip.AddFile(filepath, studentUsername);
                zip.AddFile(filepath2, studentUsername);
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
                zip.Save(Response.OutputStream);
            }

        }       
    }
}
