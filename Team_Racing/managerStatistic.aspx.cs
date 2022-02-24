using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace Team_Racing
{
    public partial class managerStatistic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
            Database db = new Database();
            try
            {
                (db.GetConnection()).Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter adp = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("SELECT `faculty`.`faculty_name` as Faculty, COUNT(`article`.`article_ID`) as TotalAmount FROM `article`, `user`, `faculty` WHERE `article`.`user_ID` = `user`.`user_ID` AND `user`.`faculty_ID` = `faculty`.`faculty_ID` GROUP 	BY `faculty_name`", db.GetConnection());
                adp.SelectCommand = cmd;
                adp.Fill(dt);
                string[] x = new string[dt.Rows.Count];
                int[] y = new int[dt.Rows.Count];

                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    x[i] = dt.Rows[i][0].ToString();
                    y[i] = Convert.ToInt32(dt.Rows[i][1]);
                }

                Chart1.Series[0].Points.DataBindXY(x, y);

                if(charttypeDropDownList.SelectedValue == "Pie") 
                {
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    Chart1.Series[0]["PieLabelStyle"] = "Outside";
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.ChartAreas[0].Area3DStyle.Inclination = 10;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                else if (charttypeDropDownList.SelectedValue == "Bar")
                {
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                else
                {
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                

            }
            catch (Exception f)
                {
                Console.WriteLine(f.Message);
            }
            finally
            {
                (db.GetConnection()).Close();
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