<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$username = $_POST['name'];
$password = $_POST['password'];

$namecheckquery = "SELECT username,salt,hash,score FROM login_info_table WHERE username = '". $username ."';";

  	$namecheck = mysqli_query($con, $namecheckquery);

if(mysqli_num_rows($namecheck) < 0)
{
	echo "Less than one Name Found \t";
	exit();
}
elseif (mysqli_num_rows($namecheck) > 1) 
{
	echo "Less than one Name Found \t";
	exit();
}
elseif(mysqli_num_rows($namecheck) == 0)
{
	echo "User email is not created click register button to create one.\t";
}
elseif (mysqli_num_rows($namecheck) == 1) 
{
	//echo "Only one user which is good";
}

//get login info from query
$existinginfo = mysqli_fetch_assoc($namecheck);
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

if (!password_verify($password, $hash) && !mysqli_num_rows($namecheck) == 0) 
{
	echo "6: Incorrect password";
	exit();
}
else 
{
    echo "0";
}

?>