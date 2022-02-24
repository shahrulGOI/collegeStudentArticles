using TeamRacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Team_Racing
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        Database db = new Database();
        int article_ID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
            string[] fileName = { "", "", "" };
            string closureDate = "";
            Database database = new Database();
            try
            {
                (database.GetConnection()).Open();

                DataTable currentTable = new DataTable();
                MySqlDataAdapter currentAdapter = new MySqlDataAdapter();
                MySqlCommand currentCommand = new MySqlCommand("SELECT * from `duedate` WHERE `duedate_ID` = '1'", database.GetConnection());
                currentAdapter.SelectCommand = currentCommand;
                currentAdapter.Fill(currentTable);
                closureDate = System.Convert.ToString(currentTable.Rows[0][2].ToString());

                closureDueDate.InnerText = "Closure Due Date of upload will be in " + closureDate;

                //show the article
                DataTable table = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `article_description` FROM `article`, `user` WHERE `article`.`user_ID` = `user`.`user_ID` AND `user`.`name` = @username", database.GetConnection());

                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = global.students_name;
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
                    sendcommentButton.Enabled = false;
                }

                else
                {
                    readcommentTextBox.Text = "You have not make a comment yet.";
                    sendcommentButton.Enabled = true;
                    
                }

                //get the current publication status of the article
                DataTable tbl2 = new DataTable();
                MySqlDataAdapter adp2 = new MySqlDataAdapter();
                MySqlCommand cmd2 = new MySqlCommand("SELECT `publication` FROM `article` WHERE `article_ID` = @article_ID", database.GetConnection());
                cmd2.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                adp2.SelectCommand = cmd2;
                adp2.Fill(tbl2);
                string publication;
                if(tbl2.Rows.Count > 0)
                {
                    publication = System.Convert.ToString(tbl2.Rows[0][0]);
                    if (publication == "No")
                    {
                        saveButton.Text = "Save as publication";
                    }
                    else
                    {
                        saveButton.Text = "Save as non-pulication";
                    }
                }


            }
            catch (Exception i)
            {
                Response.Write(i.Message);
            }
            finally
            {
                (database.GetConnection()).Close();
                iframe1.Src = "~/Files/" + database.getStudent_Username()  + "/" + fileName[global.articles_num];
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
                Response.Redirect("~/CoordinatorMainMenu.aspx");
            }

        }


        protected void sendcommentButton_Click(object sender, EventArgs e)
        {
            db.GetConnection().Open();
            string comment = commentTextBox.Text + "       " + DateTime.Now.ToString();
            try
            {
                if (commentTextBox.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter your comment!')", true);
                }
                else
                {
                    //coordinator only can comment within 14days
                    DataTable tbl3 = new DataTable();
                    MySqlDataAdapter adp3 = new MySqlDataAdapter();
                    MySqlCommand cmd3 = new MySqlCommand("SELECT `article_date` FROM `article` WHERE `article_ID` = @article_ID", db.GetConnection());
                    cmd3.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                    adp3.SelectCommand = cmd3;
                    adp3.Fill(tbl3);
                    if (tbl3.Rows.Count > 0)
                    {
                        DateTime commentdue = System.Convert.ToDateTime(tbl3.Rows[0][0]);
                        if (DateTime.Now > commentdue.AddDays(14))
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You cannot leave a comment after 14days the contributions uploaded!')", true);
                        }

                        else
                        {
                            //save comment to database
                            MySqlDataAdapter adp2 = new MySqlDataAdapter();
                            MySqlCommand cmd2 = new MySqlCommand("INSERT INTO `comment` VALUES ('', @comment_coordinator, '' , @article_ID)", db.GetConnection());
                            cmd2.Parameters.Add("@comment_coordinator", MySqlDbType.VarChar).Value = comment;
                            cmd2.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                            cmd2.ExecuteNonQuery();
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Comment Successully!')", true);
                            this.Page.Response.Redirect("~/CoordinatorReply.aspx");
                        }

                    }
                }
            }
            catch (Exception i)
            {
                Response.Write(i.Message);
            }

            finally
            {
                db.GetConnection().Close();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {            
            db.GetConnection().Open();

            //retreive the closuredate from database
            DataTable tb2 = new DataTable();
            MySqlDataAdapter adp3 = new MySqlDataAdapter();
            MySqlCommand cmd3 = new MySqlCommand("SELECT `closuredate` FROM `duedate`",db.GetConnection());
            adp3.SelectCommand = cmd3;
            adp3.Fill(tb2);
            DateTime closuredate;
            closuredate = System.Convert.ToDateTime(tb2.Rows[0][0]);
            try
            {
                //coordinator cannot change the publication for the article after the closuredate
                if (DateTime.Now > closuredate)
                {
                    saveButton.Enabled = false;
                    sendcommentButton.Enabled = false;
                }

                else
                {
                    //change the publication for the article, for the default publication is no
                    if (saveButton.Text == "Save as publication")
                    {
                        MySqlCommand cmd4 = new MySqlCommand("UPDATE `article` SET `publication` = 'Yes' WHERE `article_ID` = @article_ID", db.GetConnection());
                        cmd4.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                        cmd4.ExecuteNonQuery();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(Publication Updated Successully!')", true);
                        this.Page.Response.Redirect("~/CoordinatorReply.aspx");
                    }
                    else
                    {
                        MySqlCommand cmd5 = new MySqlCommand("UPDATE `article` SET `publication` = 'No' WHERE `article_ID` = @article_ID", db.GetConnection());
                        cmd5.Parameters.Add("@article_ID", MySqlDbType.Int32).Value = article_ID;
                        cmd5.ExecuteNonQuery();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(Publication Updated Successully!')", true);
                        this.Page.Response.Redirect("~/CoordinatorReply.aspx");
                    }

                }
            }
            catch(Exception f)
            {
                Console.WriteLine(f.Message);
            }
            finally
            {
                (db.GetConnection()).Close();
            }
        }


    }
}