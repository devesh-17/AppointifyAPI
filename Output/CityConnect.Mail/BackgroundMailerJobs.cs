using CityConnect.Interfaces.Background;
using CityConnect.Mail.Models;

namespace CityConnect.Mail
{
    public class BackgroundMailerJobs : IBackgroundMailerJobs
    {
        #region Properties

        //ToDo for add mail history
        //private readonly IMailHistoryService _mailHistoryService;
        private static readonly object MailServiceLock = new object();

        #endregion Properties

        #region Constructor

        public BackgroundMailerJobs()
        {
            //_mailHistoryService = mailHistoryService;
        }

        #endregion Constructor

        public void SendWelcomeEmail()
        {
            var welcomeEmailModel = new WelcomeEmail
            {
                RecipientMail = "krunal.ifour@gmail.com",
                DisplayName = "Krunal" + " " + "Patel",
            };
            var mail = new Mail<WelcomeEmail>("WelcomeEmail", welcomeEmailModel);
            lock (MailServiceLock)
            {
                var sentMailData = mail.Send(welcomeEmailModel.RecipientMail, "Welcome to iFour network");
                //_mailHistoryService.InsertMailHistory(sentMailData.To.ToString(), sentMailData.Subject, sentMailData.Body, MailTypeEnum.Registration.ToString());
            }
        }
    }
}