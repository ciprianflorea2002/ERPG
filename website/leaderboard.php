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

$data = $conn->query("SELECT (username, score) FROM " . $table . "_leaderboard ");
echo $data;

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

if(count($data) != 0){
    echo "<tabel> <tr> <th> User </th> <th> Score </th> </tr> <\n>";
}

foreach($data as $row){
    echo "<tr> " . $row . "</tr>";
}

if(count($data) != 0){
    echo "</tabel> ";
}

?>


</body>
</html>  