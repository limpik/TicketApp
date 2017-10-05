<?php
    /* if($_POST['submit-send'])//проверка нажата ли кнопка
    
      { 
      $error = array();
    
    // Проверка полей
        
       if (!$_POST["add-name"])
      {
         $error[] = "Укажите Ваше имя";
      } else{$add_name = $_POST["add-name"];}
      
       if (!$_POST["add-phone"])
      {
         $error[] = "Укажите свой номер телефона";
      }
      if (!(preg_match("/^[0-9-]+$/",$_POST["add-phone"]))){
        $error[] = "Укажите телефон в правильном формате";
      } else{$add_phone = $_POST["add-phone"];}  
       
      if (!$_POST["add-email"])
      {
         $error[] = "Укажите свой email";         
      }
        else{ $add_email=$_POST["add-email"];}
           
    
                                      
      if (count($error))
       {           
            $_SESSION['message'] = "<p id='form-error'>".implode('<br />',$error)."</p>";
            
       }
 
       
          else {   */
          if($_POST['submit-send']){//проверка нажата ли кнопка
               $add_name = $_POST["add-name"];
               $add_email = $_POST["add-email"];
               $add_phone = $_POST["add-phone"];
            $message='Пользователь'.$add_name.'оставил заявку на обратный звонок. Номер:'.$add_phone;
      $email=$_POST["add-email"];
      $to='limp2_96@mail.ru';
      $subject='Заявка на звонок';
      // Для отправки HTML-письма должен быть установлен заголовок Content-type
//$headers  = 'MIME-Version: 1.0' . "\r\n";
//$headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n"; 

// Дополнительные заголовки
//$headers .= 'To: Ирина <iklinkova@yandex.ua>' . "\r\n"; // Свое имя и email
//$headers .= 'From: '  . $_POST['add-name'] . '<' . $_POST['add-email'] . '>' . "\r\n";
      mail($to, $subject, $message);}
     // $_SESSION['message'] = "<p id='form-success'>Заявка успешно отправлена!</p>";}

     // }
      
      
?>
<!DOCTYPE HTML>
<html>

<head>
	<meta http-equiv="content-type" content="text/html" />
   
</head>

<body>
<?php

	//	 if(isset($_SESSION['message']))
	//	{
	//	echo $_SESSION['message'];
	//	unset($_SESSION['message']);
	//	}
  
?>
<form method="post" action="report.php">
<ul>
<li>
<label>Ваше имя</label>
<input type="text" placeholder="Введите Ваше имя" name="add-name"/></li>

<li>
<label>Телефон</label>
<input type="text" placeholder="Введите Ваш номер телефона" name="add-phone"/></li>

<li>
<label>Email</label>
<input type="text" placeholder="Введите свой email" name="add-email"/></li>

</ul>
<p id="add"><input type="submit" id="" name="submit-send" value="Отправить заявку"/></p>
</form>
</body>
</html>