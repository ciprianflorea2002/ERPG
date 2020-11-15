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
</style>
<html>

<body >
    
    <form action="/leaderboard.php" method="get" id="search">
        <input type="search" id="game" name="game"> <br>
        <button>Find game</button>
    </form>

    <br><br>

<?php


if(count($rows) != 0){

	print('<style type="text/css">
.tftable {font-size:12px;color:#333333;width:100%;border-width: 1px;border-color: #a9a9a9;border-collapse: collapse;}
.tftable th {font-size:12px;background-color:#b8b8b8;border-width: 1px;padding: 8px;border-style: solid;border-color: #a9a9a9;text-align:left;}
.tftable tr {background-color:#cdcdcd;}
.tftable td {font-size:12px;border-width: 1px;padding: 8px;border-style: solid;border-color: #a9a9a9;}
</style>

<table class="tftable" border="1"> 
<tr><th>Username</th><th>Score</th></tr> ');

}

foreach($rows as $r){
    print('<tr> 
		<td>' . $r['username'] . ' </td> 
		<td>' . $r['score']    . ' </td>
	</tr>');
}

if(count($rows) != 0){
    print("</tabel> ");
}

?>

</body>
</html>  
