using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Security;
using MimeKit;

namespace OryxMailer
{
    public class DefaultSenderOptions
    {
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public SecureSocketOptions SecureOption { get; set; }
        public string SenderUserName { get; set; }
        public string SenderPassword { get; set; }
        public string SenderName { get; set; }
        public bool AddOAUTH { get; set; }
    }

    public class SendMailOptions
    {
        public string EmailToName { get;  set; }
        public string EmailToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailType { get; set; }
        public MimeEntity HtmlBody { get; set; }
    }

    
}
