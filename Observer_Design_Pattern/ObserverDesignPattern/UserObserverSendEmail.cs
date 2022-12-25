using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using Observer_Design_Pattern.DAL.Entities;
using System;


namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverSendEmail:IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();



            MimeMessage mimeMessage = new MimeMessage();



            //wwzcmzrgscgqcvyo
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "projecore01@gmail.com");
            mimeMessage.From.Add(mailboxAddress);



            MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
            mimeMessage.To.Add(mailboxAddressTo);



            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Observer Design Pattern İndirim Mailidir, indirim oranınız %15 olarak belirlendi, indirim kodunuz: GAZIANTEP27";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Example Market İndirim";



            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("projecore01@gmail.com", "wwzcmzrgscgqcvyo");
            client.Send(mimeMessage);
            client.Disconnect(true);



            logger.LogInformation($" {appUser.Name + " " + appUser.Surname} isimli kullanıcıya indirim maili atıldı");



        }
    }
}
