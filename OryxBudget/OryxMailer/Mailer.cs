using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.Extensions.Logging;

namespace OryxMailer
{
    public class Mailer
    {
        private DefaultSenderOptions m_options;
        //private TextPart m_TextPart;
        //private string m_Subject;
        private ILogger<Mailer> m_logger;
        public Mailer (DefaultSenderOptions Options, ILogger<Mailer> Logger)
        {
            m_options = Options;
            m_logger = Logger;
        }

        public async Task SendEmailAsync( SendMailOptions opt)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(opt.EmailToName, opt.EmailToAddress));
            message.From.Add(new MailboxAddress(m_options.SenderName, m_options.SenderUserName));
            message.Subject = opt.Subject;

            message.Body = new TextPart(opt.MailType)
            {
                Text = @opt.Body
            };

            await SendMessageAsync(message);
        }

        public void SendEmail(SendMailOptions opt)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(opt.EmailToName, opt.EmailToAddress));
            message.From.Add(new MailboxAddress(m_options.SenderName, m_options.SenderUserName));
            message.Subject = opt.Subject;
            if (opt.HtmlBody != null)
            {
                message.Body = opt.HtmlBody;
            }
            else
            {
                message.Body = new TextPart(opt.MailType)
                {
                    Text = @opt.Body
                };
            }

           

            SendMessage(message);
        }

        private void SendMessage(MimeMessage msg)
        {
            
            {
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    

                    client.Connect(m_options.ServerAddress, m_options.ServerPort, m_options.SecureOption);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    if (!m_options.AddOAUTH)
                    {
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                    }

                    //await client.AuthenticateAsync(m_options.SenderUserName, m_options.SenderPassword);
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(m_options.SenderUserName, m_options.SenderPassword);

                    client.Send(msg);
                    m_logger.LogInformation($"Email Sent", msg);
                    client.Disconnect(true);
                }
            }
            
        }


        private async Task SendMessageAsync(MimeMessage msg)
        {
            //try
            {
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;


                    await client.ConnectAsync(m_options.ServerAddress, m_options.ServerPort, m_options.SecureOption);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    if (!m_options.AddOAUTH)
                    {
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                    }

                    //await client.AuthenticateAsync(m_options.SenderUserName, m_options.SenderPassword);
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(m_options.SenderUserName, m_options.SenderPassword);

                    await client.SendAsync(msg);
                    m_logger.LogInformation($"Email Sent", msg);
                    await client.DisconnectAsync(true);
                }
            }
            //catch (Exception ex)
            //{
            //    m_logger.LogError($"Failed to send email", ex);
            //}
        }


    }
}
