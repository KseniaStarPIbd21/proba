<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<link rel="icon" type="image/png" href="images/favicon.png" />
<title>Фотостудия "бла-бла". Главная.</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7; IE=EmulateIE9">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0, user-scalable=no"/>
    <link rel="stylesheet" type="text/css" href="styles.css" media="all" />
<link rel="stylesheet" href="style.css" type="text/css">
<!-- jQuery -->
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <!-- FlexSlider -->
    <script type="text/javascript" src="js/jquery.flexslider-min.js"></script>
    <script type="text/javascript" charset="utf-8">
    var $ = jQuery.noConflict();
    $(window).load(function() {
    $('.flexslider').flexslider({
          animation: "fade"
    });
	
	$(function() {
		$('.show_menu').click(function(){
				$('.menu').fadeIn();
				$('.show_menu').fadeOut();
				$('.hide_menu').fadeIn();
		});
		$('.hide_menu').click(function(){
				$('.menu').fadeOut();
				$('.show_menu').fadeIn();
				$('.hide_menu').fadeOut();
		});
	});
  });
</script>
 
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
<div class="container">
     
     <div class="slider_container">
		<div class="flexslider">
	      <ul class="slides">
	    	<li>
	    		<img src="images/slider/slide1.jpg" alt="" title=""/>
	    		<div class="flex-caption">
                     <div class="caption_title_line"><h2>Зал "Industrial"</h2></div>
                </div>
	    	</li>
	    	<li>
	    		<img src="images/slider/slide2.jpg" alt="" title=""/>
	    		<div class="flex-caption">
                     <div class="caption_title_line"><h2>Зал "Casual"</h2></div>
                </div>
	    	</li>
	    	<li>
	    		<img src="images/slider/slide4.jpg" alt="" title=""/>
	    		<div class="flex-caption">
                   <div class="caption_title_line"><h2>Зал "Casual"</h2></div>
                </div>
	    	</li>
			<li>
	    		<img src="images/slider/slide3.jpg" alt="" title=""/>
	    		<div class="flex-caption">
                     
					   <div class="caption_title_line"><h2>Зал "Nude"</h2></div>
                </div>
	    	</li>
	    	
	    </ul>
	  </div>
   </div>
    </div>  
</div>

<?php include 'footer.php' ?>


</body>

</html>