<?php

 /* $sorting=$_GET["sort"];
  
  switch($sorting){
    case 'price-asc';
    $sorting='price ASC';
    break;
        
    case 'price-desc';
    $sorting='price DESC';
    break;
        
    default:
    $sorting='id_product DESC';
    break;
  } */
?>
<!DOCTYPE html>
<html lang="ru">
  <head>
    <meta charset="windows-1251">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>KingArtStudio</title>

    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link rel="stylesheet" href="css/fonts.css" />
    
    <script  src="http://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script>
      $(document).ready(function(){

         // $(".spol1").click(function(){
           // value = $(this).attr("value");
          //  $.get("/services/load_tovar.php", value, function(result){
          //      $("#result").html(result);
          //  });
         // });


          $(".spol1").click(function(){
            var val = $(this).attr('value');
            $.ajax({
              type: "POST",
              url: "loadtovar.php",
              data: "value="+val,
              success: function(result)
              {
                $("#view_tovar").html(result);
              },
              error: function(){
                 alert('Problem whith POST!');
               }
            });
          });
      });
    </script>
  </head>
  <body>
  <!-- Модальное окно  "Карточка товара"-->
    <div class="modal fade" id="modal_tovar">
      <div class="modal-dialog mdl">
        
      </div>
    </div>

  <header>
  <div id="result"></div>
    <div class="top_line">
      <div class="container">
        <div class="row">
          <div class="col-md-4">
            <div class="name_king">
              <strong>KingArtStudio</strong>
            </div>
          </div>
          <div class="col-md-4"></div>
          <div class="col-md-4"></div>
        </div>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <h1>Стань ближе к искусству c "KINGARTSTUDIO"</h1>
        </div>
      </div>
    </div>
      
    <div class="button_top">
      <div class="container">
        <div class="row">
          <div class="col-md-4"></div>
          <div class="col-md-4">
           <a data-toggle="modal" href="#modal_order" class="button">Сделать индивидуальный заказ</a> 
          </div>
          <div class="col-md-4"></div>
        </div>
      </div>                      
    </div> 
  </header>



  <nav class="center_menu ">
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <ul>
            <li><a href="#about_us" class="scrollto">О нас</a></li>
            <li><a href="#our_works" class="scrollto">Наши работы</a></li>
            <li><a href="#delivery" class="scrollto">Доставка</a></li>
            <li><a href="#contacts" class="scrollto">Контакты</a></li>
            <li><a href="#" class="info">Полезная информация</a></li>
          </ul>
        </div>
      </div>
    </div>
  </nav>



  <section class="about_us" id="about_us">
    <div class="container">
      <div class="row">
        <div class="col-md-4"><p class="block_opis_1">Про KINGARTSTUDIO</p></div>
        <div class="col-md-8">
          <p class="block_opis_2">KingArtStudio - это дружная командпрофессиональных художников, каждый из которых имеет за плечами более 7 лет стажа. За время своей деятельности мы создали более 1000+ полотен, которые ежедневно приносят уйму положительных эмоций нашим клиентам.</p>
        </div>
      </div>
    </div>
      
    <div class="wrap_3">
      <div class="container">
        <div class="row">
          <div class="col-md-3">
            <div class="block_facts">
              <h1>7 лет на рынке</h1>
              <p>Работаем много лет, поможем подобрать лучшее для вас</p>
            </div>
          </div>
          <div class="col-md-3">
            <div class="block_facts">
              <h1>1000+ проданных картин</h1>
              <p>Уже украшают дома наших клиентов </p>
            </div>
          </div>
          <div class="col-md-3">
            <div class="block_facts">
              <h1>870 довольных клиентов</h1>
              <p>Сотни благодарных клиентов уже подобрали себе картины</p>
            </div>
          </div>
          <div class="col-md-3">
            <div class="block_facts">
              <h1>50+ стран мира</h1>
              <p>Осуществляется экспресс-доставка Ваших заказов</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>



  <section class="our_works" id="our_works">
    <div class="wrap_1">

      <div class="container">
        <div class="row">
          <div class="col-md-12"><span>Наши работы</span></div>
        </div>
      </div>

      <div class="wrap_2">
        <div class="container">
          <div class="row">

            <div class="col-md-4">
              <div class="block_painting p_left">
                <img src="img/1.jpg" alt="alt">
                <a href="#" class=""><h3>Портреты</h3></a>
              </div>
            </div>

            <div class="col-md-4"> 
              <div class="block_painting">
                <img src="img/2.jpg" alt="alt">
                <a href="#" class=""><h3>Натюрморты</h3></a>
              </div>
            </div>

            <div class="col-md-4">
              <div class="block_painting">
                <img src="img/3.jpg" alt="alt">
                <a href="#" class="spol1" value="2"><h3>Пейзажи</h3></a>
              </div>
            </div>

          </div>
        </div>
      </div>

    </div>
  </section>



  <section class="tovar">
    <div class="container">

      <div class="wrap_block_sorting">
        <div class="row">
          <div class="col-md-3"></div>
          <div class="col-md-6">
            <ul id="sort">
              <li>Сортировать:</li>
              <li><a href="index.php?sort=price-desc">От дорогих к дешовым</a></li>
              <li><a href="index.php?sort=price-asc">От дешовых к дорогим</a></li>
            </ul>
          </div>
          <div class="col-md-3"></div>            
        </div>
      </div>

        <div class="row" id="view_tovar">
          

        </div>
      </div>
    </section> 



  <section class="delivery" id="delivery">
    <div class="wrap_delivery">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <span>Доставка</span>
          </div>
        </div>
      </div>

      <div class="container p_top">
        <div class="row">
          <div class="col-md-4">
            <img src="img/delivery1.jpg" alt="alt">
          </div>
          <div class="col-md-8 p_block_text">
            <h3>Украина</h3>
            <p>Во все города Украины доставка осуществляется службой "Нова Пошта", в течении 2-3 дней после отправки товара. </p>
            <h3>Международная доставка</h3>
            <p>Международная доставка товаров осуществляется в более чем 200 стран мира с помощью служб DHL, УкрПошта, Нова  Пошта, в течении 7-14 дней.</p>
          </div>
        </div>
      </div>
    </div>  
  </section>



  <section class="contacts" id="contacts">
    <div class="container">
      <div class="row">

        <div class="col-md-4">
          <img src="img/phone.png" alt="alt">
          <strong>0938664141</strong>
        </div>

        <div class="col-md-4">
          <img src="img/mail.png" alt="alt">
          <strong>kingartst@mail.ru</strong>
        </div>

        <div class="col-md-4">
          <img src="img/place.png" alt="alt">
          <strong>г.Харьков, Гв.Широнинцев 45</strong>
        </div>
         
      </div>
    </div>
  </section>

<!-- Модальное окно  "Форма заказа"-->
<div class="modal fade" id="modal_order">
  <div class="modal-dialog">
     <div class="modal-content">
       <div class="modal-header">
         <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Индивидуальный заказ</h4>
      </div>

    <div class="modal-body"> 
      <form class="form-horizontal" id="contactForm">
        <div class="form-group">
          <label for="name" class="col-sm-3 control-label">Ваше имя</label>
          <div class="col-sm-7">
            <input type="text" class="form-control" id="name" name="name" placeholder="Name">
          </div>
          <div class="col-sm-2"></div>
        </div>

        <div class="form-group">
          <label for="mail" class="col-sm-3 control-label">Ваш Email</label>
          <div class="col-sm-7">
            <input type="email" class="form-control" id="email" name="email" placeholder="Email">
          </div>
          <div class="col-sm-2"></div>
        </div>

        <div class="form-group">
          <label for="message" class="col-sm-3 control-label">Ваше сообщение</label>
          <div class="col-sm-7">
            <textarea class="form-control" id="message" name="message" rows="3"></textarea>
          </div>
          <div class="col-sm-2"></div>
        </div>

        <div class="form-group">
          <label for="exampleInputFile" class="col-sm-3 control-label">Загрузить файл</label>
            <div class="col-sm-6">
              <input type="file" multiple="multiple" accept=".txt,image/*">
              <button class="submit button btn btn-default">Загрузить файл</button>
              <div class="ajax-respond"></div>
            </div>
            <div class="col-sm-3"></div>
        </div>

        <div class="form-group top_button_order">
          <div class="col-sm-6"></div>
          <div class="col-sm-6">
            <div class="top_buttons">
              <button type="submit" id="form-submit" class="btn btn-success">Отправить</button>
              <button class="btn btn-danger" type="button" data-dismiss="modal">Отменить</button>
            </div>
          </div>
        </div>
      </form>
    </div>

    <div class="modal-footer hidden">
      <p class="view-message">
        <h4>Заявка отправлена</h4>
        <h5>В течении дня мы c Вами свяжемся</h5>
        </p>
    </div>
  </div>
</div>
</div>

    
    <script src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/script_upload.js"></script>
    <script src="js/func.js"></script> 
    <script type="text/javascript" src="js/scripts.js"></script>

  </body>
</html>