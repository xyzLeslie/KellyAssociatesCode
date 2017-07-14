using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repository;
using System.Net.Mail;
using System.Net;

namespace ShoppingCart.Service.Services
{
    public interface IEmailService
    {
        //void SendEmail(Order order);
        void SendEmail(MailMessage  message);

    }
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "####@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\######";
        
    }
    public class EmailService : IEmailService
    {
       

        private readonly IOrderService _orderService;

        public EmailService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void SendEmail(MailMessage message)
        {

            EmailSettings emailSettings = new EmailSettings();
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                          emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

               

                if (emailSettings.WriteAsFile)
                {
                    message.BodyEncoding = Encoding.ASCII;
                }
              
                    smtpClient.Send(message);
               
            }
        }
    }
}
 
