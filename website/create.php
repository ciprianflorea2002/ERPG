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
<script>
    const firebaseConfig = {
    apiKey: "AIzaSyCRfqkLeHNBi9iPSuAEi3fcHqlcW9wcur0",
    authDomain: "erpg-295700.firebaseapp.com",
    databaseURL: "https://erpg-295700.firebaseio.com",
    projectId: "erpg-295700",
    storageBucket: "erpg-295700.appspot.com",
    messagingSenderId: "1094285983498",
    appId: "1:1094285983498:web:3badb50ceabbcd5a57c4f3",
    measurementId: "G-1SEQ7J74B7"
  };
    </script>
<!-- The core Firebase JS SDK is always required and must be listed first -->
<script src="/__/firebase/8.0.2/firebase-app.js"></script>

<!-- TODO: Add SDKs for Firebase products that you want to use
     https://firebase.google.com/docs/web/setup#available-libraries -->
<script src="/__/firebase/8.0.2/firebase-analytics.js"></script>

<!-- Initialize Firebase -->
<script src="/__/firebase/init.js"></script> </body>
';

?>
