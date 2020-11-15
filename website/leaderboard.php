<?php
$servername = "localhost";
$username = "root";
$password = "oxhackERPG2020";
$table = addslashes($_GET['game']);
$dbname = "games";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$result = $conn->query("SELECT * FROM " . $table . "_leaderboard ");

$conn->close();


function sortScore($a, $b) {
    return $a['score'] < $b['score'];
}


if ($result->num_rows > 0) {
  // output data of each row
  $rows = array();
  while($row = $result->fetch_assoc()) {
    $rows[] = $row;
  }
}

usort($rows, 'sortScore');

?>

<!DOCTYPE html>
<style>

.center {

  margin: auto;

}
.btn-group button {
  display: flex;
  justify-content: center;
  background-color: #4CAF50; /* Green background */
  border: 1px solid green; /* Green border */
  color: white; /* White text */
  padding: 7% 10px; /* Some padding */
  cursor: pointer; /* Pointer/hand icon */
  width: 90%; /* Set a width if needed */ 
  display: block; /* Make the buttons appear below each other */
  font-size: 3vw;
}
.title {
  color: white;
  display: flex;
  justify-content: center;
  margin: auto;
  font-size: 5vw;
} 

.info {
  color: white;
  position: fixed;
  left: 0; 
  bottom: 0;
  width: 100%;
  font-size: 1.5vw;
  text-align: center; 
}

/* Add a background color on hover */
.btn-group button:hover {
  background-color: #3e8e41;
}

.float-child {
    width: 33%;
    float: left;
    margin: auto;
}  



.footer {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  color: white;
  font-size: 1vw;
  text-align: center;
}

</style>
<html>

<body style="background-color:rgb(41,41,41);"> 
    <br>
    <div class="center title">  ERPG </div>
    <br>
<div>
 <div class="float-child">  <img src="images/player.gif" width=80%/>  </div> 
 
<?php

  $html = '<div class=" float-child center">   

    <form class="center" action="/leaderboard.php" method="get" id="search">
        <input type="search" id="game" name="game"> <br>
        <button>Find game</button>
    </form>

    <br><br>  
    <style type="text/css">
.tftable {font-size:12px;color:#333333;width:100%;border-width: 1px;border-color: #a9a9a9;border-collapse: collapse;}
.tftable th {font-size:12px;background-color:#b8b8b8;border-width: 1px;padding: 8px;border-style: solid;border-color: #a9a9a9;text-align:left;}
.tftable tr {background-color:#cdcdcd;}
.tftable td {font-size:12px;border-width: 1px;padding: 8px;border-style: solid;border-color: #a9a9a9;}
</style>

<table class="tftable" border="1"> 
<tr><th>Username</th><th>Score</th></tr> ';

foreach($rows as $r){
    $html += '<tr> 
		<td>' . $r['username'] . ' </td> 
		<td>' . $r['score']    . ' </td>
	  </tr>';
}

$html += '</tabel>

 </div>

 <div class="float-child"> <br><br> <br><img src="images/boss.gif" width="80%" style="float: right;"/>  </div> 
</div>


<div class="footer">
    <p>Made @ OxfordHack 2020</p> 
</div>';

echo $html;

?>


</body>

</html> 
