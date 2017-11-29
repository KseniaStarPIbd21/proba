<script type="text/javascript">
  if(screen.width < 1){
     location.href='/proba7/index.php';
  }
</script>

  <a href="" class="logo">Фотостудия <br> "бла-бла"</a>
    <!-- This checkbox will give us the toggle behavior, it will be hidden, but functional -->
    <input id="toggle" type="checkbox">

    <!-- IMPORTANT: Any element that we want to modify when the checkbox state changes go here, being "sibling" of the checkbox element -->

    <!-- This label is tied to the checkbox, and it will contain the toggle "buttons" -->
    <label class="toggle-container" for="toggle">
        <!-- If menu is open, it will be the "X" icon, otherwise just a clickable area behind the hamburger menu icon -->
        <span class="button button-toggle"></span>
    </label>
	<nav class="nav">
        <a class="nav-item" href="index.php">Главная</a>
        <a class="nav-item" href="rules.php">Правила студии</a>
		<a class="nav-item" href="zagluschka.php">Интерьеры и цены</a>
        <a class="nav-item" href="bron.php">Бронирование</a>
        <a class="nav-item" href="zagluschka.php">Контакты</a>
    </nav>
	
