<?PHP 
        $username = $_POST['username'];
        $password = $_POST['password'];
		$mysqli = NEW MySQLi('localhost','root','','test');
		
		$password = md5($password);
		
		//Query the database
		$resultset = $mysqli->query("SELECT * FROM accounts WHERE username = '$username' AND
		password = '$password' LIMIT 1");
		
		if($resultset->num_rows != 0){
			//Process login
			$row = $resultset->fetch_assoc();
			$verified  = $row['verified'];
			$email = $row['email'];
		    $date = $row['registration_date'];
			$date = strtotime($date);
			$date = date('M d Y',$date);
			
			if($verified == 1 ){
				//Continue processing
				//die("Your account is verified and you have been logged in");
				
				echo "ID: " . $row["id"]. 
                     "\r\n" . " Name: " . $row["name"]. 
					 "\r\n" . " Username: " . $row["username"]. 
                     "\r\n" . " Email: " . $row["email"].
                     "\r\n" . " Registration date: " . $date. "\r\n";
			}else{
				die ("This account not yet been verified.");
				//die ("An email was sent to $email on $date");
			}
		}else{
			//Invalid credentials
			die("The username or password you entered is incorrect");
		}
?>