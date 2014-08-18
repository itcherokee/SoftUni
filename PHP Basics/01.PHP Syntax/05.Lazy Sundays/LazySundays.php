<?php
// Task 05: Write a PHP script LazySundays.php which prints the dates of all Sundays in the current month.

$currentDate = getdate();
$currentMonth = $currentDate['mon'];
$currentMonthName = $currentDate['month'];
$currentYear = $currentDate['year'];
for ($i = 1; $i <= 31; $i++){
    $current = getdate(strtotime("$currentYear-$currentMonth-$i"));
    if($current['wday'] === 0 && $current['mon'] === $currentMonth){
        $numbering = 'th';
        switch ($i){
            case 1:
                $numbering = 'st';
                break;
            case 2:
                $numbering = 'nd';
                break;
            case 3:
                $numbering = 'rd';
                break;
        }

        echo "$i$numbering $currentMonthName, $currentYear \n";
    }
}
?>