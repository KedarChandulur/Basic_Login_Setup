<?php

$con = mysqli_connect('localhost','root','root','login_storage');

if (mysqli_connect_errno()) 
{
  echo "1: Failed to connect to MySQL";
  exit();
}

$useremail = $_POST['email'];
$password = $_POST['password'];

$emailcheckquery = "SELECT email,salt,hash FROM login_info_table WHERE email = '". $useremail ."';";

  	$emailcheck = mysqli_query($con, $emailcheckquery);

if(mysqli_num_rows($emailcheck) != 1)
{
	echo "5: Either no user with name or more than one";
	exit();
}


//------------------------------------------------------

//get login info from query
$existinginfo = mysqli_fetch_assoc($emailcheck);
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

if (password_verify($password, $hash)) 
{
    //echo "Success";
}
else 
{
    echo "6: Incorrect password";
	exit();
}

//$salt = "\$5\$rounds=5000\$" . "steamedhams" . $useremail . "\$";
//$hash = crypt($password,$salt);

//$salt = '\$5\$rounds=5000\$';
//$hash = $password.$salt;
//$hash = sha1($hash);

//echo "string " . $hash;

//$loginhash = crypt($password,$salt);
//if($hash != $loginhash)
//{
//	echo "6: Incorrect password";
//	exit();
//}

echo "0";

?>