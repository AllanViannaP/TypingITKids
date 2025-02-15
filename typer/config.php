<?php
// config.php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "typer";

// Conexão com o banco de dados
$conn = new mysqli($servername, $username, $password, $dbname);

// Verifica se a conexão foi bem-sucedida
if ($conn->connect_error) {
    die(json_encode(["error" => "Database connection failed"]));
}
?>
