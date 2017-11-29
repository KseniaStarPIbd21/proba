<?php
if (file_exists("text/rules.txt")) {
$file_array = file("text/rules.txt");
//Выводим блок со стилем + сам текст
for ($i = 0; $i < count($file_array); $i++) 
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