<?php
$name = trim($_GET['name']);
$pin = trim($_GET['pin']);
$gender = trim($_GET['gender']);

function checkPin($pin, $gender)
{
    if (strlen($pin) !== 10) {
        return false;
    }

    $pinAsArray = preg_split('//', $pin, -1, PREG_SPLIT_NO_EMPTY);
    $date = substr($pin, 0, 6);
    $year = (int)(substr($date, 0, 2));
    $day = (int)(substr($date, 4, 2));
    if ($date[2] > 3) { // after year 2000
        $year = 2000 + $year;
        $month = (int)(substr($date, 2, 2)) - 40;
    } else if ($date[2] > 1) { // before year 1900
        $year = 1800 + $year;
        $month = (int)(substr($date, 2, 2)) - 20;
    } else {
        $year = 1900 + $year;
        $month = (int)(substr($date, 2, 2));
    }
    if (!checkdate($month, $day, $year)) {
        return false;
    }

    // check gender
    $testGender = (int)substr($pin, 8, 1) % 2 === 0 ? 'male' : 'female';
    if ($testGender !== $gender) {
        return false;
    }

    // check checksum
    $checksum = (int)substr($pin, 9, 1);
    $weights = array(2, 4, 8, 5, 10, 9, 7, 3, 6);
    $sum = 0;
    for ($i = 0; $i < 9; $i++) {
        $sum += $pinAsArray[$i] * $weights[$i];
    }

    $remainder = $sum % 11 > 9 ? 0 : $sum % 11;
    if ($remainder !== $checksum) {
        return false;
    }

    return true;
}

$names = preg_split('/\s+/', $name, -1, PREG_SPLIT_NO_EMPTY);
if (checkPin($pin, $gender) && count($names) == 2 && $name === ucwords($name)) {
    echo json_encode(array('name' => $name, 'gender' => $gender, 'pin' => $pin));
} else {
    die("<h2>Incorrect data</h2>");
};


