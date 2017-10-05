<?php
include("db_connect.php");
session_start();
  if(!empty($_POST['value'])){
    $value = $_POST['value'];
    if($value == 1){
       echo '1';
    }else 
      if($value == 2){
      echo '2';
    }else 
      if($value == 3){

       $result=mysql_query("SELECT * FROM product WHERE genre='пейзаж'", $link);
        if(mysql_num_rows($result)>0)
        {
          $row=mysql_fetch_array(result);
            do {
              if  ($row['image'] > 0 && file_exists("upload/".$row["image"]))
                          {
                           $img_path = 'upload/'.$row["image"];
                          } else {
                            $img_path = "../images/no-image.png";
                            $width = 300;
                            $height = 300;
                            }
      echo ' 
          <div class="col-md-4">
            <div class="wrap_tovar">
              <li>
                <div id="this_a">
                  <div class="img_tovar">
                    <img src="upload/'.$row["image"].'" alt="alt">
                  </div>
                  <a  data-toggle="modal" href="#modal_tovar" title="'.$row["id_product"].'">                  
                  <p class="tovar_title">'.$row["title"].'</p> </a>
                  <p class="tovar_price">'.$row["price"]." ".'USD</p>
                </div>
              </li>          
            </div>        
          </div>  
         ';
        }
       while($row = mysql_fetch_array($result));
      }
    }
  }
  

            /*  $result=mysql_query("SELECT * FROM product WHERE genre='пейзаж' ORDER BY 
                $sorting",$link);
                if (mysql_num_rows($result)>0)
                  {
                    $row=mysql_fetch_array($result);
                      do{
                        if  ($row['image'] > 0 && file_exists("upload/".$row["image"]))
                          {
                           $img_path = 'upload/'.$row["image"];
                          } else {
                            $img_path = "../images/no-image.png";
                            $width = 300;
                            $height = 300;
                            }
    echo ' 
          <div class="col-md-4">
            <div class="wrap_tovar">
              <li>
                <div id="this_a">
                  <div class="img_tovar">
                    <img src="upload/'.$row["image"].'" alt="alt">
                  </div>
                  <a  data-toggle="modal" href="#modal_tovar" title="'.$row["id_product"].'">                  
                  <p class="tovar_title">'.$row["title"].'</p> </a>
                  <p class="tovar_price">'.$row["price"]." ".'USD</p>
                </div>
              </li>          
            </div>        
          </div>  
         ';
        }
          while($row = mysql_fetch_array($result));
      }   */
       ?>