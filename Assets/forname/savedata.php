<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$username = $_POST['name'];
$newscore = $_POST['score'];

$checkquery = "SELECT username FROM login_info_table WHERE username = '" . $username . "';";

$check = mysqli_query($con, $checkquery);

$existinginfo = mysqli_fetch_assoc($check);

if(mysqli_num_rows($existinginfo) <= 0)
{
	echo mysqli_error($con);
}
else if(mysqli_num_rows($existinginfo) > 1)
{
	echo "more than one user with name";
	exit();
}

$updatequery = "UPDATE login_info_table SET score = " . $newscore . " WHERE username = '" . $username . "';";
mysqli_query($con,$updatequery) or die("7");

echo "0";

?>