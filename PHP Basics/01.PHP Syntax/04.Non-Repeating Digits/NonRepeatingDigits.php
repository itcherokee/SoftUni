<?php
// Task 04: Write a PHP script NonRepeatingDigits.php that declares an integer variable N,
//          and then finds all 3-digit numbers that are less or equal than N (<= N) and
//          consist of unique digits. Print "no" if no such numbers exist.

//$n = 1234;
//$n = 145;
//$n = 15;
//$n = 247;
//$n = 102;
$n = 103;
//$n = 101;

if ($n < 102) {
    echo "no";
} else {
    if ($n > 987) {
        $n = 987;
    }

    $isFirst = true;
    for ($i = 102; $i <= $n; $i++) {
        // first solution - comment to test second solution
//        $numAsString = (string)($i);
//        if ($numAsString[0] != $numAsString[1] && $numAsString[1] != $numAsString[2] && $numAsString[0] != $numAsString[2]) {
//            if (!$isFirst) {
//                echo ", ";
//            } else {
//                $isFirst = !$isFirst;
//            }
//
//            echo $numAsString;
//        }

        // second solution - comment to test first solution
        $units = $i % 10;
        $tens = $i / 10 % 10;
        $hundreds = $i / 100;
        if ($units != $tens && $tens != $hundreds && $units != $hundreds) {
            if (!$isFirst) {
                echo ", ";
            } else {
                $isFirst = !$isFirst;
            }

            echo $i;
        }
    }
}

?>