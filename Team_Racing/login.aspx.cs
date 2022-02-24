using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team_Racing;

namespace TeamRacing
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertLabel.Text = "";
        }

        protected void buttonSignIn_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            string username = textUsername.Text;
            string userPw = textPassword.Text;
            global.users_name = textUsername.Text;
            try
            {
                (database.GetConnection()).Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `username` = @username AND `password` = MD5(@password)", database.GetConnection());

                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userPw;
                adapt.SelectCommand = command;
                adapt.Fill(table);
                var page = HttpContext.Current.CurrentHandler as Page;

                if (table.Rows.Count > 0)
                {
                    string usertype;
                    login login1 = new login();
                    usertype = System.Convert.ToString(table.Rows[0][5].ToString());
                    global.users_id = System.Convert.ToInt32(table.Rows[0][0]);
                    global.facultys_num = System.Convert.ToInt32(table.Rows[0][6]);
                    if (usertype == "Student")
                    {
                        HttpContext.Current.Response.Redirect("~/userUpload.aspx");
                    }

                    else if (usertype == "Coordinator")
                    {
                        HttpContext.Current.Response.Redirect("~/CoordinatorMainMenu.aspx");

                    }

                    else if (usertype == "Manager")
                    {
                        HttpContext.Current.Response.Redirect("~/ManagerMainMenu.aspx");

                    }

                }
                else
                {
                    alertLabel.Text = "Please Check Your Username and Password.";
                }
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
            }
            finally
            {

            }

        }

        protected void adminButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

    }
    
}