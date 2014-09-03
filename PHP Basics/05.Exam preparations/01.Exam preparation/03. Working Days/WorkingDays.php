<?php
date_default_timezone_set('Europe/Sofia');

$firstDate = $_GET['dateOne'];
$secondDate = $_GET['dateTwo'];
$holidaysList = preg_split('/\s+/', $_GET['holidays'], -1, PREG_SPLIT_NO_EMPTY);

$holidays = array();
foreach ($holidaysList as $day) {
    $holidays[] = strtotime($day);
}

$result = '';

$startDate = strtotime($firstDate);
$endDate = strtotime($secondDate);
$workingDays = array();

while ($startDate <= $endDate) {
    if (date('N', $startDate) < 6 && !in_array($startDate, $holidays)) {
        $workingDays[] = $startDate;
    }

    $startDate = strtotime("+1 day",$startDate);
}

if (count($workingDays)){
    $result = "<ol>";
    for($i = 0; $i < count($workingDays); $i++){
        $day = date("d-m-Y",$workingDays[$i]);
        $result .= "<li>{$day}</li>";
    }

    $result .= "</ol>";
} else {
    $result = "<h2>No workdays</h2>";
}

echo $result;
?>
