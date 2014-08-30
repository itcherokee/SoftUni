<?php
// Task 4:  Write a PHP script PrimesInRange.php that receives two numbers – start and end – from
//          an input field and displays all numbers in that range as a comma-separated list.
//          Prime numbers should be bolded. Styling the page is optional.

header("Content-Type: text/html; charset=utf8");

function parseInput($data)
{
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlentities($data);
    return $data;
}

function isValidInteger($value)
{
    if (is_numeric($value)) {
        if (is_float($value)) {
            return false;
        } else {
            return true;
        }
    }

    return false;
}

function isPrime($value)
{
    if (isValidInteger($value)) {
        $number = (int)$value;
        if ($value <= 1) {
            return false;
        }
    } else {
        return false;
    }

    $isPrime = true;
    $divider = 2;
    $maxDivider = round(sqrt($number), 0, PHP_ROUND_HALF_UP);
    while ($divider <= $maxDivider) {
        if ($value % $divider === 0) {
            $isPrime = false;
            break;
        }

        $divider += 1;
    }

    return $isPrime;
}

$error = '';
?>

<!DOCTYPE html>
<html>
<head>
    <title>Find Primes in Range</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<form action="" method="post">
    <label for="start-index">Starting Index: </label>
    <input type="text" name="start-index" id="start-index"/>
    <label for="end-index">End: </label>
    <input type="text" name="end-index" id="end-index"/>
    <input type="submit" value="Submit"/>

</form>
<script>
    document.getElementById('start-index').value = "<?= htmlentities($_POST['start-index']); ?>";
    document.getElementById('end-index').value = "<?= htmlentities($_POST['end-index']); ?>";
</script>
<div>
    <?php
    if (!empty($_POST['start-index']) && !empty($_POST['end-index'])):
        $startIndex = parseInput($_POST['start-index']);
        $endIndex = parseInput($_POST['end-index']);
        if (isValidInteger($startIndex) && isValidInteger($endIndex)):
            if ($startIndex <= $endIndex):
                for ($i = $startIndex; $i <= $endIndex; $i++):
                    if (isPrime($i)): ?>
                        <span class="prime"><?= $i ?></span>
                    <?php
                    else:
                        echo $i;
                    endif;
                    if ($i !== $endIndex) {
                        echo ", ";
                    }
                endfor;
            else: ?>
                <span class="error"> * Start index must be smaller that End index!</span>
            <?php endif;
        else: ?>
            <span class="error"> * Invalid input data detected!</span>
        <?php endif;
    endif; ?>
</div>
</body>
</html>