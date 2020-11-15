<?php
$servername = "localhost";
$username = "root";
$password = "oxhackERPG2020";
$table = addslashes($_GET['game']);
$dbname = "games";


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM information_schema.tables WHERE table_schema = 'games' AND table_name = '" . $table . "' LIMIT 1;";
$result = $conn->query($sql);


if(count($result->fetch_assoc()) != 0){
        echo 'true';
} else {
        echo 'false';
}


$conn->close();

?>