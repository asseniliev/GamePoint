using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using MatchScore.Web.Helpers.Args;

namespace MatchScore.Web.Helpers
{
    public class EmailHelper
    {
        public EmailHelper()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }

        public void OnRequestProcessed(object source, RequestProcessArgs args)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("gamepoint@abv.bg"),
                Subject = "Game Point Request",
                Body = $"Your {args.Request.RequestType} request has been {args.Request.RequestStatus}!",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(args.Request.User.Email));

            SmtpClient smtpClinet = new SmtpClient
            {
                Host = "in-v3.mailjet.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("575c5f4a8b51f0a60d6974207edba6b2", "d69c10a587832bb2005973786c99d2c1"),
                EnableSsl = true,
            };

            smtpClinet.Send(mailMessage);
        }

        public void OnPlayerAdded(object source, PlayerAddArgs args)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("gamepoint@abv.bg"),
                Subject = "Player added to Event",
                Body = $"Your player profile {args.Player.Name} has been added to event {args.@event.Title}!",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(args.User.Email));

            SmtpClient smtpClinet = new SmtpClient
            {
                Host = "in-v3.mailjet.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("575c5f4a8b51f0a60d6974207edba6b2", "d69c10a587832bb2005973786c99d2c1"),
                EnableSsl = true,
            };

            smtpClinet.Send(mailMessage);
        }

        public void OnPlayerRemoved(object source, PlayerRemoveArgs args)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("gamepoint@abv.bg"),
                Subject = "Player removed from Event",
                Body = $"Your player profile {args.Player.Name} has been removed from event {args.@event.Title}!",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(args.User.Email));

            SmtpClient smtpClinet = new SmtpClient
            {
                Host = "in-v3.mailjet.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("575c5f4a8b51f0a60d6974207edba6b2", "d69c10a587832bb2005973786c99d2c1"),
                EnableSsl = true,
            };

            smtpClinet.Send(mailMessage);
        }

        public void OnPlayerAddedToMatch(object source, PlayerAddToMatchArgs args)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("gamepoint@abv.bg"),
                Subject = "Player added to Match",
                Body = $"Your player profile {args.Player.Name} has been added to a match in event {args.@event.Title}!",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(args.User.Email));

            SmtpClient smtpClinet = new SmtpClient
            {
                Host = "in-v3.mailjet.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("575c5f4a8b51f0a60d6974207edba6b2", "d69c10a587832bb2005973786c99d2c1"),
                EnableSsl = true,
            };

            smtpClinet.Send(mailMessage);
        }

        public void OnMatchUpdated(object source, MatchUpdatedArgs args)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("gamepoint@abv.bg"),
                Subject = "Match changed",
                Body = $"The match for player profile {args.User.Player.Name} in event {args.Event.Title} has been changed!",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(args.User.Email));

            SmtpClient smtpClinet = new SmtpClient
            {
                Host = "in-v3.mailjet.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("575c5f4a8b51f0a60d6974207edba6b2", "d69c10a587832bb2005973786c99d2c1"),
                EnableSsl = true,
            };

            smtpClinet.Send(mailMessage);
        }
    }
}
