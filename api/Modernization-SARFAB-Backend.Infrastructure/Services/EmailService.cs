using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using Modernization_SARFAB_Backend.Application.Interfaces.Services;
using Modernization_SARFAB_Backend.Infrastructure.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace Modernization_SARFAB_Backend.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettingsOptions)
        {
            _smtpSettings = smtpSettingsOptions.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Soporte", _smtpSettings.Username));
            email.To.Add(new MailboxAddress("", to));
            email.Subject = subject;

            email.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public string GetHtmlTemplate(string templateName, Dictionary<string, string> replacements)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "EmailTemplates");

            string path = Path.Combine(basePath, templateName);

            if (!File.Exists(path))
            {
                Log.Warning("Plantilla de correo no encontrada en: {Path}", path);
                return "<p>Error: La plantilla no fue encontrada.</p>";
            }

            string htmlContent = File.ReadAllText(path);

            foreach (var item in replacements)
            {
                htmlContent = htmlContent.Replace(item.Key, item.Value);
            }

            return htmlContent;
        }
    }
}