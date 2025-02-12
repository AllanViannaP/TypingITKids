<?php
    // This file is used to register a new user to the database
    $con = mysqli_connect("localhost", "root", "", "typer");

    // Check connection
    if(mysqli_connect_errno()){
        echo "1: Failed to connect to MySQL: " . mysqli_connect_error(); // Error code #1 = failed to connect to MySQL
        exit();
    }

    // Get the data from the form
    $nick = $_POST["nick"];
    $password = $_POST["password"];
    $email = $_POST["email"];

    // Check if the name or email already exists
    $namecheckquery = "SELECT nick FROM users WHERE nick='" . $nick . "';";
    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); // Error code #2 = name check query failed
    $emailcheckquery = "SELECT email FROM users WHERE email='" . $email . "';";
    $emailcheck = mysqli_query($con, $emailcheckquery) or die("3: Email check query failed"); // Error code #3 = email check query failed

    if(mysqli_num_rows($namecheck) > 0){
        echo "4: Name already exists"; // Error code #4 = name exists cannot register
        exit();
    }
    if(mysqli_num_rows($emailcheck) > 0){
        echo "5: Email already exists"; // Error code #5 = email exists cannot register
        exit();
    }

    //Add user to the table
    $salt = "\$5\$rounds=5000\$" . "steamedhams" . $nick . "\$"; // $5$ is the algorithm, 5000 is the number of rounds, steamedhams is the salt, $nick is the username
    $hash = crypt($password, $salt); // Hash the password with the salt
    $insertuserquery = "INSERT INTO users (nick, hash, salt, email) VALUES ('" . $nick . "', '" . $hash . "', '" . $salt . "', '" . $email . "');";

    mysqli_query($con, $insertuserquery) or die("6: Insert player query failed"); // Error code #6 = insert query failed

    echo "0"; // No error


?>