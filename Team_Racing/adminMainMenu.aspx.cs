using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using TeamRacing;

namespace Team_Racing
{
    public partial class adminMainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;
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

        protected void registerButton_Click(object sender, EventArgs e)
        {
            getEmail mail = new getEmail();
            Database database = new Database();
            string name = nameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phonenumberTextBox.Text;
            string roles = rolesDropDownList.SelectedValue;
            string faculty = facultyDropDownList.SelectedValue;
            string dob = dateTextBox.Text;
            string gender = genderDropDownList.SelectedValue;

            (database.GetConnection()).Open();
            DataTable existuser = new DataTable();
            MySqlDataAdapter adapt2 = new MySqlDataAdapter();
            MySqlCommand command2 = new MySqlCommand("SELECT * from `user` WHERE `username` = @username", database.GetConnection());
            command2.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapt2.SelectCommand = command2;
            adapt2.Fill(existuser);

            if (existuser.Rows.Count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This username had been taken already!')", true);
                usernameTextBox.Text = "";
            }

            else
            {
                try
                {

                    DataTable table = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `user` VALUES ('', @username, MD5(@password), @name, @email, @roles, @faculty, @phone, @dob, @gender)", database.GetConnection());
                    command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@roles", MySqlDbType.VarChar).Value = roles;
                    command.Parameters.Add("@faculty", MySqlDbType.Int32).Value = faculty;
                    command.Parameters.Add("@phone", MySqlDbType.Int32).Value = phone;
                    command.Parameters.Add("@dob", MySqlDbType.Date).Value = dob;
                    command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                    command.ExecuteNonQuery();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Register Successully!')", true);
                    nameTextBox.Text = "";
                    usernameTextBox.Text = "";
                    emailTextBox.Text = "";
                    phonenumberTextBox.Text = "";
                    rolesDropDownList.SelectedValue = "Roles";
                    facultyDropDownList.SelectedValue = "Faculty";
                    passwordTextBox.Text = "";
                    dateTextBox.Text = "";
                    genderDropDownList.SelectedValue = "Gender";

                }
                catch (Exception f)
                {
                    Console.WriteLine(f.Message);
                }
                finally
                {
                    database.GetConnection().Close();
                    mail.registrationEmailing(email, name, username, password);
                }
            }
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            usernameTextBox.Text = "";
            emailTextBox.Text = "";
            phonenumberTextBox.Text = "";
            rolesDropDownList.SelectedValue = "Roles";
            facultyDropDownList.SelectedValue = "Faculty";
            passwordTextBox.Text = "";
            dateTextBox.Text = "";
            genderDropDownList.SelectedValue = "Gender";
        }
    }
}