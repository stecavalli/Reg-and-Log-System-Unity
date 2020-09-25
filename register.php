<?PHP
      $name = $_POST['name'];
      $username = $_POST['username'];
      $password = $_POST['password'];
      $email = $_POST['email'];

       $mysqli = NEW MySQLi('localhost','root','','test');

       $result1 = $mysqli->query("SELECT * FROM accounts WHERE username = '$username'
		LIMIT 1");  

    if($result1->num_rows == 0)
    {
      $password = md5($password);
      $vkey = md5(time() .$username);
      $insert = $mysqli->query("INSERT INTO `accounts` (`id` , `name` , `username` , `password` , `email`, `vkey`) VALUES ('' , '".$name."' , '".$username."' , '".$password."' , '".$email."', '".$vkey."') ; ");
        if ($insert)
	    {
            die ($vkey);
            
        }else{
                die ("Error: " . mysqli_error());
             }
	}else{
            die("User already exists!");
         }
?>