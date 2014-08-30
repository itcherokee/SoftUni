<?php
// Task 1:  Write a PHP script SquareRootSum.php that displays a table in your browser with 2 columns.
//          The first column should contain a number (even numbers from 0 to 100) and the second column
//          should contain the square root of that number, rounded to the second digit after the decimal
//          point. The last row of the table should contain the sum of all values in the Square column.
//          Styling the page is optional.

header("Content-Type: text/html; charset=utf8");
?>

<!DOCTYPE html>
<html>
<head>
    <title>Square Root Sum</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<table>
    <thead>
    <tr>
        <th>Number</th>
        <th>Square</th>
    </tr>
    </thead>
    <tbody>
    <?php
    for ($i = 0, $sum = 0; $i <= 100; $i += 2):
        $result = round(sqrt($i), 2);
        $sum += $result;
        ?>
        <tr>
            <td><?= $i ?></td>
            <td><?= $result; ?></td>
        </tr>
    <?php endfor; ?>
    </tbody>
    <tfoot>
    <tr>
        <td>Total:</td>
        <td><?= round($sum, 2); ?></td>
    </tr>
    </tfoot>
</table>
</body>
</html>