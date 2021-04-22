using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Security;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;

public class Share : MonoBehaviour
{
	[Header("Length")]
	public int len;
	[Header("Code")]
	private int num;
	public string code;
	[Header("Text Area")]
	public Text textArea;
	public GameObject panel;
	[Header("Code Switch")]
	public string sw;
	string[] symbols_a = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
	string[] symbols_A = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "x", "Y", "Z" };
	private void Start()
    {
		//PlayerPrefs.SetString("Share", "No");
		Close();
	}
    public void StartShare()
	{
        StartCoroutine("ShareURL");
		//Code();
	}
	public IEnumerator ShareURL()
	{
		yield return WaitFramesAndDo(20);
		new NativeShare().SetSubject("").SetText("").SetUrl("https://Google.com").Share();
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
		if (sw == "No")
		{
			Generate();
			Send();
			panel.SetActive(true);
			code = PlayerPrefs.GetString("PromoCode");
			PlayerPrefs.SetString("Share", "Yes");
		}
		if (sw == "Yes")
		{
			panel.SetActive(true);
			code = PlayerPrefs.GetString("PromoCode");
		}
		textArea.text = code;
	}
	private void Send()
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
	private void Generate()
	{
		textArea.text = " ";
		code = "";
		for (int i = 0; i < len; i++)
		{
			num = Random.Range(0, 29);
			if(num > 9 && num < 19)
            {
				 code += symbols_a[Random.Range(0, symbols_a.Length)];
			}
			else if (num > 19)
			{
				code += symbols_A[Random.Range(0, symbols_A.Length)];
			}
			else if(num <= 9)
            {
				code += num;
			}
		}
		PlayerPrefs.SetString("PromoCode", code);
	}
	public void Close()
    {
		panel.SetActive(false);
	}
}
