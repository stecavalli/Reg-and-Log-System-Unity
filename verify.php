<?php
if(isset($_GET['vkey'])){
	//Process Verification
	$vkey = $_GET['vkey'];
    
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "test";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
      
$sql = "UPDATE accounts SET verified = 1 WHERE vkey = '$vkey' LIMIT 1";

if ($conn->query($sql) === TRUE) {
  echo "Record verified successfully";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}
}
$conn->close();
?>