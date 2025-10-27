using DnsClient;
using System;
using System.Net.Mail;
using DnsClient.Protocol;
using System.Linq;

namespace EmailValidator
{
    public class EmailValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public CheckResult Validate(string email)
        {
            var result = new CheckResult();
            if (string.IsNullOrWhiteSpace(email))
            {
                result.Msg = "Email is Empty";
                return result;
            }

            email = email.Trim();
             
            var mailAddress = new MailAddress(email);

            var options = new LookupClientOptions()
            {
                UseCache = true,
                MinimumCacheTimeout = TimeSpan.FromSeconds(30)
            };
            var dnsClient = new LookupClient(options);
            try
            {
                var mxRecords = dnsClient.Query(mailAddress.Host, QueryType.MX)
                                  .Answers
                                  .MxRecords()
                                  .ToList();

                if (mxRecords.Count == 0)
                {
                    result.Code = SmtpStatusCode.MailboxUnavailable;
                    result.Msg = "No email on the domain";
                }

                foreach (MxRecord mxRecord in mxRecords)
                {
                    try
                    {
                        var smtpClient = new SmtpClient(mxRecord.Exchange.Value);
                        var response = smtpClient.CheckMailboxExists(email);
                        var state = response.Code == SmtpStatusCode.Ok || response.Code == SmtpStatusCode.ServiceClosingTransmissionChannel;
                        result.Msg = state ? string.Empty : response.Raw;
                        result.Code = response.Code;
                        result.IsValid = state ? true : false;
                        return result;
                    }
                    catch (SmtpClientException ex)
                    {
                        result.Msg = ex.Message;
                        break;
                    }
                    catch (ArgumentNullException ex)
                    {
                        result.Msg = ex.Message;
                    }
                }

                if (mxRecords.Count > 0)
                {
                    result.Msg = "The SMTP service is not available";
                    result.Code = SmtpStatusCode.ServiceNotAvailable;
                    return result;
                }
                result.Code = SmtpStatusCode.GeneralFailure;
                return result;
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.Code = SmtpStatusCode.GeneralFailure;
                return result;
            }

        }
    }
}
