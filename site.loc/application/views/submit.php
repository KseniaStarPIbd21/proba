<?php
// Error reporting:
error_reporting(E_ALL^E_NOTICE);

// This is the URL your users are redirected,
// when registered succesfully:

$redirectURL = 'goodbron.php';
$errors = array();

$link = mysqli_connect('localhost', 'root', '', 'studia');
if (!$link) {
      die ('Ошибка соединения!' . mysqli_error());
      }
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
$sel_d = $_POST['id_date'];
$sel_t = $_POST['id_time']; 
$ind1 = $_POST['id_type']; 
$name = $_POST['name'];
    $email = $_POST['email'];
    $npho = $_POST['nphone']; 
$sql1 = "SELECT `state` FROM `schedule` WHERE `id_room` =".$ind1." AND `date` ='".$sel_d."' AND `time` = '".$sel_t."'";
$result_list_st = mysqli_query($link,$sql1);
if(mysqli_num_rows($result_list_st) > 0)
{
while($row = mysqli_fetch_array($result_list_st)) {
  if ($row['state']=="1"){
$errors['nphone']='Sorry, this time has been already booked!<br />';
} 
} } else {

$errors['nphone']='Sorry, this time has been already booked!<br />';
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
	} else {

	// JSON success response. Returns the redirect URL:
	
    $f = fopen('title/textfile.txt', a);
    fputs($f, $name."  ".$npho."  ".$email."\n");
    fclose($f);
	
$sql = "UPDATE `schedule`  SET `state` =1, `familia`='".$name."',`phone_number`='".$npho."' WHERE `id_room` =".$ind1." AND `date` ='".$sel_d."' AND `time` = '".$sel_t."'";
	$result = mysqli_query($link,$sql);}
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

    $f = fopen('title/textfile.txt', a);
    fputs($f, $name."  ".$npho."  ".$email."\n");
    fclose($f);
	
$sql = "UPDATE `schedule`  SET `state` =1, `familia`='".$name."',`phone_number`='".$npho."' WHERE `id_room` =".$ind1." AND `date` ='".$sel_d."' AND `time` = '".$sel_t."'";
	$result = mysqli_query($link,$sql);
    header("Location: ".$redirectURL);
	
?>