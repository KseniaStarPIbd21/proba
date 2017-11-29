<?php

class Controller_Book extends Controller
{
	
	function __construct()
	{
		$this->model = new Model_Book();
		$this->view = new View();
	}

	function action_index()
	{
		$data = $this->model->get_data();
		$data1 = $this->model->get_data1();
		$data2 = $this->model->get_data2();
		 if (!empty($_POST['name'])) {
            if (!empty($_POST['email'])) {
				if (!empty($_POST['nphone'])) {
				       $this->model->set_data($_POST['name'],$_POST['email'], $_POST['nphone']);
				}
			}
		 }
		$this->view->generate('book_view.php', 'template_view.php', $data, $data1, $data2 );
		
	}
}
