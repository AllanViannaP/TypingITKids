<?php
// Connect to the database
$con = mysqli_connect("localhost", "root", "", "typer");

// Check connection
if (mysqli_connect_errno()) {
    echo json_encode(["error" => "Failed to connect to MySQL"]);
    exit();
}

// Fetch words from the database
$query = "SELECT word FROM words;";
$result = mysqli_query($con, $query);

if (!$result) {
    echo json_encode(["error" => "Query failed"]);
    exit();
}

// Store words in an array
$wordsArray = [];
while ($row = mysqli_fetch_assoc($result)) {
    $wordsArray[] = $row['word'];
}

// Return JSON response
header('Content-Type: application/json');
echo json_encode(["words" => $wordsArray]);
?>
