<?php
$errorMSG = "";
// NAME
if (empty($_POST["name"])) {
    $errorMSG .= "Введите имя";
} else {
    $name = $_POST["name"];
}
// EMAIL
if (empty($_POST["email"])) {
    $errorMSG .= "Введите Email ";
} else {
    $email = $_POST["email"];
}
// MESSAGE
if (empty($_POST["message"])) {
    $errorMSG .= "Введите сообщение ";
} else {
    $message = $_POST["message"];
}

$EmailTo = "kingartst@gmail.com";
$Subject = "Новая заявка";
// prepare email body text
$Body = "";
$Body .= "Имя: ";
$Body .= $name;
$Body .= "\n";
$Body .= "Email: ";
$Body .= $email;
$Body .= "\n";
$Body .= "Сообщение: ";
$Body .= $message;
$Body .= "\n";
// send email
$success = mail($EmailTo, $Subject, $Body, "От:".$email);
// redirect to success page
if ($success && $errorMSG == ""){
   echo "success";
}else{
    if($errorMSG == ""){
        echo "Что-то пошло не так ((";
    } else {
        echo $errorMSG;
    }
}
?>