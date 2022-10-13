namespace Cooperchip.ITDeveloper.Mvc.ServiceApp.Settings
{
    public class EmailCredentialsSettings
    {
        public const string SectionName = nameof(EmailCredentialsSettings);

        public string EmailSender { get; set; }
        public string EmailPassword { get; set; }   
        // smtp: smtp.gmail.com.br
        // port: 587
    }
}
