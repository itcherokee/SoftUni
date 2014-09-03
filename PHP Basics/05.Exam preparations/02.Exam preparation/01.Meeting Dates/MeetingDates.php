<?php
date_default_timezone_set('Europe/Sofia');

$dateOne = strtotime($_GET['dateOne']);
$dateTwo = strtotime($_GET['dateTwo']);
if ($dateOne > $dateTwo) {
    $switchDate = $dateOne;
    $dateOne = $dateTwo;
    $dateTwo = $switchDate;
}

$currentDate = $dateOne;
$result = '';
$offset = 1;
while ($currentDate <= $dateTwo) {
    if (date('N', $currentDate) == 4) {
        $formatedDate = date('d-m-Y', $currentDate);
        $result .= "<li>{$formatedDate}</li>";
        $offset = 7;
    }

    $currentDate = strtotime("+$offset day", $currentDate);
}

if ($result == '') {
    echo "<h2>No Thursdays</h2>";
} else {
    echo "<ol>{$result}</ol>";
}