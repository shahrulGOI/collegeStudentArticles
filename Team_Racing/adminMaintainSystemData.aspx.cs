using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Team_Racing
{
    public partial class adminMaintainSystemData : System.Web.UI.Page
    {
        Database database = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
           
            (database.GetConnection()).Open();

            DataTable current = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * from `duedate` WHERE `duedate_ID` = '1'", database.GetConnection());
            adapt.SelectCommand = command;
            adapt.Fill(current);

            currentDueDateTextBox.Text = System.Convert.ToString(current.Rows[0][1].ToString());
            currentclosureduedateTextbox.Text = System.Convert.ToString(current.Rows[0][2].ToString());

            (database.GetConnection()).Close();            
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
                Response.Redirect("~/adminMainMenu.aspx");
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string dd = duedatedateTextBox.Text;
            string ddd = duedatetimeTextBox1.Text;
            string dt = dd + " " + ddd;

            string cd = closureduedatedateTextBox.Text;
            string cdd = closuredatetimeTextBox.Text;
            string dt2 = cd + " " + cdd;

            DateTime firstdue = Convert.ToDateTime(dt);
            DateTime seconddue = Convert.ToDateTime(dt2);

            if (seconddue > firstdue)
            {
                try
                {
                    (database.GetConnection()).Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `duedate` SET `firstduedate` = '" + dt + "', `closuredate` = '" + dt2 + "' WHERE `duedate_ID` = '1' ", database.GetConnection());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception f)
                {
                    Console.WriteLine(f.Message);
                }

                finally
                {
                    (database.GetConnection()).Close();
                }
            }

            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Closure date cannot be earlier than the first due date! Please choose another time.')", true);               
            } 

        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            duedatedateTextBox.Text = "";
            duedatetimeTextBox1.Text = "";
            closureduedatedateTextBox.Text = "";
            closuredatetimeTextBox.Text = "";
        }
    }
}