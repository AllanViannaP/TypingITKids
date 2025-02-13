# Typing Game Project

This project is a typing game where users can train their typing skills using words stored in a database. The game uses Unity for the front-end and PHP for the back-end to handle database communication.

## Prerequisites

To run this project, you will need the following:

- **Unity**: The game is developed using Unity, so make sure you have it installed.
- **XAMPP**: A local web server environment for running PHP and MySQL on your computer.

## Setting Up XAMPP and the Project

### Step 1: Install XAMPP

1. **Download XAMPP**:
   - Go to the [XAMPP official website](https://www.apachefriends.org/index.html) and download the installer for your operating system (Windows, macOS, or Linux).
   - Choose the appropriate version for your system and download it.

2. **Install XAMPP**:
   - Run the installer you downloaded and follow the installation instructions.
   - During the installation, ensure that you install both **Apache** and **MySQL**, as these will be used to run the web server and manage the database for this project.

3. **Start XAMPP**:
   - Open the **XAMPP Control Panel** (it should be in your start menu or desktop after installation).
   - Start the **Apache** and **MySQL** services by clicking on the "Start" button next to each service.
   - The **Apache** service will run your local web server, and **MySQL** will allow you to run the database.

### Step 2: Set Up the `typer` Folder in XAMPP

1. **Download or Clone the Project**:
   - If you haven't already, download or clone the project repository to your local machine.

2. **Move the Project Files to XAMPP's `htdocs` Folder**:
   - Navigate to the directory where XAMPP was installed (usually `C:\xampp` on Windows).
   - Open the `htdocs` folder located inside the XAMPP installation folder (`C:\xampp\htdocs`).
   - Place the `typer` project folder inside `htdocs` (i.e., `C:\xampp\htdocs\typer`).

### Step 3: Set Up the Database

1. **Open phpMyAdmin**:
   - Open a browser and go to `http://localhost/phpmyadmin/`.
   - This will open the phpMyAdmin interface where you can manage your MySQL databases.

2. **Create the Database**:
   - In phpMyAdmin, click on the "Databases" tab.
   - Create a new database called `typer`.

3. **Import the Database Schema**:
   - After creating the database, click on the newly created `typer` database.
   - Go to the "Import" tab in the top menu.
   - Click on "Choose File" and select the `.sql` file (provided with the project or created separately) that contains the schema for the `words` and `wordlist` tables.
   - Click "Go" to import the schema and create the necessary tables.

### Step 4: Configure PHP to Use Your Database Credentials

1. **Edit the PHP Database Connection**:
   - Navigate to the `typer` folder in `htdocs` (`C:\xampp\htdocs\typer`).
   - Open the `get_words.php` file inside the `typer` folder.
   - Find the following lines and update them with your MySQL database credentials:

   ```php
   $servername = "localhost";  // Keep this as "localhost"
   $username = "root";         // Default MySQL username in XAMPP is "root"
   $password = "";             // Default MySQL password in XAMPP is an empty string
   $dbname = "typer";          // This should match the database name you created in phpMyAdmin
   ```

2. **Save the Changes.**

### Step 5: Run Unity and check
