using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_Racing
{
    public partial class GuestMainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Database database = new Database();
            try
            {
                database.GetConnection().Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT ROW_NUMBER() OVER(ORDER BY `article_date`) AS `no`, `name`, `article_title`, `faculty`.`faculty_name` " +
                    "FROM `user`, `article`, `faculty` WHERE `user`.`user_ID` = `article`.`user_ID` " +
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

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string studentName = (string)button.Attributes["data-name"];
            string articleName = (string)button.Attributes["data-article"];
            global.students_name = studentName;
            global.articles_name = articleName;

            Response.Redirect("~/GuestArticleReview.aspx");


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
                Response.Redirect("~/GuestMainMenu.aspx");
            }

        }
    }
}