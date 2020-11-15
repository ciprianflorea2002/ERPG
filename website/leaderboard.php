<?php
$servername = "localhost";
$username = "root";
$password = "oxhackERPG2020";
$table = addslashes($_GET['game']);
$dbname = "games";

if($table == ""){
    echo '
    <!DOCTYPE html>
<style>
</style>
<html>

<body >
    
    <form action="/ERPG/leaderboard.php" method="get" id="search">
        <input type="search" id="game" name="game"> <br>
        <button>Find game</button>
    </form>
    

</body>
</html> ';
return;
} 

echo $table;

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}


?>