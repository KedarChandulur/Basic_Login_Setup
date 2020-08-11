<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$username = $_POST['name'];
$useremail = $_POST['email'];
$password = $_POST['password'];

$namecheck = mysqli_query($con, "SELECT username FROM login_info_table WHERE username = '" . $username . "'");

  	$res_n = mysqli_query($con, $namecheck);

if(mysqli_num_rows($res_n) > 0)
{
  	  $name_error = "Sorry... name already taken";
}

$emailcheck = mysqli_query($con, "SELECT email FROM login_info_table WHERE email = '" . $useremail . "'");

  	$res_e = mysqli_query($con, $emailcheck);

if(mysqli_num_rows($res_e) > 0)
{
  	  $email_error = "Sorry... email already taken";
}

$salt = "\$5\$rounds=100\$" . $username . "\$";
$hash = crypt($password,$salt);

$insertuserquery = "INSERT INTO login_info_table (username, email, hash, salt) 
VALUES ('" . $username . "', '" . $useremail . "', '" . $hash . "', '" . $salt . "');";

$result = mysqli_query($con,$insertuserquery) or die(mysqli_error($con));

echo "0";

?>