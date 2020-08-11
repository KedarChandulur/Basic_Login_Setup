<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$useremail = $_POST['email'];

$checkquery = "SELECT email,username,score FROM login_info_table WHERE email = '". $useremail ."';";

$check = mysqli_query($con, $checkquery);

$existinginfo = mysqli_fetch_assoc($check);

if(mysqli_num_rows($existinginfo) <= 0)
{
	echo mysqli_error($con);
}
else if(mysqli_num_rows($existinginfo) > 1)
{
	echo "1";
	exit();
}

echo "0\t" . $existinginfo["username"] . "\t" . $existinginfo["score"];

?>