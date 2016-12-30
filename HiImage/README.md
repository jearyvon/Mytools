# Hiimage(嘿一妹子)-生成文字图片的php工具类

>必须采用utf8编码
>支持文本文件排版

## UPDATE LIST
* 2016-12-30
 >优化图片生成逻辑
 >增加灵活的配置方式

## 准备工作
* 安装开启GD库
* 安装开启mbstring库

## 使用方法
* 引入文件
* 实例化类
* 调用方法传入参数
* 输出图形

## 生成文章图片
`
<?php
include_once('imgTTF.class.php');
$txt =file_get_contents('test.txt');
$img =new imgTTF();
echo $img->getpagepic($txt,1);
`
## 生成文字小图 (140字以内)
`
<?php
include_once('imgTTF.class.php');
$txt =file_get_contents('test.txt');
$img =new imgTTF();
echo $img->getstrpic($txt);
`
## Api

| 函数           | 参数说明          |
| -------------  |:-------------:    |
| getpagepic     | 1.需要处理的字符串 2.设置 3.生成模式（0传统模式较慢排版校较准确 1 快速模式和传统模式相反|
| getstrpic      | 1.字符串  2.配置  3,字符串数组    |



## 测试

>运行test.php 将会看到如下效果

![getpagepic](https://ww2.sinaimg.cn/mw690/87306f67gw1fb8um5soc9j20go1hy4fw.jpg)

![getstrpic](https://ww4.sinaimg.cn/mw690/87306f67gw1fb8uzibwn7j20m8064q31.jpg)


![rrr](https://ww4.sinaimg.cn/mw690/87306f67gw1fb8v3diexoj20m8064gmq.jpg)
