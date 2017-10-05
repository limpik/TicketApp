
<div id="block-header">
<div id="block-header1">
<h3>KingArtStudio. Панель управления</h3>
<p id="link-nav"><?php	echo $_SESSION['urlpage'] ?></p>
</div>

<div id="block-header2">
<p><a href="adminictrators.php">Администраторы</a> | <a href="?logout">Выход</a></p>
<p>Вы - <span><?php echo $_SESSION['username']?></span></p>
</div>
</div>
<div id="left-nav">
<ul>
<li><a href="tovar.php">Товары</a></li>
<li><a href="clients.php">Клиенты</a></li>
</ul>
</div>
