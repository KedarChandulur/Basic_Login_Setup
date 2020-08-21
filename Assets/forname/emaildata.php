<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$username = $_POST['name'];

$checkquery = "SELECT username,email,score FROM login_info_table WHERE username = '". $username ."';";

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

echo "0\t" . $existinginfo["email"] . "\t" . $existinginfo["score"];

?>