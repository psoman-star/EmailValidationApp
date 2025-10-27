using System.Net.Mail;

namespace EmailValidator
{

    public class CheckResult
    {

        public bool IsValid { get; set; }

        public SmtpStatusCode Code { get; set; }
        public string Msg { get; set; }

        public CheckResult()
        {
            IsValid = false;
            Code = SmtpStatusCode.MailboxNameNotAllowed;
        }
    }
}
