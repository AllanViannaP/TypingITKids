<?php
// Set content type to JSON
header("Content-Type: application/json");

// Database connection details
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "typer";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    // If connection fails, return error message
    die(json_encode(["error" => "Database connection failed"]));
}

// Check if deck_id is passed in the request
if (!isset($_GET["id_deck"])) {
    // If deck_id is missing, return error message
    die(json_encode(["error" => "Missing deck_id parameter"]));
}

// Get the deck_id from the request
$deck_id = intval($_GET["id_deck"]);

// SQL query to fetch words associated with the deck_id
$sql = "SELECT w.Word FROM words w JOIN wordlist wl ON w.ID = wl.ID_Word WHERE wl.ID_Deck = ?";

// Prepare the SQL statement
$stmt = $conn->prepare($sql);
$stmt->bind_param("i", $deck_id);
$stmt->execute();
$result = $stmt->get_result();

// Initialize an empty array to store words
$words = [];

// Fetch words from the result
while ($row = $result->fetch_assoc()) {
    $words[] = $row["Word"];
}

// Check if words are found for the given deck_id
if (empty($words)) {
    // If no words found, return an error message
    echo json_encode(["error" => "No words found for the given deck"]);
} else {
    // If words are found, return them in JSON format
    echo json_encode(["words" => $words]);
}

// Close the statement and connection
$stmt->close();
$conn->close();
?>
