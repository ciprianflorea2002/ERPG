<?php
$servername = "localhost";
$username = "root";
$password = addslashes($_GET['pass']);
$table = addslashes($_GET['game']) . "_leaderboard";
$user = addslashes($_GET['user']);
$score = addslashes($_GET['score']);
$dbname = "games";


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM information_schema.tables WHERE table_schema = 'games' AND table_name = '" . $table . "' LIMIT 1;";
$result = $conn->query($sql);


if(count($result->fetch_assoc()) == 0){
    $sql = "CREATE TABLE " . $table . " ( username VARCHAR(30) NOT NULL, score INT(6) NOT NULL)";    
    if ($conn->query($sql) === TRUE) {
        echo "Table " . $table . " created successfully";
    } else {
        echo "Error creating table: " . $conn->error;
    }
}

$sql = "INSERT INTO " . $table . "(username, score) VALUES('" . $user . "', " . $score . ") ";
$result = $conn->query($sql);



$conn->close();

?>