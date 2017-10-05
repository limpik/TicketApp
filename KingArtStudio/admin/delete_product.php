<?php
   include("include/db_connect.php");
   $id = $_GET['id_product'];
   mysql_query(" DELETE FROM product WHERE id_product='$id' ");
   mysql_close();
header("Location: tovar.php");


?>