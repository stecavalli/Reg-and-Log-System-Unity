# Reg and Log System
Registration and Login System
 <br>
 <br>
This simple user registration and login system for Android Device was created
 <br>
to test the sending E-Mail from Unity using Xampp and Google Mail.
 <br>
This example can be applied on a hosting site with PhpMyAdmin, MySQL and the
 <br>
Sendmail function with some changes to the C# code in Unity and the
 <br>
Php codes uploaded to the server.
 <br>
 <br>
Software Versions Used:
 <br>
XAMPP for Windows 7.4.10
 <br>
Unity 2020.1.6f1
 <br>
Google Chrome
# Xampp configuration
Install XAMPP in the path C:\xampp.
 <br>
Create a new folder called register2 in C:\xampp\htdocs\ and
 <br>
put inside the <i>login.php</i>, <i>register.php</i> and <i>verify.php</i> files you find in the list above.
 <br>
 <br>
Replace the <i>php.ini</i> file in the C:\xampp\php\ folder with the <i>php.ini</i> file found in the list above.
 <br>
Edit the line:
 <br>
sendmail_from = YOUR ACCOUNT @gmail.com
 <br>
by entering your Google mail address.
 <br>
 <br>
Replace the <i>sendmail.ini</i> file in the C:\xampp\sendmail\ folder with the <i>sendmail.ini</i> file found in the list above.
 <br>
Edit the lines:
 <br>
auth_username=YOUR ACCOUNT @gmail.com
 <br>
auth_password = YOUR PASSWORD ACCOUNT
 <br>
with your Google mail data.
 <br>
 <br>
Use the <i>SQL code</i> you find in the list above to create the "accounts" table in the "test" database.
 # Unity configuration
Create a new project in Unity and import the package <i>RegLogSystem.unitypackage</i> found in the list above.
<br>
Open the <i>Main_Menu_Xampp.cs</i> file with Visual Studio and change the line of code 
 <br>
 <br>
smtpServer.Credentials = new System.Net.NetworkCredential ("YOUR_ACCOUNT_@gmail.com", "YOUR_PASSWORD_GMAIL") as ICredentialsByHost; 
 <br>
 <br>
by entering your Gmail account credentials
 # Google Chrome configuration
Turning on 'less secure apps' settings as mailbox user.
 <br>
- Go to https://myaccount.google.com/
- On the left navigation panel, click Security.
- On the bottom of the page, in the Less secure app access panel, click Turn on access.
- In the subwindow, Set radio button to On.
- If you don't see the Less secure app access panel, You need to set "Two-Step Verification" to "Not active".
- Remember to reset the radio button to Off when you are not using sending email from the application.
 # Credits
https://stecavalli.altervista.org/
 <br>
https://stecavalli.altervista.org/xampp-php-mysql-unity/
