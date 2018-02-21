using System.Collections.Generic;
using System.Net.Mail;

namespace FrameworkCommon.Toolbox
{
    public class EmailUtils
    {
        /// <summary>
        /// Sends the specified message to an SMTP server for delivery.
        /// </summary>
        /// <param name="host">The SMTP server.</param>
        /// <param name="fromEmailAddress">The email address to send the email from.</param>
        /// <param name="toEmailAddresses">List of email addresses to send email to.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="isBodyHtml">Flag to set email body as HTML content.</param>
        /// <param name="body">The content of the email body.</param>
        /// <param name="attachmentPaths">(Optional) File path(s) for the email attachment(s).</param>
        /// <returns>Flag is the email was sent.</returns>
        public static bool SendEmail(string host, string fromEmailAddress, List<string> toEmailAddresses, string subject, bool isBodyHtml, string body, List<string> attachmentPaths = null)
        {
            bool success = true;
            try
            {
                // Create a MailMessage
                MailMessage message = new MailMessage();
                // Define the email's Subject
                message.Subject = subject;
                // Define the email's To
                message.From = new MailAddress(fromEmailAddress);
                foreach (string emailAddress in toEmailAddresses)
                {
                    message.To.Add(new MailAddress(emailAddress));
                }
                // Define the email's body content type
                message.IsBodyHtml = isBodyHtml;
                // Define the email's body
                message.Body = body;
                // Add attachement(s)
                if (attachmentPaths != null)
                {
                    foreach (string attachmentPath in attachmentPaths)
                    {
                        Attachment attachment = new Attachment(attachmentPath);
                        message.Attachments.Add(attachment);
                    }
                }
                // Define the SMTP host
                SmtpClient smtp = new SmtpClient(host);
                // Send the SMTP message
                smtp.Send(message);
            }
            catch
            {
                // There was an error sending the email
                success = false;
            }
            return success;
        }
    }
}
