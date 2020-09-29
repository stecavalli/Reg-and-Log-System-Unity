# Reg-and-Log-System
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
put inside the login.php, register.php and verify.php files you find in the list above.
 <br>
 <br>
Replace the php.ini file in the C:\xampp\php\ folder with the php.ini found in the list above.
 <br>
Edit the line:
 <br>
sendmail_from = YOUR ACCOUNT @gmail.com
 <br>
by entering your Google mail address.
 <br>
 <br>
Replace the sendmail.ini file in the C:\xampp\sendmail\ folder with the sendmail.ini found in the list above.
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
Use the SQL code you find here to create the "accounts" table in the "test" database.
 # Unity configuration
Create a new project in Unity and import the package:
- RegLogSystem.unitypackage
found in the list above.
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
