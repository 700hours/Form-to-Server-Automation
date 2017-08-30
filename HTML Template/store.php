<?php
date_default_timezone_set('UTC');
$date = new DateTime();
$date->getTimestamp();
$datetime = $date->format('Y-m-d H:i:s');
if(isset($_POST['players']) && isset($_POST['worldsize']) && isset($_POST['worldname']) && isset($_POST['id']) && isset($_POST['tshock']) && (int)($_POST['players']) > 7 && (int)($_POST['players']) < 256 && (int)($_POST['worldsize']) < 4 && (int)($_POST['language']) < 6 && (int)($_POST['tshock']) < 2 && $_POST['password'] != 'Optional') {
    $params = 'set name=' . $_POST['id'] . ';' . 'set players=' . $_POST['players'] . ';' . 'set worldsize=' . $_POST['worldsize'] . ';' . 'set worldname=' . $_POST['worldname'] . ';' . 'set password=' . $_POST['password'] . ';' . 'set motd=' . $_POST['motd'] . ';' . 'set language=' . $_POST['language'];
    $uID = $_POST['id'];
	$ts = 'set tshock=' . $_POST['tshock'];
	$em = $datetime . "\n" . 'Forum Name: ' . $_POST['forumid'] . "\n" . 'Email: ' . $_POST['email'] . "\n" . 'Server ID: ' .$_POST['id'] . "\n" . 'Players: ' . $_POST['players'] . "\n" . 'World Size: ' . $_POST['worldsize'] . "\n" . 'World Name: ' . $_POST['worldname'] . "\n" . 'Password: ' . $_POST['password'] . "\n" . 'MOTD: ' . $_POST['motd'] . "\n" . 'TShock: ' . $_POST['tshock'] ."\n" . 'Language: ' . $_POST['language'];
	 $message = wordwrap($em, 70, "\r\n");
	 mail('email@mail.com', 'server contact', $message); #Add you supportE-mail address
	$ret = file_put_contents('serverparams.html', $params, LOCK_EX);
	$ret = file_put_contents('serverid.cmd', $uID, LOCK_EX);
	$ret = file_put_contents('check_tshock.cmd', $ts, LOCK_EX);
    if($ret === false) {
        die('<p style="margin:0px; padding:0px; opacity:0.4; color:red font-family:Verdana, Geneva, sans-serif;;">Process Error</p><br>');
    }
    else {
        echo '<p style="margin:0px; padding:0px; opacity:0.5; color:black; font-family:Verdana, Geneva, sans-serif;">Success</p><br>';
    }
	if($ter === false) {
        die('<p style="margin:0px; padding:0px; opacity:0.4; color:red; font-family:Verdana, Geneva, sans-serif;">Process Error</p><br>');
    }
    else {
        echo '<p style="margin:0px; padding:0px; opacity:0.4; color:black; font-family:Verdana, Geneva, sans-serif;">Success</p><br>';
    }
	if($ert === false) {
        die('<p style="margin:0px; padding:0px; opacity:0.4; color:red; font-family:Verdana, Geneva, sans-serif;">Process Error</p>');
    }
    else {
        echo '<p style="margin:0px; padding:0px; opacity:0.3; color:black; font-family:Verdana, Geneva, sans-serif;">Success</p>';
    }
}
else {
   die('<p style="margin:0px; padding:0px; opacity:0.5; color:slate; font-family:Verdana, Geneva, sans-serif;">Error in form input, <a href="form.html">retry?</a></p>');
}
?>
<html>
<head>
<<title>TEMPLATE</title>
<!--   123456789 123456789 123456789 123456789 123456789 123456789 123456789  
                1         2         3         4         5         6         7 -->

<meta name="description" 
content="">

<meta name="keywords" 
content="">

<meta name="robots" content="all,index,follow">
<meta name="revisit-after" content="7 days">
<link rel="stylesheet" type="text/css" href="forms.css">
</head>
<div class="finalizebox">
<div class="topbox" style="background-color:#BDBDBD;"><p align="right" style="margin:0px; padding:6px 10px 0px 0px;"><font face="Verdana" size="3" color="#515151">Details</font></p></div>
<div class="leftfinbox" style="background-color:#BDBDBD;">
<font face="Verdana" size="2" color="#515151">
<div class="textalign">
	 Players 
<br> World Size
<br> World Name
<br> Password
<br> Server Message
<br> Language
<br> Unique ID
<br> TShock
<br> Forum Name
<br> Email Address</font>
</div>
</div>
<div class="middlefinbox" style="background-color:#A4A4A4;"></div>
<div class="rightfinbox" style="background-color:#BDBDBD;">
<font face="Verdana" size="2" color="#404040">
<div class="textalign">
	 <?php echo htmlspecialchars((int)$_POST['players']); ?>
<br> <?php echo htmlspecialchars((int)$_POST['worldsize']); ?>
<br> <?php echo htmlspecialchars($_POST['worldname']); ?>
<br> <?php echo htmlspecialchars($_POST['password']); ?>
<br> <?php echo 'motd'; ?>
<br> <?php echo htmlspecialchars((int)$_POST['language']); ?>
<br> <?php echo htmlspecialchars($_POST['id']); ?>
<br> <?php echo htmlspecialchars((int)$_POST['tshock']); ?>
<br> <?php echo '***'; ?>
<br> <?php echo '***'; ?> </font>
</div>
</div>
<div class="bottombox">
<div class="align">
<form action="finalized.html">
<input type="submit" value="Forward">
</form>
</div>
</div>
</html>