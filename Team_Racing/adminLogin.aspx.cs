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
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                MySqlCommand command = new MySqlCommand("SELECT * FROM `admin` WHERE `admin_username` = @username AND `admin_password` = MD5(@password)", database.GetConnection());

                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userPw;
                adapt.SelectCommand = command;
                adapt.Fill(table);

                if (table.Rows.Count > 0)
                {
                        HttpContext.Current.Response.Redirect("~/adminMainMenu.aspx");
                }
                else
                {
                    alertLabel.Text = "Please Check Your Username and Password.";
                }
            }
            catch (Exception f)
            {
                Response.Write(f.Message);
            }
            finally
            {

            }
        }
    }
}