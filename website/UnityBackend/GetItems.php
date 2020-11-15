<?php
$servername = "localhost";
$username = "root";
$password = addslashes($_GET['pass']);
$table = addslashes($_GET['game']);
$dbname = "games";


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT question, difficulty, answer, wanswer1, wanswer2, wanswer3 FROM " . $table;                      

$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  $rows = array();
  while($row = $result->fetch_assoc()) {
    $rows[] = $row;
  }
  echo json_encode($rows);
} else {
  echo "0";
}

$conn->close();

?>
