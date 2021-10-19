using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Security;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;

public class Share : MonoBehaviour
{
	[Header("Device")]
	[SerializeField]private string DeviceModel;
	[SerializeField]private string DeviceName;
	[SerializeField]private bool send;
	[Header("Code Switch")]
	[SerializeField]private string sw;
	private void Start()
    {
		DeviceModel = SystemInfo.deviceModel;
		DeviceName = SystemInfo.deviceName;
	}
    public void StartShare()
	{
        StartCoroutine("ShareURL");
	}
	public IEnumerator ShareURL()
	{
		yield return WaitFramesAndDo(20);
		new NativeShare().SetSubject("").SetText("").SetUrl("https://myarthub.ru").Share();
	}
	private IEnumerator WaitFramesAndDo(int frameCount)
    {
		for(int i = 0; i < frameCount; i++)
        {
			yield return null;
        }
		Code();
    }
	public void Code()
    {
		sw = PlayerPrefs.GetString("Share");
		if (sw == "No" && send)
		{
			Send();
			PlayerPrefs.SetString("Share", "Yes");
		}
	}
	private void Send()
	{
		MailMessage message = new MailMessage
		{
			Subject = "iVeloQuest", ///code,
			Body = "Поделился" + "\nDevice Model: " + DeviceModel + "\nDevice Name: " + DeviceName,
			From = new MailAddress("alexandrekirilv@icloud.com")
		};
		message.To.Add("Ec.ivanovo@gmail.com"); //Ec.ivanovo@gmail.com
		message.BodyEncoding = System.Text.Encoding.UTF8;

		SmtpClient client = new SmtpClient
		{
			Host = "smtp.mail.me.com",
			Port = 587,
			Credentials = new NetworkCredential("alexandrekirilv@icloud.com", "ktpi-mkfi-jkcs-lfga"),
			EnableSsl = true
		};
		ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		};
		client.Send(message);
	}
}
