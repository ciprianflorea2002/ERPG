<?php
$servername = "localhost";
$username = "root";
$password = $_GET['pass'];
$table = $_GET['game'];
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




$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_errno) {
    printf("Connect failed: %s\n", $con->connect_error);
    exit();
}
if ($result = $conn->query($sql)) {
    // $result is an object and can be used to fetch row here
}
else {
    printf("Query failed: %s\n", $conn->error);
}

$conn->close();

?>