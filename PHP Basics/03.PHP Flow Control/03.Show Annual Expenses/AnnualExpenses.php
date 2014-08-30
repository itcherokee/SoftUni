<?php
// Task 3:  Write a PHP script AnnualExpenses.php that receives n years from an input HTML form
//          and creates a table (like the one shown below) with random expenses by months and
//          the corresponding years (n years back). For example, if N is 10, create a table that
//          shows the expenses for each month for the last 10 years. Add a "Total" column at the end,
//          showing the total expenses for the same year. The random expenses in the table should be
//          in the range [0…999]. Styling the page is optional.

header("Content-Type: text/html; charset=utf8");
$headers = ['Year', 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August',
    'September', 'October', 'November', 'December', 'Total:'];
?>

<!DOCTYPE html>
<html>
<head>
    <title>Annual Expenses</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<form action="" method="post">
    <label for="years">Enter number of years: </label>
    <input type="text" id="years" name="years"/>
    <input type="submit" value="Show costs"/>
</form>
<script>
    document.getElementById('years').value = "<?php  echo $_POST['years']; ?>";
</script>
<?php
if (!empty($_POST['years'])) :
    if (htmlentities($_POST['years']) < 0) {
        $period = 1;
    } else {
        $period = htmlentities($_POST['years']);
    }
    ?>
    <table>
        <thead>
        <tr>
            <?php for ($i = 0; $i < count($headers); $i++): ?>
                <th><?= $headers[$i] ?></th>
            <?php endfor; ?>
        </tr>
        </thead>
        <tbody>
        <?php
        $year = (int)(date('Y', time()));
        for ($i = $year; $i > $year - $period; $i -= 1):
            $total = 0;
            ?>
            <tr>
                <?php for ($month = 0; $month < count($headers); $month++):
                    if ($month === 0) {
                        $field = $i;
                    } elseif ($month === count($headers) - 1) {
                        $field = $total;
                    } else {
                        $field = rand(0, 999);
                        $total += $field;
                    }
                    ?>
                    <td><?= $field; ?></td>
                <?php endfor; ?>
            </tr>
        <?php endfor; ?>
        </tbody>
    </table>
<?php endif; ?>
</body>
</html>