using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;


namespace TechnicalService.Models
{

    public class Utilities
    {
        //// Generate random Number
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public string ConvertDecimalDateToString(string strDate)
        {
            string outputDate = "1900-01-01";
            if (strDate.Length < 8)
            {
                return outputDate;
            }
            else
            {
                //string outputDate = Convert.ToString(strDate.Substring(4, 2) + "/" + strDate.Substring(5, 2) + "/" + strDate.Substring(0, 4));
                //return outputDate;

                outputDate = Convert.ToString(strDate.Substring(0, 4) + "-" + strDate.Substring(4, 2) + "-" + strDate.Substring(6, 2));
                return outputDate;
            }
        }

        public static string encrypt(string get_value)
        {
            int i, j, ni, nj;
            string ls_enctext = "";
            const string CRYPT_KEY = "$#@%&#%@&*";

            j = get_value.Length;
            for (i = 1; i <= j; i++)
            {
                ls_enctext += CRYPT_KEY.Substring((i / 10) + 1, 1);

                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(get_value.Substring(i, 1));
                ni = Convert.ToInt32(b);
                nj = 255 - ni;
                ls_enctext += nj.ToString();
            }

            return ls_enctext;

        }

        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        //// Generate Local Date Time
        public static DateTime GetLocalDateTime()
        {
            DateTime serverTime = DateTime.Now;

            // gives you current Time in server timeZone

            DateTime utcTime = serverTime.ToUniversalTime();

            // convert it to Utc using timezone setting of server computer

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");

            // convert from utc to local
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            return localTime;
        }

        ////send message on mobile number
        public static String SMSPcode(string mobile_no, string msg)
        {
            String url = "http://my.ezeee.pk/sendsms_url.html?";
            String result = "";
            String message = HttpUtility.UrlEncode(msg);
            String strPost = "Username=03351999555&Password=@03351999555&From=ZASA&To=" + mobile_no + "&Message=" + message;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(strPost);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }

        ////email OTP
        public static String EmailPcode(string member_email, string name, int otp)
        {
            try
            {
                // Command line argument must the the SMTP host.
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = "loyaltybunch.com";
                client.EnableSsl = false;
                client.Timeout = 30000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("support@loyaltybunch.com", "#LoyaltyBunch8080");

                string htmlBody = "<html><body><img  src='http://loyaltybunch.com/logos/logo_only.png' height='90' width='100'/><br/><p>Dear " + name + ",<br/>" + "Welcome to Mujer community.<br/><b>Your PIN CODE to register is " + otp + "</b>.<br/>We hope that you enjoy our services.<br/>Regards,<br/>Mujer team</body></html>";

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

                //FileStream fileToStream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/images/logo.jpg"), FileMode.Open, FileAccess.Read);
                MailMessage mm = new MailMessage();
                MailAddress sFrom = new MailAddress("support@loyaltybunch.com");
                MailAddress sTo = new MailAddress(member_email);
                mm.From = sFrom;
                mm.To.Add(sTo);
                mm.Subject = "Loyalty Bunch OTP";
                mm.AlternateViews.Add(avHtml);

                mm.Body = String.Format(
                           htmlBody);

                mm.IsBodyHtml = true;

                // mm = new MailMessage("support@mujer.pk", member_email, "OTP-Mujer", msg);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch (SmtpException ex)
            {
                return ex.Message;
            }
            catch (ArgumentNullException ex) { ex.ToString(); }
            catch (InvalidOperationException ex) { ex.ToString(); }
            return "done";

        }

        public static String SendEmail(string to_email, string msg_subject, string msg_body)
        {
            try
            {

                String from = "noreply@awazigargashae.com"; //example:- sourabh9303@gmail.com
                string Rno = Utilities.RandomString(4);
                                
                using (MailMessage mail = new MailMessage(from, to_email))
                {
                    mail.Subject = msg_subject;
                    mail.Body = msg_body;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "mail.awazigargashae.com"; // from local testing 
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "&_jnGx4308McXY");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 26;
                    smtp.Send(mail);
                }

                return "Email Sent Successfully!";
            }
            catch (Exception e)
            {
                return "Something went wrong. " + e.ToString(); 
            }
        }
    }
}