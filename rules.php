<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<link rel="icon" type="image/png" href="images/favicon.png" />
<title>Фотостудия "бла-бла". </title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7; IE=EmulateIE9">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0, user-scalable=no"/>
    <link rel="stylesheet" type="text/css" href="styles.css" media="all" />
<link rel="stylesheet" href="style.css" type="text/css">
<!-- jQuery -->
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <!-- FlexSlider -->
    <script type="text/javascript" src="js/jquery.flexslider-min.js"></script>
<header>
 <?php include 'header.php' ?>
</header>
<script type="text/javascript">
 
$(function() {
 
$(window).scroll(function() {
 
if($(this).scrollTop() != 0) {
 
$('#toTop').fadeIn();
 
} else {
 
$('#toTop').fadeOut();
 
}
 
});
 
$('#toTop').click(function() {
 
$('body,html').animate({scrollTop:0},800);
 
});
 
});
 
</script>
</head>
<body>


<?php
if (file_exists("rules.txt")) {
$file_array = file("rules.txt");
//Выводим блок со стилем + сам текст
for ($i = 0; $i <= count($file_array); $i++) 
  { 
   if(!preg_match("/^[0-9]/", $file_array[$i]))
   {
	 // echo '<div class="name">'.$file_array[$i].'</div>'; 
	 echo '<div class="p1">'.$file_array[$i].'</div>'; 
   } else echo '<div class="textblock">'.$file_array[$i].'</div>'; 
  } 	
}
else echo "Файл не существует";


?>
</body>
<?php include 'footer.php' ?>

</html>