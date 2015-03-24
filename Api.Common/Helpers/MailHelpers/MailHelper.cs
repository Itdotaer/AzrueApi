// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The mail helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace API.Common.Helpers.MailHelpers
{
    using System.Net.Mail;
    using System.Threading.Tasks;

    using API.Common.Configs;

    /// <summary>
    /// The mail helper.
    /// </summary>
    public class MailHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// The send mail.
        /// </summary>
        /// <param name="mailTo">
        /// The mail to.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="mailFrom">
        /// The mail from.
        /// </param>
        /// <param name="ccTo">
        /// The cc to.
        /// </param>
        /// <param name="isBodyHtml">
        /// The is body html.
        /// </param>
        public static void SendMail(string mailTo, string title, string content, string mailFrom = null, string ccTo = null, bool isBodyHtml = true)
        {
            mailFrom = string.IsNullOrEmpty(mailFrom) ? BlobPortalConfig.MailFrom : mailFrom;

            using (var msg = new MailMessage(mailFrom, mailTo, title, content))
            {
                msg.IsBodyHtml = isBodyHtml;
                if (!string.IsNullOrEmpty(ccTo))
                {
                    msg.CC.Add(new MailAddress(ccTo));
                }

                using (var smtp = new SmtpClient(BlobPortalConfig.SmtpHost))
                {
                    smtp.UseDefaultCredentials = true;
                    smtp.Send(msg);
                }
            }
        }

        public static async Task SendMailAsync(string mailTo, string title, string content, string mailFrom = null, string ccTo = null, bool isBodyHtml = true)
        {
            mailFrom = string.IsNullOrEmpty(mailFrom) ? BlobPortalConfig.MailFrom : mailFrom;

            using (var msg = new MailMessage(mailFrom, mailTo, title, content))
            {
                msg.IsBodyHtml = isBodyHtml;
                if (!string.IsNullOrEmpty(ccTo))
                {
                    msg.CC.Add(new MailAddress(ccTo));
                }

                using (var smtp = new SmtpClient(BlobPortalConfig.SmtpHost))
                {
                    smtp.UseDefaultCredentials = true;
                    await smtp.SendMailAsync(msg);
                }
            }
        }

        #endregion
    }
}