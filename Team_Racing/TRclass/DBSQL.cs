using TeamRacing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Team_Racing
{
    class Database  
    {
        MySqlConnection myconn;
        public Database()
        {
            myconn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=racing; convert zero datetime=True");
        }

        public MySqlConnection GetConnection()
        {
            return myconn;
        }

        //get article based on faculty id of coordinator
        
        //update article as coordinator
        public void updateArticle(string tit, string des, int pass, int selectedId)
        {
            myconn.Open();
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "UPDATE article_title, article_desc, article_pass SET article_title =@title , article_desc =@desc , article_pass =@pa  WHERE article_id = @selectedArticle";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = myconn;
                    cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = tit;
                    cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = des;
                    cmd.Parameters.Add("@pa", MySqlDbType.Int32).Value = pass;

                    cmd.ExecuteNonQuery();
                    myconn.Close();
                }
            }
        }


      

        //Delete article from database
        public void deleteArticle(int article_remove_id)
        {
            myconn.Open();
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "DELETE FROM article WHERE article_id =@artId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = myconn;
                    cmd.Parameters.Add("@artId", MySqlDbType.Int32).Value = article_remove_id;
                    cmd.ExecuteNonQuery();
                    myconn.Close();
                }
            }
        }

        public int getImage(string img)
        {
            DataTable table = new DataTable();
            int imageId = 0;
            try
            {
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `image_ID` FROM `image` WHERE image_name = @image;", myconn);
                command.Parameters.Add("@image", MySqlDbType.VarChar).Value = img;
                adapt.SelectCommand = command;
                adapt.Fill(table);
                if (table.Rows.Count > 0)
                {
                    imageId = System.Convert.ToInt32(table.Rows[0][0]);
                }

            }
            catch (Exception)
            {

            }
            return imageId;
        }

        public string getUserEmailAddress(int userid)
        {
            DataTable table = new DataTable();
            string address = "";
            try
            {
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `email` FROM `user` WHERE `user_ID` = @userid;", myconn);
                command.Parameters.Add("@userid", MySqlDbType.Int32).Value = userid;
                adapt.SelectCommand = command;
                adapt.Fill(table);
                if (table.Rows.Count > 0)
                {
                    address = System.Convert.ToString(table.Rows[0][0]);
                }

            }
            catch (Exception)
            {

            }
            return address;
        }

        public string getCoordinatorEmailAddress(int faculty)
        {
            DataTable table = new DataTable();
            string address = "";
            try
            {
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `email` FROM `user`, `faculty` WHERE `user`.`user_type` = @type AND `faculty`.`faculty_ID` = @faculty;", myconn);
                command.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Coordinator";
                command.Parameters.Add("@faculty", MySqlDbType.Int32).Value = faculty;
                adapt.SelectCommand = command;
                adapt.Fill(table);
                if (table.Rows.Count > 0)
                {
                    address = System.Convert.ToString(table.Rows[0][0]);
                }

            }
            catch (Exception)
            {

            }
            return address;
        }

        public ArrayList getUser_Name()
        {
            ArrayList username = new ArrayList();
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `name` FROM `user`, `faculty` WHERE `faculty`.`faculty_ID` = `user`.`faculty_ID` AND `faculty`.`faculty_ID`= @faculty AND `user`.`user_type` = @type Order BY `name` ASC;", myconn);
                command.Parameters.Add("@faculty", MySqlDbType.Int32).Value = global.facultys_num;
                command.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Student";
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if(table.Rows.Count > 0)
                {
                    for(int i=0; i <= table.Rows.Count ; i++)
                    {
                        username.Add(System.Convert.ToString(table.Rows[i][0]));
                    }
                }
            }
            catch(Exception)
            {
                
            }
            return username;
        }

        public string getStudent_Username() // to retrieve student username for coodinator purpose.
        {
            string username = "";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `username` FROM `user` WHERE `user`.`name` = @name", myconn);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = global.students_name;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    username = System.Convert.ToString(table.Rows[0][0]);
                }
            }
            catch (Exception)
            {

            }
            return username;
        }

        public string getStudent_name(int id) // to get student name
        {
            string name = "";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT `name` FROM `user` WHERE `user_ID = @userid", myconn);
                command.Parameters.Add("@userid", MySqlDbType.Int32).Value = id;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    name = System.Convert.ToString(table.Rows[0][0]);
                }
            }
            catch (Exception)
            {

            }
            return name;
        }

        public bool checkStudentUploadLimit() // to check student upload limit (max 3)
        {
            bool limit = true;
            try
            {
                myconn.Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT DISTINCT COUNT(`article_description`) FROM `article` WHERE `article`.`user_ID` = @userid", myconn);
                command.Parameters.Add("@userid", MySqlDbType.Int32).Value = global.users_id;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                     int article = System.Convert.ToInt32(table.Rows[0][0]);
                    if(article > 2)
                    {
                       limit = false;
                    }
                    else
                    {
                        limit = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            return limit;
        }
    }

}
