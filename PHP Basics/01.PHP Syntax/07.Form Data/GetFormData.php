<?php
// Task 07: Write a PHP script GetFormData.php which retrieves the input data
//          from an HTML form, and displays it as string. The input fields
//          should hold name, age and gender (radio buttons). The returned
//          string should be a message containing the information submitted
//          by the form. 100% accuracy is NOT required. Semantic HTML is required.
?>

<!DOCTYPE html>
<html>
<head>
    <title>Form Data</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<main>
    <form action="" method="get">
        <input type="text" name="name" placeholder="Name"/>
        <input type="text" name="age" placeholder="Age"/>

        <div><input type="radio" name="gender" value="male"/>Male</div>
        <div><input type="radio" name="gender" value="female"/>Female</div>
        <input type="submit"/>
    </form>
    <?php
    if (isset($_GET['name']) && $_GET['name'] !== '' && isset($_GET['age']) && $_GET['age'] !== '') {
        echo "<p>My name is " . htmlentities($_GET['name']) . ". ";
        echo "I am " . htmlentities($_GET['age']) . " year(s) old. ";
        echo "I am ";
        $gender = isset($_GET['gender']) ? htmlentities($_GET['gender']) : '';
        switch ($gender) {
            case "male":
                echo "male";
                break;
            case "female":
                echo "female";
                break;
            default:
                echo "unknown";
                break;
        }
        echo ' gender.</p>';
    }
    ?>
</main>
</body>
</html>