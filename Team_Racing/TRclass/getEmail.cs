using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using TeamRacing;
using System.Security.Cryptography;

namespace Team_Racing
{
    public class getEmail
    {
        public void uploadEmailing(string emailaddress, string article, string image, string article_name)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("trelloewsd@gmail.com");
                mail.To.Add(emailaddress);
                mail.Subject = "Article Uploaded";

                string body = ("Your article was received!"                       + Environment.NewLine +
                                                                               "" + Environment.NewLine
                                                                                  + Environment.NewLine +
                               "Here is your article details:"                    + Environment.NewLine +
                               "Name of article     : " + article_name            + Environment.NewLine +
                               "Name of file        : " + article                 + Environment.NewLine +
                               "Name of Image file  : " + image                   + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Thank you," + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Best Regards" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Celtic University" + Environment.NewLine +
                               "-------------------------------------------------" + Environment.NewLine +
                                                                                    Environment.NewLine +
                               "Tel No : " + Environment.NewLine + "+603-33249914" + Environment.NewLine + "+60 14-343 5109 (Mr.Liew)");


                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("trelloewsd@gmail.com", "ewsd1234");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
        }

        public void uploadEmailingCoordinator(string emailaddress, string article, string image, string article_name, string studentName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("trelloewsd@gmail.com");
                mail.To.Add(emailaddress);
                mail.Subject = "Article Uploaded";

                string body = (studentName + "'s article was uploaded!"           + Environment.NewLine +
                                                                               "" + Environment.NewLine
                                                                                  + Environment.NewLine +
                               "Here is " +studentName+ "'s article details:"     + Environment.NewLine +
                               "Name of article     : " + article_name            + Environment.NewLine +
                               "Name of file        : " + article                 + Environment.NewLine +
                               "Name of Image file  : " + image                   + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Thank you," + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Best Regards" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Celtic University" + Environment.NewLine +
                               "-------------------------------------------------" + Environment.NewLine +
                                                                                    Environment.NewLine +
                               "Tel No : " + Environment.NewLine + "+603-33249914" + Environment.NewLine + "+60 14-343 5109 (Mr.Liew)");


                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("trelloewsd@gmail.com", "ewsd1234");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
        }

        public void registrationEmailing(string emailaddress, string name, string username, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("trelloewsd@gmail.com");
                mail.To.Add(emailaddress);
                mail.Subject = "Celtic University: Registration";

                string body = ("Your account has been registered successfully!"   + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Hi " + name + ","                                 + Environment.NewLine 
                                                                                  + Environment.NewLine +
                               "Here is your account details :"                   + Environment.NewLine +
                               "Username : " + username                           + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Password : " + password                           + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Thank you,"                                       + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Best Regards"                                     + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                                                                               "" + Environment.NewLine +
                               "Celtic University"                                + Environment.NewLine +
                               "-------------------------------------------------" + Environment.NewLine +
                                                                                    Environment.NewLine +
                               "Tel No : " + Environment.NewLine + "+603-33249914" + Environment.NewLine + "+60 14-343 5109 (Mr.Liew)");


                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("trelloewsd@gmail.com", "ewsd1234");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
        }
    }
}