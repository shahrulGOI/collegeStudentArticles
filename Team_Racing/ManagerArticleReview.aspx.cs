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
    public partial class ManagerArticleReview : System.Web.UI.Page
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
                MySqlCommand command = new MySqlCommand("SELECT `article`.`article_description`, `image`.`image_name`, `user`.`name`, `faculty`.`faculty_name`, `user`.`email` "+
                                                        "FROM `article`, `user`, `image`, `faculty` "+
                                                        "WHERE `article`.`image_ID` = `image`.`image_ID` "+
                                                        "AND `article`.`user_ID` = `user`.`user_ID` "+
                                                        "AND `user`.`faculty_ID` = `faculty`.`faculty_ID` "+
                                                        "AND `user`.`name` = @name "+
                                                        "AND `article`.`article_title` = @title", database.GetConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = global.students_name;
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = global.articles_name;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    iframe.Src = "~/Files/" + database.getStudent_Username() + "/" + System.Convert.ToString(table.Rows[0][0]);
                    student_name.InnerText = "Student name: " + global.students_name;
                    student_faculty.InnerText = "Faculty: " + System.Convert.ToString(table.Rows[0][3]);
                    student_email.InnerText = "Email: " + System.Convert.ToString(table.Rows[0][4]);

                    iframe2.Src = "~/Files/" + database.getStudent_Username() + "/" + System.Convert.ToString(table.Rows[0][1]);
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
    }
}