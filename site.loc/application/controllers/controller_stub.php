<?php

class Controller_Stub extends Controller
{

	function action_index()
	{	
		$this->view->generate('stub_view.php', 'template_view.php');
	}
}