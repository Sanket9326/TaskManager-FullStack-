using System.Net;
using System.Net.Mail;
using TaskManagerBackend.Data.DataDbContext;
using TaskManagerBackend.Services.IServices;

namespace TaskManagerBackend.Services.Service
{
    public class MailService : IMailService
    {
        public UserDbContext _context;

        public MailService(UserDbContext context)
        {
            _context = context;
        }

        public bool passwordRecovery(string username, string password)
        {
            try
            {
                var message = new MailMessage();
                message.Subject = "Task Manager Password Recovery";
                message.From = new MailAddress("TaskManager@gmail.com");
                message.To.Add(username);
                message.Body = "Hello, \n\n" +
               "Welcome to TaskManager! We're excited to have you on board. \n\n" +
               "Your password has been successfully created. Please find it below: \n\n" +
               "Password: " + password + "\n\n" +
               "For your security, please do not share your password with anyone. If you have any questions, feel free to reach out to us.\n\n" +
               "Best regards, \n" +
               "The TaskManager Team";

                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("sawantsanket640@gmail.com", "zarm gxrt exup dkiq"),
                    EnableSsl = true
                };

                smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
