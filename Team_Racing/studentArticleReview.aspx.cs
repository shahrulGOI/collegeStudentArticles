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
    public partial class studentArticleReview : System.Web.UI.Page
    {
        int article_ID;
        Database database = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
            string[] fileName = { "", "", "" };
            
            try
            {
                (database.GetConnection()).Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `article_description` FROM `article`, `user` WHERE `article`.`user_ID` = @userid", database.GetConnection());

                command.Parameters.Add("@userid", MySqlDbType.Int64).Value = global.users_id;
                adapt.SelectCommand = command;
                adapt.Fill(table);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        fileName[i] = System.Convert.ToString(table.Rows[i][0]);
                    }
                }

                //get the article_ID
                DataTable dt = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter();
                MySqlCommand cm = new MySqlCommand("SELECT `article_ID` from `article` WHERE `article_description` = '" + fileName[global.articles_num] + "'", database.GetConnection());
                ad.SelectCommand = cm;
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    article_ID = System.Convert.ToInt32(dt.Rows[0][0]);
                }

                //retreive comment from the database
                DataTable tbl = new DataTable();
                MySqlDataAdapter adp = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `comment`.`comment_coordinator`, `comment`.`comment_student` FROM `comment` WHERE `article_ID` = @article_ID", database.GetConnection());
                cmd.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                adp.SelectCommand = cmd;
                adp.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    //the format of the textbox
                    readcommentTextBox.Text = "Coordinator: " + System.Convert.ToString(tbl.Rows[0][0]) +
                                                System.Environment.NewLine +
                                                "Student: " + System.Convert.ToString(tbl.Rows[0][1]);
                    
                }

                else
                {
                    readcommentTextBox.Text = "You coordiantor has not make a comment yet.";
                    sendcommentButton.Enabled = false;
                }


            }
            catch (Exception i)
            {
                Response.Write(i.Message);
            }
            finally
            {
                (database.GetConnection()).Close();
                iframe1.Src = "~/Files/" + global.users_name + "/" + fileName[global.articles_num];
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
                Response.Redirect("~/userUpload.aspx");
            }

        }

        protected void sendcommentButton_Click(object sender, EventArgs e)
        {
            database.GetConnection().Open();
            string comment = commentTextBox.Text + "       " + DateTime.Now.ToString();
            try
            {
                if (commentTextBox.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter your comment!')", true);
                }
                else
                {
                    //save comment to database
                    MySqlDataAdapter adp2 = new MySqlDataAdapter();
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE `comment` SET `comment_student` = @comment_student WHERE `article_ID`= @article_ID", database.GetConnection());
                    cmd2.Parameters.Add("@comment_student", MySqlDbType.VarChar).Value = comment;
                    cmd2.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                    cmd2.ExecuteNonQuery();

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Comment Successully!')", true);
                    this.Page.Response.Redirect("~/studentArticleReview.aspx");
                }

            }
            catch (Exception i)
            {
                Response.Write(i.Message);
            }

            finally
            {
                database.GetConnection().Close();
            }
        }
    }
}