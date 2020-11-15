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


if(count($result->fetch_assoc()) == 0){
    $sql = "CREATE TABLE " . $table . " (question VARCHAR(30) NOT NULL, difficulty INT(2) NOT NULL, answer VARCHAR(30) NOT NULL, wanswer1 VARCHAR(30) NOT NULL, wanswer2 VARCHAR(30) NOT NULL, wanswer3 VARCHAR(30) NOT NULL)";
    $conn->query($sql);
}

$count = count($_POST['question']);

$it = 0;


while ($it < $count){
    $q = addslashes($_POST['question'][$it]);
    $dif = addslashes($_POST['dif'][$it]);
    $ans1 = addslashes($_POST['ans1'][$it]);
    $ans2 = addslashes($_POST['ans2'][$it]);
    $ans3 = addslashes($_POST['ans3'][$it]);
    $ans4 = addslashes($_POST['ans4'][$it]);


    $sql = "INSERT INTO " . $table . "(question, difficulty, answer, wanswer1, ".
    "wanswer2, wanswer3) VALUES('" . $q . "', " . $dif . ", '" .
    $ans1 . "', '" . $ans2. "', '" . $ans3 . "', '" . $ans4 . "') ";


    $result = $conn->query($sql);
    $it++;
}

$conn->close();

echo '<body> 

<h1> Game code: ". $table ."  </h1> 

</body>';

?>
