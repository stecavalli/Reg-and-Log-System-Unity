using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Collections;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

public class Main_Menu_Xampp : MonoBehaviour
{
    public Text ipAddressText, usernameText, passwordText, regNameText, regUsernameText, regPassText, regConfPassText, regEmailText;
    public Text ipAddressSaved, messageText, message2Text, loggedText; 
    public GameObject LoginPan, SwitchPan, RegisterPan, IpObj;

    private string ipAddress, username, password, verified;
    private string regName, regUsername, regPass, regConfPass, regEmail;
    private bool check = false;

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            string DomainMapper(Match match)
            {
                var idn = new IdnMapping();

                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
    public bool ValidateIPv4(string ipString)
    {
        if (String.IsNullOrWhiteSpace(ipString))
        {
            return false;
        }

        string[] splitValues = ipString.Split('.');
        if (splitValues.Length != 4)
        {
            return false;
        }

        byte tempForParsing;

        return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }
    private void Start()
    {
        message2Text.text = "";
    }
    public void ipAddressBut()
    {
        ipAddress = ipAddressText.text;
        ipAddressSaved.text = "IP Saved: " + ipAddress;
    }
    public void LoginBut()
    {
        StartCoroutine(LogIn());
    }
    public void RegisterBut()
    {
        StartCoroutine(Register());
    }
    IEnumerator LogIn()
    {
        messageText.text = "";

        username = usernameText.text;
        password = passwordText.text;
        verified = "0";

        if (username == "" || password == "")
            messageText.text = "Please complete all fields.";
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("verified", verified);
            if (ValidateIPv4(ipAddress))
            {
                UnityWebRequest www = UnityWebRequest.Post("http://" + ipAddress + "/register2/login.php", form);

                yield return www.SendWebRequest();

                Debug.Log("Response:" + www.downloadHandler.text);
                message2Text.text = www.downloadHandler.text;
                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    messageText.text = www.error;
                }
                else
                {
                    if (message2Text.text == "The username or password you entered is incorrect")
                    {
                        messageText.text = "The username or password you entered is incorrect";
                    }
                    else if (message2Text.text == "This account not yet been verified.")
                    {
                        messageText.text = "This account not yet been verified.";
                    }
                    else
                    {
                        loggedText.text = "Account logged in:"
                            + "\n " + " " + "\n " + www.downloadHandler.text
                            + "\n " + " " + "\n " + "Your game can start here...";
                        LoginPan.SetActive(false);
                        SwitchPan.SetActive(false);
                        IpObj.SetActive(false);
                        loggedText.gameObject.SetActive(true);
                    }

                }
            }
            else
            {
                messageText.text = "Please enter a valid ip address.";
            }
        }
    }

    IEnumerator Register()
    {
        messageText.text = ""; 
       
        regName = regNameText.text;    
        regUsername = regUsernameText.text;    
        regPass = regPassText.text;    
        regConfPass = regConfPassText.text;    
        regEmail = regEmailText.text;
        if (regName == "" || regUsername == "" || regPass == "" || regConfPass == "" || regEmail == "") 
            messageText.text = "Please complete all fields.";
        else    
        {
            if (ValidateIPv4(ipAddress))
            {
                if (regPass == regConfPass)
                {
                    if (IsValidEmail(regEmail) == true)
                    {
                        WWWForm form = new WWWForm();
                        form.AddField("name", regName);
                        form.AddField("username", regUsername);
                        form.AddField("password", regPass);
                        form.AddField("email", regEmail);
                        UnityWebRequest www = UnityWebRequest.Post("http://" + ipAddress + "/register2/register.php", form);

                        yield return www.SendWebRequest();

                        Debug.Log("Response:" + www.downloadHandler.text);
                        message2Text.text = www.downloadHandler.text;
                        if (www.isNetworkError || www.isHttpError)
                        {
                            Debug.Log(www.error);
                            messageText.text = www.error;
                        }
                        else
                        {
                            if (message2Text.text != "User already exists!")
                            {
                                messageText.text = "Succesfully Created User !" + "\n"
                                    + "Wait, sending email ...";

                                //RegisterPan.SetActive(false);
                                //SwitchPan.SetActive(false);
                                check = true;
                                yield return new WaitForSecondsRealtime(2f);
                                messageText.text = "";
                                if (check == true)
                                {
                                    MailMessage mail = new MailMessage();

                                    mail.From = new MailAddress("YOUR_ACCOUNT_@gmail.com");
                                    mail.To.Add("YOUR_ACCOUNT_@gmail.com");
                                    mail.Subject = "verified email";
                                    mail.IsBodyHtml = true;
                                    mail.Body = "<a href=http://" + ipAddress + "/register2/verify.php?vkey=" + www.downloadHandler.text + "> Register Account</a>";
                                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                                    smtpServer.Port = 587;
                                    smtpServer.Credentials = new System.Net.NetworkCredential("YOUR_ACCOUNT_@gmail.com", "YOUR_PASSWORD_GMAIL") as ICredentialsByHost;
                                    smtpServer.EnableSsl = true;
                                    ServicePointManager.ServerCertificateValidationCallback =
                                        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                        { return true; };
                                    smtpServer.Send(mail);
                                    Debug.Log("Verification email sent successfully ...");
                                    messageText.text = "Verification email sent successfully ...";
                                    check = false;
                                }
                            }
                            else if (message2Text.text == "User already exists!")
                            {
                                messageText.text = "User already exists!";
                            }
                        }
                    }
                    else
                    {
                        messageText.text = "Please enter a valid email address !";
                    }

                }
                else
                    messageText.text = "Your passwords do not match.";
            }
            else
            {
                messageText.text = "Please enter a valid ip address.";
            }
        }
    }
}

