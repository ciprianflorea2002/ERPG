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

$result = $conn->query($sql);

$val = mysql_query('select 1 from'. $table . 'LIMIT 1');

echo $val ? 'true' : 'false';

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