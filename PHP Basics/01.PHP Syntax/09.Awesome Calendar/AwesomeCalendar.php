<?php
// Task 09: ** Write a PHP script AwesomeCalendar.php which creates a calendar in HTML
//          for a given year. Styling the calendar is optional. Semantic HTML is required.
//          Hint: Embed HTML in your PHP code. Use tables or divs for structuring the calendar.
//          Look for a way to find the day of the week.

function generateMonth($month, $year)
{
    $lastDay = date("t", strtotime("$year-$month-1"));
    $firstDay = date("N", strtotime("$year-$month-1"));
    $monthArray = array();
    for ($i = 1, $len = $lastDay + $firstDay; $i < $len; $i++) {
        if ($i >= $firstDay) {
            $monthArray[] = $i - $firstDay + 1;
        } else {
            $monthArray[] = 0;
        }
    }

    return $monthArray;
}

function formatMonth($monthArray, $month)
{
    $table = "<thead><tr><th>Пн</th><th>Вт</th><th>Ср</th><th>Чт</th><th>Пе</th><th>Сб</th><th>Не</th></tr></tr></thead>";
    $months = array("Януари", "Февруари", "Март", "Април", "Май", "Юни", "Юли", "Август", "Септември", "Октомври", "Ноември", "Декември");
    $table .= "<caption>{$months[$month-1]}</caption>";
    $table .= "<tbody>";
    $len = count($monthArray);
    for ($row = 0, $numRows = (int)($len / 7); $row <= $numRows; $row++) {
        $table .= "<tr>";
        $numCols = $row * 7 + 7 > $len ? $len : $row * 7 + 7;
        for ($col = $row * 7; $col < $numCols; $col++) {
            if($monthArray[$col] !== 0){
                $table .= "<td>{$monthArray[$col]}</td>";
            }else {
                $table .="<td>&nbsp;</td>";
            }
        }
        $table .= "</tr>";
    }
    $table .= "</tbody>";

    return "<table>$table</table>";
}

if (isset($_GET['year'])) {
    $year = htmlentities($_GET['year']);
} else {
    $year = null;
}
?>
<!DOCTYPE html>
<html lang="bg">
<head>
    <title>Awesome Calendar</title>
    <link rel="stylesheet" href="styles/style.css"/>
    <meta charset="utf-8"/>
</head>
<body>
<main>
    <form action="" id="select-form">
        <label for="year-selection">Year: </label>
        <select name="year" id="year-selection">
            <option value="" hidden="hidden">Select year...</option>
            <option value="2013">2013</option>
            <option value="2014">2014</option>
            <option value="2015">2015</option>
            <option value="2016">2016</option>
            <option value="2017">2017</option>
        </select>
        <input type="submit"/>
    </form>
    <article>
        <header>
            <h1>
                <?php
                if (!is_null($year)) {
                    echo $year;
                }
                ?>
            </h1>
        </header>
        <section>
            <?php
            $i = 1;
            if (!is_null($year)) {
                for ($i = 1; $i <= 12; $i++) {
                    echo formatMonth(generateMonth($i, intval($year)), $i);
                }
            }
            ?>
        </section>
    </article>
</main>
</body>
</html>
