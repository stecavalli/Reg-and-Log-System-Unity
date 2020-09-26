# Reg-and-Log-System
Registration and Login System
 <br>
 <br>
This is a simple user registration and login system for Unity3D, Xampp, Google Mail for Android Device.
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
put inside the login.php, register.php and verify.php files you find here.
 <br>
 <br>
Replace the php.ini file in the C:\xampp\php\ folder with the php.ini found here.
 <br>
Edit the line:
 <br>
sendmail_from = YOUR ACCOUNT @gmail.com
 <br>
by entering your Google mail address.
 <br>
 <br>
Replace the sendmail.ini file in the C:\xampp\sendmail\ folder with the sendmail.ini found here.
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
 <br>
The XAMPP configuration is finished.
 # Unity configuration
Create a new project in unity and import the package from Unity Asset Store at this link:
 <br>
 <br>
https://assetstore.unity.com/packages/slug/179864
 # Google Chrome configuration
Turning on 'less secure apps' settings as mailbox user.
 <br>
 <br>
Go to https://myaccount.google.com/
 <br>
 <br>
On the left navigation panel, click Security.
 <br>
 <br>
On the bottom of the page, in the Less secure app access panel, click Turn on access.
 <br>
 <br>
If you don't see this setting, You need to set "Two-Step Verification" to "Not active".
 <br>
 <br>
In the subwindow, Set radio button to On.
 <br>
 <br>
Remember to reset the radio button to Off
 <br>
 <br>
when you are not using sending email from the application.
