using UnityEngine;
using System.Net.Security;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;

public class SendCode : MonoBehaviour
{
    [Header("Code")]
    public string code;
    public void Send()
    {
        MailMessage message = new MailMessage
        {
            Body = "Промокод: " + code,
            From = new MailAddress("alexandrekirilv@icloud.com")
        };
        message.To.Add("alexandrekirilv@icloud.com");
        message.BodyEncoding = System.Text.Encoding.UTF8;

        SmtpClient client = new SmtpClient
        {
            Host = "smtp.mail.me.com",
            Port = 587,
            Credentials = new NetworkCredential("alexandrekirilv@icloud.com", "xhny-jvbs-hgxa-cllr"),
            EnableSsl = true
        };
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        client.Send(message);
    }
}
