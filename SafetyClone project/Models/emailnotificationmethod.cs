//using System;
//using System.Net;
//using System.Net.Mail;


//namespace SafetyClone_project.Models
//{



//    public class Program

//    {
//        static void Main(string[] args)
//        {
//            string receiverEmail = "recipient@email.com";
//            string message = "This is a test email";

//            SendEmail(receiverEmail, message);
//        }

//        static void SendEmail(string receiverEmail, string message)
//        {
//            MailMessage mailMessage = new MailMessage();
//            mailMessage.From = new MailAddress("email@mywebsitedomain.com");
//            mailMessage.To.Add(receiverEmail);
//            mailMessage.Subject = "Subject";
//            mailMessage.Body = message;

//            SmtpClient smtpClient = new SmtpClient();
//            smtpClient.Host = "smtp.mywebsitedomain.com";
//            smtpClient.Port = 587;
//            smtpClient.UseDefaultCredentials = false;
//            smtpClient.Credentials = new NetworkCredential("username", "password");
//            smtpClient.EnableSsl = true;

//            try
//            {
//                smtpClient.Send(mailMessage);
//                Console.WriteLine("Email Sent Successfully.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }
//    }
//}
