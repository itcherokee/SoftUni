<?php
// Task 03: Write a PHP script CalculateInterest.php which generates an HTML page that contains:
//          •	An input text field to hold the amount of money
//          •	Radio buttons to choose the currency
//          •	An input text field to enter the compound annual interest amount
//          •	A dropdown menu to choose the period of time
//          •	A submit button
//          When the information is submitted, the script should print out the amount of money you
//          will have after the selected period, rounded to 2 decimal places.
//          Semantic HTML is required. Styling is not required.

header('Content-Type: text/html; charset=utf-8');

$result = '';
if (isset($_GET['amount']) && isset($_GET['currency']) && isset($_GET['interest']) && isset($_GET['period'])) {
    if (!empty($_GET['amount']) && is_numeric(($_GET['amount'])) &&
        !empty($_GET['currency']) &&
        !empty($_GET['interest']) && is_numeric(($_GET['interest'])) &&
        !empty($_GET['period'])
    ) {
        $investment = (float)$_GET['amount'];
        $interest = (float)$_GET['interest'] / 100 / 12;
        $period = (int)$_GET['period'];
        $currency = $_GET['currency'];
        $result = number_format($investment * pow((1 + $interest), ($period)), 2, ".", "");
        if ($currency === 'лв') {
            $result .= " " . $currency;
        } else {
            $result = $currency . " " . $result;
        }
    } else {
        $result = "Invalid data provided!!!";
    }
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Calculate Interest</title>
</head>
<body>
<section>
    <form action="" method="get">
        <label for="amount">Enter Amount</label>
        <input type="text" name="amount" id="amount"/><br/>
        <input type="radio" name="currency" value="$"/>USD
        <input type="radio" name="currency" value="€"/>EUR
        <input type="radio" name="currency" value="лв"/>BGN<br/>
        <label for="interest">Compound Interest Amount</label>
        <input type="text" name="interest" id="interest"/><br/>
        <select name="period">
            <option hidden="hidden" value="">Period...</option>
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>
        <input type="submit" value="Calculate"/>
        <?= $result ?>
    </form>
</section>
</body>
</html>