<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<link rel="icon" type="image/png" href="images/favicon.png" />
<title>Фотостудия "бла-бла". Бронирование.</title>
<link rel="stylesheet" href="style.css" type="text/css">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7; IE=EmulateIE9">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0, user-scalable=no"/>

<header>
 <?php include 'header.php' ?>
</header></head>
<body>
<div id="carbonForm">
	<p>Бронирование</p>

    <form action="submit.php" method="post" id="signupForm">

    <div class="fieldContainer">

        <div class="formRow">
            <div class="label">
                <label for="name">Ваша фамилия:</label>
            </div>
            
            <div class="field">
                <input type="text" name="name" required id="name" placeholder="Фамилия"/>
            </div>
        </div>
        
        <div class="formRow">
            <div class="label">
                <label for="email">Email:</label>
            </div>
            
            <div class="field">
                <input type="text" name="email" required id="email" placeholder="Email"/>
            </div>
        </div>
        
        <div class="formRow">
            <div class="label">
                <label for="nphone">Номер телефона:</label>
            </div>
            
            <div class="field">
                <input type="text" name="nphone" required id="nphone" placeholder="Номер телефона" />
            </div>
        </div>
        
        

        <input type="submit" name="submit" id="submit" value="Забронировать" />
	   
    </div>
    
    </form>
        
</div>
<script type="text/javascript" src="script.js"></script>
</body>
<?php include 'footer.php' ?>
</html>