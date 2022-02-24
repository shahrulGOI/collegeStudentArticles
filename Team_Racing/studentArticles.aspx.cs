using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using TeamRacing;

namespace Team_Racing
{
    public partial class studentReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
            string[] imageName = { "","", "" };
            Database database = new Database(); 
            try
            {
                (database.GetConnection()).Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `image_name` FROM `image`, `article`, `user` WHERE `image`.`image_ID` = `article`.`image_ID` AND `article`.`user_ID` = @userid", database.GetConnection());

                command.Parameters.Add("@userid", MySqlDbType.Int64).Value = global.users_id;
                adapt.SelectCommand = command;
                adapt.Fill(table);

                if(table.Rows.Count>0)
                {
                    for(int i=0;i<table.Rows.Count;i++)
                    {
                        imageName[i] = System.Convert.ToString(table.Rows[i][0]);
                    }
                }
            }
            catch(Exception i)
            {
                Response.Write(i.Message);
            }
            finally
            {
                (database.GetConnection()).Close();
                if (imageName[0] != "")
                {
                    image1.ImageUrl = "~/Files/" + global.users_name + "/" + imageName[0];
                }
                else
                {
                    image1.ImageUrl = "";
                }
                if (imageName[1] != "")
                {
                    image2.ImageUrl = "~/Files/" + global.users_name + "/" + imageName[1];
                }
                else
                {
                    image2.ImageUrl = "";
                }
                if (imageName[2] != "")
                {
                    image3.ImageUrl = "~/Files/" + global.users_name + "/" + imageName[2];
                }
                else
                {
                    image3.ImageUrl = "";
                }
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

        protected void btn1_Click(object sender, EventArgs e)
        {
            if (image1.ImageUrl != "")
            {
                global.articles_num = 0;
                HttpContext.Current.Response.Redirect("~/studentArticleReview.aspx");
            }
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            if (image2.ImageUrl != "")
            {
                global.articles_num = 1;
                HttpContext.Current.Response.Redirect("~/studentArticleReview.aspx");
            }
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            if (image3.ImageUrl != "")
            {
                global.articles_num = 2;
                HttpContext.Current.Response.Redirect("~/studentArticleReview.aspx");
            }
        }
    }
}