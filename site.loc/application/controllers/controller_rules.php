<?php

class Controller_Rules extends Controller
{
	
	function action_index()
	{
		$this->view->generate('rules_view.php', 'template_view.php');
	}
}
