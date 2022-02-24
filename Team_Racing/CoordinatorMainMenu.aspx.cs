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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
            string[] imageName = { "", "", "" };
            string studentUsername = "";
            Database database = new Database();
            if (!IsPostBack)
            {
                studentDropDownList.DataSource = database.getUser_Name();
                studentDropDownList.DataBind();
            }
            if (studentDropDownList.SelectedItem.Value =="")
            {
                Response.Write("No student is selected.");
            }
            else
            {
                try
                {
                    database.GetConnection().Open();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT `image_name` FROM `image`, `article`, `user` WHERE `article`.`image_ID` = `image`.`image_ID` AND `article`.`user_ID` = `user`.`user_ID` AND `user`.`name`= @name", database.GetConnection());
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = studentDropDownList.SelectedItem.Value;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if(table.Rows.Count>0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            imageName[i] = System.Convert.ToString(table.Rows[i][0]);
                        }
                    }

                    DataTable table1 = new DataTable();
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                    MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT `username` FROM `user` WHERE `user`.`name`= @name", database.GetConnection());
                    command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = studentDropDownList.SelectedItem.Value;
                    adapter1.SelectCommand = command1;
                    adapter1.Fill(table1);
                    if (table1.Rows.Count > 0)
                    {
                        studentUsername = System.Convert.ToString(table1.Rows[0][0]);
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    database.GetConnection().Close();
                    if (imageName[0]!= "")
                    {
                        image1.ImageUrl = "~/Files/" + studentUsername + "/" + imageName[0];
                    }
                    else
                    {
                        image1.ImageUrl = "";
                    }
                    if(imageName[1] != "")
                    {
                        image2.ImageUrl = "~/Files/" + studentUsername + "/" + imageName[1];
                    }
                    else
                    {
                        image2.ImageUrl = "";
                    }
                    if (imageName[2] != "")
                    {
                        image3.ImageUrl = "~/Files/" + studentUsername + "/" + imageName[2];
                    }
                    else
                    {
                        image3.ImageUrl = "";
                    }
                }
            }
        }


        protected void btn1_Click(object sender, EventArgs e)
        {
            if (image1.ImageUrl != "")
            {
                global.students_name = studentDropDownList.SelectedItem.Value;
                global.articles_num = 0;
                HttpContext.Current.Response.Redirect("~/CoordinatorReply.aspx");
            }
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            if (image2.ImageUrl != "")
            {
                global.students_name = studentDropDownList.SelectedItem.Value;
                global.articles_num = 1;
                HttpContext.Current.Response.Redirect("~/CoordinatorReply.aspx");

            }
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            if (image3.ImageUrl != "")
            {
                global.students_name = studentDropDownList.SelectedItem.Value;
                global.articles_num = 2;
                HttpContext.Current.Response.Redirect("~/CoordinatorReply.aspx");
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
    }
}