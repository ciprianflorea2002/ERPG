<?php
$servername = "localhost";
$username = "root";
$password = addslashes($_GET['pass']);
$table = addslashes($_GET['game']);
$question = addslashes($_GET['question']);
$difficulty = addslashes($_GET['dif']);
$answer = addslashes($_GET['ans']);
$wanswer1 = addslashes($_GET['wans1']);
$wanswer2 = addslashes($_GET['wans2']);
$wanswer3 = addslashes($_GET['wans3']);
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
    $sql = "CREATE TABLE " . $table . " (question VARCHAR(30) NOT NULL, difficulty INT(2) NOT NULL, answer VARCHAR(30) NOT NULL, wanswer1 VARCHAR(30) NOT NULL, wanswer2 VARCHAR(30) NOT NULL, wanswer3 VARCHAR(30) NOT NULL)";    
    if ($conn->query($sql) === TRUE) {
        echo "Table " . $table . " created successfully";
    } else {
        echo "Error creating table: " . $conn->error;
    }
}

$sql = "INSERT INTO " . $table . "(question, difficulty, answer, wanswer1, ".
"wanswer3, wanswer3) VALUES('" . $question . "', " . $difficulty . ", '" .
 $answer . "', '" . $wanswer1. "', '" . $wanswer2 . "', '" . $wanswer3. "') ";


$result = $conn->query($sql);



$conn->close();

?>