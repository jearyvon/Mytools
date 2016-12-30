<?php
include_once('imgTTF.class.php');
$txt =file_get_contents('test.txt');
$img =new imgTTF();
file_put_contents("1.png",$img->getpagepic($txt,1));
