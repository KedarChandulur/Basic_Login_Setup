<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$useremail = $_POST['email'];
$password = $_POST['password'];

$emailcheckquery = "SELECT email,salt,hash,score FROM login_info_table WHERE email = '". $useremail ."';";

  	$emailcheck = mysqli_query($con, $emailcheckquery);

if(mysqli_num_rows($emailcheck) < 0)
{
	echo "Less than one Name Found \t";
	exit();
}
elseif (mysqli_num_rows($emailcheck) > 1) 
{
	echo "Less than one Name Found \t";
	exit();
}
elseif(mysqli_num_rows($emailcheck) == 0)
{
	echo "User email is not created click register button to create one.\t";
}
elseif (mysqli_num_rows($emailcheck) == 1) 
{
	//echo "Only one user which is good";
}

//get login info from query
$existinginfo = mysqli_fetch_assoc($emailcheck);
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

if (!password_verify($password, $hash) && !mysqli_num_rows($emailcheck) == 0) 
{
	echo "6: Incorrect password";
	exit();
}
else 
{
    echo "0";
}

?>