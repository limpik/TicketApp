<?php
    $sorting=$_GET["sort"];
    session_start();
    
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
    }
   

    ?>