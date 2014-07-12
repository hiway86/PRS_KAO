#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Util\Email.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073C8567B00A047C6074A10A9C92CB3DE826DEA3"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Util\Email.cs"
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;

/// <summary>
/// Email 的摘要描述
/// </summary>
public class Email
{

    private string smtp = "";  //smtp host
    private string msg = "";
    private string[] emailAddress ;
    private string title = ""; //標題
    private MailMessage mail = new MailMessage();
    private string senderName = ""; //寄件者名稱
    private string senderEmailAddress = "";  //寄件者email
    SmtpClient smtpClient = new SmtpClient();


	public Email()
	{
        smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["MailStmpHost"];
        smtpClient.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MailStmpPort"]);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = true;
        string mailid = System.Configuration.ConfigurationManager.AppSettings["MailAddress"];
        string passwd = System.Configuration.ConfigurationManager.AppSettings["MailPassword"];
        smtpClient.Credentials = new System.Net.NetworkCredential(mailid, passwd);
	}

    public bool toSend(string title, string[] emailAddress, string msg)
    { 
        this.title = title;
        this.emailAddress = emailAddress;
        this.msg = msg;
        bool b = false;

        try
        {
            //if ( senderEmailAddress.Length == 0)
            //{
            //    return false;
            //}

            string sendAddress = System.Configuration.ConfigurationManager.AppSettings["MailAddress"];
            //寄件者
            mail.From = new MailAddress(sendAddress);
            //給收件者
            for (int i = 0; i < emailAddress.Length; i++)
            {
                mail.To.Add(emailAddress[i]);
            }
            //主旨
            mail.Subject = title;
            mail.SubjectEncoding = Encoding.UTF8;
            //內容
            mail.Body = msg;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.Normal;
            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            AlternateView alternate = AlternateView.CreateAlternateViewFromString(msg, mimeType);
            mail.AlternateViews.Add(alternate);

            

            //寄信
           
            smtpClient.Send(mail);

            b = true;
        }
        catch (Exception e)
        {

        }
        return b;
    }






}


#line default
#line hidden
