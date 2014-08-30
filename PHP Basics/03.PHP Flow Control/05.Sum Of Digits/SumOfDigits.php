<?php
// Task 5:  Write a PHP script SumOfDigits.php which receives a comma-separated list of integers from an input
//          form and creates a two-column table. The first column should contain each of the values from the
//          input. The second column should contain the sum of the digits of each value. If the value is not
//          an integer number, print "I cannot sum that". Styling the page is optional.

header("Content-Type: text/html; charset=utf8");
?>

<!DOCTYPE html>
<html>
<head>
    <title>Sum Of Digits</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<form action="" method="post">
    <label for="numbers">Input string: </label>
    <input type="text" id="numbers" name="numbers"/>
    <input type="submit" value="Submit"/>
</form>
<script>
    document.getElementById('numbers').value = "<?php  echo $_POST['numbers']; ?>";
</script>
<?php
if (!empty($_POST['numbers'])) :
    $numbers = preg_split('/[\s,]+/', htmlentities($_POST['numbers']));
    ?>
    <table>
        <tbody>
        <?php
        for ($i = 0; $i < count($numbers); $i += 1):
            if ($numbers[$i][0] == '-') {
                $currentNum = substr($numbers[$i],1);
            } else {
                $currentNum = $numbers[$i];
            }
            if (ctype_digit($currentNum)) {
                $len = strlen($currentNum);
                $result = 0;
                for ($char = 0; $char < $len; $char++) {
                    $result += (int)($currentNum[$char]);
                }
            } else {
                $result = "I cannot sum that";
            }
            ?>
            <tr>
                <td><?= $numbers[$i] ?></td>
                <td><?= $result; ?></td>
            </tr>
        <?php endfor; ?>
        </tbody>
    </table>
<?php endif; ?>
</body>
</html>