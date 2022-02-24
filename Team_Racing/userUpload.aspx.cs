using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamRacing;
using WordToPDF;

namespace Team_Racing
{
    public partial class userUpload : System.Web.UI.Page
    {
        Database database = new Database();
        string currentDueDate="";
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelusername.Text = global.users_name;

            (database.GetConnection()).Open();

            DataTable current = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * from `duedate` WHERE `duedate_ID` = '1'", database.GetConnection());
            adapt.SelectCommand = command;
            adapt.Fill(current);
            currentDueDate = System.Convert.ToString(current.Rows[0][1].ToString());

            dueDate.InnerText = "Due Date of upload will be in " + currentDueDate;

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
                Response.Redirect("~/userUpload.aspx");
            }

        }

        protected void upload_Click(object sender, EventArgs e)
        {
            bool artical = ArticleID.Text == "" ? true : false;
            string file = Server.MapPath("~/Files/" + global.users_name + "/");
            int dateTimeCompare = DateTime.Compare(Convert.ToDateTime(currentDueDate), DateTime.Now);

            if (files.HasFile && images.HasFile && artical == false && TnC.Checked)
            {

                if (database.checkStudentUploadLimit() == true)
                {
                    if (dateTimeCompare > 0) //due date is earlier then dateTime now
                    {
                        if (System.IO.Directory.Exists(file))
                        {
                            uploadFile(file);
                        }

                        else
                        {
                            string file1 = Server.MapPath("~/Files/");
                            string path = System.IO.Path.Combine(file1, global.users_name);
                            System.IO.Directory.CreateDirectory(path);
                            uploadFile(file);


                        }

                        getEmail mail = new getEmail();

                        try
                        {
                            DataTable table = new DataTable();
                            MySqlDataAdapter adapt = new MySqlDataAdapter();
                            MySqlCommand command = new MySqlCommand("INSERT INTO `image` VALUES ('', @image)", database.GetConnection());
                            command.Parameters.Add("@image", MySqlDbType.VarChar).Value = images.FileName;
                            command.ExecuteNonQuery();

                            int imageId = database.getImage(images.FileName.ToString());
                            int user_Id = global.users_id;
                            string t = DateTime.Now.ToString("yyyy-MM-dd");

                            DataTable table1 = new DataTable();
                            MySqlDataAdapter adapt1 = new MySqlDataAdapter();
                            MySqlCommand command1 = new MySqlCommand("INSERT INTO `article`(`article_ID`, `user_ID`, `image_ID`, `article_title`, `article_description`, `article_date`, `publication`) VALUES ('', @user_id, @image_id, @article_title, @article_desp, @article_date, 'No');", database.GetConnection());
                            command1.Parameters.Add("@user_id", MySqlDbType.Int64).Value = System.Convert.ToInt64(user_Id);
                            command1.Parameters.Add("@image_id", MySqlDbType.Int64).Value = System.Convert.ToInt64(imageId);
                            command1.Parameters.Add("@article_title", MySqlDbType.VarChar).Value = ArticleID.Text;
                            command1.Parameters.Add("@article_desp", MySqlDbType.VarChar).Value = files.FileName;
                            command1.Parameters.Add("@article_date", MySqlDbType.VarChar).Value = t;

                            command1.ExecuteNonQuery();



                        }
                        catch (Exception f)
                        {
                            Response.Write(f.Message);
                        }
                        finally
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Upload Successully!')", true);
                            (database.GetConnection()).Close();
                            mail.uploadEmailing(database.getUserEmailAddress(global.users_id), files.FileName, images.FileName, ArticleID.Text);
                            mail.uploadEmailingCoordinator(database.getCoordinatorEmailAddress(global.facultys_num), files.FileName, images.FileName, ArticleID.Text, database.getStudent_name(global.users_id));
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Artilce has been rejected due to overtime!')", true);
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Submission of article has been reached the limit.')", true);
                }

            }
            else
            {
                if (ArticleID.Text =="")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check on your article name.')", true);                  
                }
                else if (!TnC.Checked)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check on the TnC.')", true);                    
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check on your upload file and image.')", true);
                }
            }
        }

        private void uploadFile(string f)
        {
            images.PostedFile.SaveAs(f + images.FileName);
            files.PostedFile.SaveAs(f + files.FileName);
            Word2Pdf WTP = new Word2Pdf();
            object location = f + files.FileName;
            string fileExtend = Path.GetExtension(files.FileName);
            string changeExtend = (files.FileName).Replace(fileExtend, ".pdf");
            if(fileExtend == ".docx" || fileExtend == ".doc")
            {
                object toLocation = f + changeExtend;
                WTP.InputLocation = location;
                WTP.OutputLocation = toLocation;
                WTP.Word2PdfCOnversion();
                File.Delete(f + files.FileName);

            }
        }
    }
}