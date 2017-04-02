using Services.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace Services.Services
{
    public class SendEmailService : ISendEmailService
    {
        private const string mailBody = "<h1>New Order</h1> <p><b> Email:</b> {0}</p> <p><b> Name:</b> {1}</p> <p><b>Address: </b>{2}</p> <p><b>Phone: </b>{3}</p> <p><b>Comment:</b> {4}</p> <hr/><p><b>Pictures:</b></p>";
        private const string mailBodyPartPictureInfo = "<p><b>Picture title:</b> {0}; <b>Author:</b> {1}; <b>Price:</b> {2}</p>";

        public void SendEmail(MailMessage mail)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("artcentervagabond@gmail.com", "Vagabond123"),
                EnableSsl = true
            };

            client.Send(mail);
        }

        public string GenerateMailBodyMessageForPictureOrder(string address, string comment, string phone, string fullname, string email)
        {
            return String.Format(mailBody,email, fullname, address, phone, comment);
        }

        public string AddPictureInfoToMailBody(string title, string author, string price)
        {
            return String.Format(mailBodyPartPictureInfo, title, author, price);
        }

    }
}
