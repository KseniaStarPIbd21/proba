<?php
// Error reporting:
error_reporting(E_ALL^E_NOTICE);

// This is the URL your users are redirected,
// when registered succesfully:

//$redirectURL = 'zagluschka.php';
$redirectURL = 'goodbron.php';
$errors = array();

// Checking the input data and adding potential errors to the $errors array:

if(!$_POST['name'] || strlen($_POST['name'])<3 || strlen($_POST['name'])>50 || !preg_match("/^[А-яA-z]/", $_POST['name']))
{
	$errors['name']='Please fill in a valid name!<br />Must be between 3 and 50 characters.';
}

if(!$_POST['email'] || !preg_match("/^[\.A-z0-9_\-\+]+[@][A-z0-9_\-]+([.][A-z0-9_\-]+)+[A-z]{1,4}$/", $_POST['email']))
{
	$errors['email']='Please fill in a valid email!';
}

if(!$_POST['nphone'] || !preg_match("/((8|\+7)-?)?\(?\d{3,5}\)?-?\d{1}-?\d{1}-?\d{1}-?\d{1}-?\d{1}((-?\d{1})?-?\d{1})?/", $_POST['nphone']))
{
	$errors['nphone']='Please fill in a valid telephone number!<br />';
}

// Checking whether the request was sent via AJAX
// (we manually send the fromAjax var with the AJAX request):

if($_POST['fromAjax'])
{
	if(count($errors))
	{
		$errString = array();
		foreach($errors as $k=>$v)
		{
			// The name of the field that caused the error, and the
			// error text are grouped as key/value pair for the JSON response:
			$errString[]='"'.$k.'":"'.$v.'"';
		}
		
		// JSON error response:
		die	('{"status":0,'.join(',',$errString).'}');
	}

	// JSON success response. Returns the redirect URL:
	echo '{"status":1,"redirectURL":"'.$redirectURL.'"}';
	exit;
}

// If the request was not sent via AJAX (probably JavaScript
// has been disabled in the visitors' browser):

if(count($errors))
{
	echo '<h2>'.join('<br /><br />',$errors).'</h2>';
	exit;
}

// Directly redirecting the visitor:
    $name = $_POST['name'];
    $email = $_POST['email'];
    $npho = $_POST['nphone']; 
    $f = fopen('title/textfile.txt', a);
    fputs($f, $name."  ".$npho."  ".$email."\n");
    fclose($f);

	header("Location: ".$redirectURL);
?>