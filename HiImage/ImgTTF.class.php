<?php
/**
 * User: JearyVon
 * Date: 2016/3/19 0019
 * Time: 16:52
 * Email��v@vvwall.com
 */
class ImgTTF
{
		private $config =array();
		
		public function __construct($config=false){
			if($config){
				$this->config =$config;
			}else{
			 $this->config =array(
				'width' =>'800',
				'height'=>'220',
				'border' =>false,
				'randcolor'=>true,
				'padding' =>20,
				'bd'=>array(
					'r' =>0,
					'g' =>0,
					'b' =>0,
				),
				'background'=>array(
					'r' =>255,
					'g' =>250,
					'b' =>249,
				),
				'r' =>80,
				'g' =>97,
				'b' =>109,
				'fontpath'=>"msyh.ttf",
				'fontsize'=>16,

			)	;
			}

		}
        public function  getstrpic($str,$config=null,$strarr=null){
            if($config==null){
               $config=$this->config;
            }
            if(mb_strlen($str,'UTF-8')>140){
                return false;
            }
            $im =imagecreate($config['width'],$config['height']);
            $width =$config['width'];
            $height = $config['height'];
            $fontsize =$config['fontsize'];
            $font = $config['fontpath'];
            $padding =$config['padding'];
            $imgpicstr =array();
            $break =false;
            if(!isset($strarr)){
                $strarr =mbStrSplit($str);
            }
            $fontH= $fontsize*1.5;
            $centy =$fontH+$padding;

            $tempstr='';
            for($i=0;$i<count($strarr);$i++){
                if($centy>$height){

                    $fontsize =$config['fontsize']=$fontsize-3;

                    $break =true;
                    break;
                }else{
                    $pos =imageftbbox($fontsize*1.05, 0, $font, $tempstr);
                    if(($pos[2]-$pos[0])>$width-$padding*2){
                        $centx =$padding;
                        $td['str']=$tempstr;
                        $td['y'] =$centy;
                        array_push($imgpicstr,$td );//��������
                        $tempstr ='';//���
                        $centy +=$fontH;
                    }
                    $tempstr.=$strarr[$i];
                }
            }
            $td['str']=$tempstr;
            $td['y'] =$centy;
            array_push($imgpicstr, $td);//��������

            if(!$break){
                if($config['randcolor']){
                    $config['r']=mt_rand(1,255);
                    $config['g']=mt_rand(1,255);
                    $config['b']=mt_rand(1,255);
                    $color = imagecolorallocate($im, $config['r'],$config['g'],$config['b']);
                }
                //���
                if($config['border']){
                    $bg= imagecolorallocatealpha($im,$config['bd']['r'],$config['bd']['g'],$config['bd']['b'],127);//����ɫ���ĸ�����0-127��ʾ͸����
                    $color = imagecolorallocate($im, $config['r'],$config['g'],$config['b']);//������ɫѡ��
                }else{
                    $bg= imagecolorallocatealpha($im,$config['r'],$config['g'],$config['b'],127);//����ɫ���ĸ�����0-127��ʾ͸����
                    $color = imagecolorallocate($im, $config['r'],$config['g'],$config['b']);//������ɫѡ��
                }

                imagealphablending($im , false);//�رջ��ģʽ���Ա�͸����ɫ�ܸ���ԭ����
                imagefill($im , 0 , 0 , $bg);//���
                //���ܼ������ִ�С�����Ű�


                $paddingtb=($height -end($imgpicstr)['y'])/2;
                $centx = $padding;
                if(count($imgpicstr)==1){
                    //����
                    $bbox = imageftbbox($fontsize, 0, $font, $imgpicstr[0]['str']);
                   $centx= ($width-($bbox[2]-$bbox[0]))/2+$padding;
                }
                for($t =0;$t<count($imgpicstr);$t++) {

                    imagettftext($im, $fontsize, 0, $centx, $imgpicstr[$t]['y']+$paddingtb, $color, $font, $imgpicstr[$t]['str']);
                }
                imagesavealpha($im , true);//���ñ���PNGʱ����͸��ͨ����Ϣ
                header("content-type: image/png");
                imagepng($im);

            }else{

               $this->getstrpic($str,$config,$strarr);//�ݹ�
            }
            imagedestroy($im);
            return ture;
        }
    //ȡһ������ͼ
    public function getline(){

    }
    public function  getpagepic($str,$eng=1,$config=null){
        //x�Ȳ�����ͼƬ
        // ֻ����һ�����880px
        if(!isset($config)){
            $config =$this->config;
            $config['width']=800;
        }
        $width =$config['width'];

                //�����ַ���
        $str=str_replace(PHP_EOL,'?',$str);

        $strarr =mbStrSplit($str);//    ����
        $fontH =$config['fontsize']*1.5;
        $centy =$fontH+$config['padding'];
        $fontsize =$config['fontsize'];
        $font=$config['fontpath'];
        $tempstr ='';
        $imgpicstr=array();
        $padding =$config['padding'];
        $titletab =1;
        $linewidth=0;
        if($eng==1){
            for($i =0;$i<count($strarr);$i++){
                if($strarr[$i]=='?'){
                    $centx =$padding;
                    $td['str']=$tempstr;
                    $td['y'] =$centy;
                    array_push($imgpicstr,$td );//��������
                    $tempstr ='';//���
                    $centy +=$fontH;
                    $linewidth=0;
                }else{
                    // $pos =imageftbbox($fontsize*1.05, 0, $font, $tempstr);

                    if($linewidth>$width-$padding*2){
                        $centx =$padding;
                        $td['str']=$tempstr;
                        $td['y'] =$centy;
                        array_push($imgpicstr,$td );//��������
                        $tempstr ='';//���
                        $centy +=$fontH;
                        $linewidth=0;
                    }
                    $tempstr.=$strarr[$i];
                    $linewidth+=($fontsize*1.35 );
                }

            }
        }else{
            for($i =0;$i<count($strarr);$i++){
                if($strarr[$i]=='?'){
                    $centx =$padding;
                    $td['str']=$tempstr;
                    $td['y'] =$centy;
                    array_push($imgpicstr,$td );//��������
                    $tempstr ='';//���
                    $centy +=$fontH;
                }else{
                    $pos =imageftbbox($fontsize*1.05, 0, $font, $tempstr);

                    if(($pos[2]-$pos[0])>$width-$padding*2){
                        $centx =$padding;
                        $td['str']=$tempstr;
                        $td['y'] =$centy;
                        array_push($imgpicstr,$td );//��������
                        $tempstr ='';//���
                        $centy +=$fontH;
                    }
                    $tempstr.=$strarr[$i];
                }

            }
        }
        $td['str']=$tempstr;
        $td['y'] =$centy;
        array_push($imgpicstr,$td );//��������
//     dump($imgpicstr);
        $autoheight =end($imgpicstr)['y']+10+$padding*2;
        $im =imagecreate($width,$autoheight);
        $centx = $padding;
        if(count($imgpicstr)==1){
            //����
            $bbox = imageftbbox($fontsize, 0, $font, $imgpicstr[0]['str']);
            $centx= ($width-($bbox[2]-$bbox[0]))/2+$padding;
        }
        $background = imagecolorallocate($im, $config['background']['r'],$config['background']['g'],$config['background']['b']);
        $color = imagecolorallocate($im, $config['r'],$config['g'],$config['b']);//������ɫѡ��
      //  imageline($im,$padding,$padding,$width-$padding,$padding,$color);
        for($t =0;$t<count($imgpicstr);$t++) {
           // var_dump($imgpicstr[$t]);
            imagettftext($im, $fontsize, 0, $centx, $imgpicstr[$t]['y'], $color, $font, $imgpicstr[$t]['str']);
        }
        //��ҳ�Ż���
        $linecolor =imagecolorallocate($im, 240,0,86);
      //  imageline($im,$padding,$autoheight-26,$width-$padding,$autoheight-26,$linecolor);

       if($eng==1){
           imagettftext($im, 10, 0, $width-200,$autoheight-20, $linecolor, $font,'���� @Hi image ������������');
       }else{
           imagettftext($im, 10, 0, $width-160,$autoheight-20, $linecolor, $font,'���� @Hi image ����');
       }
        header("content-type: image/png");
        imagepng($im);
        imagedestroy($im);
    }
    //�����־���λ�ú���
    private function centerstr($width,$height,$fontsize,$str,$fontpath){

        $pos =imagettfbbox($fontsize,0,$fontpath,$str);
        $w =$pos[4]-$pos[6];//���ֵĿ��
        $h =$pos[5]-$pos[7];//���ָ߶�
//        ����ͼ��Ĺ��
        $ret =array(
            'left'=>0,
            'top' =>0,
            'size'=>$fontsize
        );
        $fontH= imagefontheight($fontsize)*2;
        $fontW =-imagefontwidth($fontsize)*2.61;
        if($width>$w){
            if($height>$h){
                mb_strlen($str,'utf-8');
            }
        }
      //  if()//���Ͻ�����

    }
}