$(document).ready(function (form) {
		var r = /^[А-яA-z]{3,25}/;
		var e = /^[\.A-z0-9_\-\+]+[@][A-z0-9_\-]+([.][A-z0-9_\-]+)+[A-z]{1,4}$/;
		var t = /((8|\+7)-?)?\(?\d{3,5}\)?-?\d{1}-?\d{1}-?\d{1}-?\d{1}-?\d{1}((-?\d{1})?-?\d{1})?/;
		
		if ((!r.test(document.getElementById('name').value)) || (!e.test(document.getElementById('email').value)) || (!t.test(document.getElementById('nphone').value))) {
     if(!r.test(document.getElementById('name').value))
{
	alert("Фамилия введена неверно!");
} 
     if(!e.test(document.getElementById('email').value))
{
	alert("Эл. адрес введен неверно!");
}

     if(!t.test(document.getElementById('nphone').value))
{
	alert("Номер телефона введен неверно!");
}
} else {
	var fam = document.getElementById('name').value;
	var phone = document.getElementById('nphone').value;
	<?PHP
	  $sql1 = "UPDATE `schedule`  SET `state` =1, `familia`='".$fam."',`phone_number`='".$phone."' WHERE `id_room` =1 AND `date` ='2017-10-25' AND `time` = '14:00:00'";
$result_list_st = mysqli_query($link,$sql1);?>

form.reset();}
});