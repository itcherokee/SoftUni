<?php
// Task 08: * Write a PHP script TimeUntilNewYear.php. Use the built-in function getdate()
//          to get the current date and time. Print how many hours, minutes and seconds
//          are left until New Year and how many days, hours, minutes and seconds are left
//          in a counter format . Look at examples below to get a better idea. The examples
//          show the current date and time in "d-m-Y G:i:s" format. Use the current time.

//          The European Union shifts all at once, at 01:00 UTC or 02:00 CET or 03:00 EET;
//          for example, Eastern European Time is always one hour ahead of Central European Time.
//          Since 1996 European Summer Time has been observed from the last Sunday in March
//          to the last Sunday in October; previously the rules were not uniform across the European Union.

// Gets last Sunday of specified month in specified year.
// Used for checking the daylight saving time period for EU (EET) - Bulgaria
function getLastSunday($month, $year)
{
    $dateAsString = date("Y-m-d H:i:s", mktime(3, 0, 0, $month, 31, $year));
    $lastSunday = date("Y-m-d H:i:s", strtotime($dateAsString . 'last sunday + 3 hours')) . "\n";
    return strtotime($lastSunday);
}

// Tests from exercise examples
//$today = getdate(mktime(13,7,9,8,12,2014));
//$today = getdate(mktime(11,8,47,8,12,2014));

// Using current time - must be commented if you want to test above examples
$today = getdate();

// Handle summertime offset & new year
define("STARTSUMMERTIME", getLastSunday(3, $today['year']));
define("ENDSUMMERTIME", getLastSunday(10, $today['year']));
define("NEWYEAR", mktime(23, 59, 59, 12, 31, $today['year']));
if ($today[0] >= STARTSUMMERTIME && $today[0] < ENDSUMMERTIME) {
    $today[0] += (60 * 60);
}

// Actual calculations
$offset = NEWYEAR - $today[0];
$days = (int)(($offset) / 86400);
$hours = (int)((($offset) % 86400) / 3600);
$minutes = (int) ((($offset) % 3600) / 60);
$seconds = (int) ((($offset) % 3600) % 60);
$totalHours = number_format((double)((int)($offset / 60 / 60)), 0, '', ' ');
$totalMinutes = number_format((double)((int)($offset / 60)), 0, '', ' ');
$totalSeconds = number_format((double)((int)($offset)), 0, '', ' ');

// Output result
echo "Hours until new year : $totalHours\n";
echo "Minutes until new year : $totalMinutes\n";
echo "Seconds until new year : $totalSeconds\n";
echo "Days:Hours:Minutes:Seconds $days:$hours:$minutes:$seconds";
?>
