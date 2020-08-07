<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$useremail = $_POST['email'];
$password = $_POST['password'];

$emailcheck = mysqli_query($con, "SELECT * FROM login_info_table WHERE email = '".$useremail."'") or exit(mysqli_error($con));

  	$res_e = mysqli_query($con, $emailcheck);

if(mysqli_num_rows($res_e) > 0)
{
  	  $email_error = "Sorry... email already taken"; 	
}

$salt = "\$5\$rounds=5000\$" . "steamedhams" . $useremail . "\$";
$hash = crypt($password,$salt);
$insertuserquery = "INSERT INTO login_info_table (email, hash , salt) VALUES ('" . $useremail . "', '" . $hash. "', '" . $salt. "');";
mysqli_query($con,$insertuserquery) or die("4: insert failed" . mysqli_error());

echo "0";

?>