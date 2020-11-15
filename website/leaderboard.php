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
?>

<!DOCTYPE html>
<style>
</style>
<html>

<body >
    
    <form action="/ERPG/leaderboard.php" method="get" id="search">
        <input type="search" id="game" name="game"> <br>
        <button>Find game</button>
    </form>

    <br><br>

<?php

if ($result->num_rows > 0) {
  // output data of each row
  $rows = array();
  while($row = $result->fetch_assoc()) {
    $rows[] = $row;
  }
} 

if(count($rows) != 0){
    echo '<tabel> <tr> <th> User </th> <th> Score </th> </tr>';
}

foreach($rows as $r){
    echo '<tr> 
		<th>' . $r['username'] . ' </th> 
		<th>' . $r['score']    . ' </th>
	</tr>';
}

if(count($rows) != 0){
    echo "</tabel> ";
}

?>


</body>
</html>  
