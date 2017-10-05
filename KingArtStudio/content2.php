<?php

include("admin/include/db_connect.php");
session_start();



  $res = $_POST['id'];
   $result = mysql_query("SELECT * FROM product WHERE  id_product = $res",$link);
  
   	 if (mysql_num_rows($result)>0) 
   	             {
   	 	$row=mysql_fetch_array($result);

   	 	do{
             if  ($row["image"] > 0 && file_exists("upload/".$row["image"]))
            {
             $img_path = 'upload/'.$row["image"];
          
            } else {
                 $img_path = "../images/no-image.png";
                 $width = 300;
                 $height = 300;
                   }

        echo '


         <div class="modal-content" >
             <div class="modal-header">
                 <button type="button" class="close" data-dismiss="modal">&times;</button>
                 <h2 class="nov">"'.$row["title"].'"</h2>
               </div>
               <div class="modal-body">
                <div class="container-fluid">
                  
                    <div class="row">
                      <div class="col-md-6">
                          <img src="upload/'.$row["image"].'" />
                      </div>
                    <div class="col-md-6">
                      <p><h4 class="title">Жанр:</h4><h4 class="description">'.$row["genre"].'</h4></p>
                      <p><h4 class="title">Размер:</h4><h4 class="description">'.$row["size"].'см</h4></p>     
                      <p><h4 class="title">Описание:</h4><h4 class="description">'.$row["description"].'</h4></p> 
                    </div>
                  </div>
               
                 
               </div>
               </div>
               <div class="modal-footer">
                 <button type="submit" id="form-submit" class="btn btn-success">В корзину</button>
                 <button class="btn btn-danger" type="button" data-dismiss="modal">Закрыть</button>
               </div>   
        </div>

        ';
   	 }
   	 while($row = mysql_fetch_array($result));
    }   
?>


