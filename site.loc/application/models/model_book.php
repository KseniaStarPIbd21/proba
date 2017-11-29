<?php 
	class Model_Book extends Model
	{
		
		public function get_data()
		{
			$link = mysqli_connect('localhost', 'root', '', 'studia');
if (!$link) {
      die ('Ошибка соединения!' . mysqli_error());
      }
$result_list_date = array();

$sql1 = "SELECT DISTINCT date FROM `schedule`";
$result_list = mysqli_query($link,$sql1);
while($row = mysqli_fetch_array($result_list)) {
  $result_list_date[] = $row['date'];
}
			return $result_list_date;
		}

	
	
	
	public function get_data1()
		{
			$link = mysqli_connect('localhost', 'root', '', 'studia');
if (!$link) {
      die ('Ошибка соединения!' . mysqli_error());
      }
	  $result_list_start_time = array();
$sql1 = "SELECT DISTINCT time FROM `schedule` ";
$result1 = mysqli_query($link,$sql1);
while($row = mysqli_fetch_array($result1)) {
  $result_list_start_time[] = $row['time'];
}
			return $result_list_start_time;
		}

	
	
	public function get_data2()
		{
			$link = mysqli_connect('localhost', 'root', '', 'studia');
if (!$link) {
      die ('Ошибка соединения!' . mysqli_error());
      }
$result_list_date = array();
$sql = "SELECT * FROM `rooms`";
$result_list = mysqli_query($link,$sql);
while($row = mysqli_fetch_array($result_list)) {
  $result_list_date[] = $row;
}
			return $result_list_date;
		}

	
	
	public function set_data($name, $email, $npho )
		{
			 $link = mysqli_connect('localhost', 'root', '', 'studia');
if (!$link) {
      die ('Ошибка соединения!' . mysqli_error());
      }
	$sql = "UPDATE `schedule`  SET `state` =1, `familia`='".$name."',`phone_number`='".$npho."' WHERE `id_room` =1 AND `date` ='2017-10-26' AND `time` = '13:00:00'";
	$result = mysqli_query($link,$sql);
		}

	}
	
	

?>