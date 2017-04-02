using Services.Models;
using System.Net.Mail;

namespace Services.Interfaces
{
    public interface ISendEmailService
    {
        void SendEmail(MailMessage mail);
        string GenerateMailBodyMessageForPictureOrder(string address, string comment, string phone, string fullname, string email);
        string AddPictureInfoToMailBody(string title, string author, string price);
    }
}
