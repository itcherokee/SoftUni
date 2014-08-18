<?php
// Task 06: Write a PHP script InformationTable.php which generates an HTML table
//          by given information about a person (name, phone number, age, address).
//          Styling the table is optional. Semantic HTML is required.

function GenerateTable($name, $phone, $age, $address)
{
    $result = "<tr><td>Name</td><td>$name</td></tr>";
    $result .= "<tr><td>Phone number</td><td>$phone</td></tr>";
    $result .= "<tr><td>Age</td><td>$age</td></tr>";
    $result .= "<tr><td>Address</td><td>$address</td></tr>";
    return "<table><tbody>$result</tbody></table>";
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>HTML Table</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<section>
    <?= GenerateTable("Goshko", "0882-321-423", 24, "Hadji Dimitar"); ?>
    <?= GenerateTable("Pesho", "0884-888-888", 67, "Suhata Reka"); ?>
</section>
</body>
</html>