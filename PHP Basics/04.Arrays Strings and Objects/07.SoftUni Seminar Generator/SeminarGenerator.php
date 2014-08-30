<?php
// Task 7:  * Write a PHP program SeminarGenerator.php that receives information about seminars from
//          a textarea, holding each seminar on a separate line, and prints the data as an HTML table.
//          The information about the seminars comes in format:
//          [Seminar name]-[Lecturer’s name]-[dd-mm-YYYY hh:MM] [Seminar info],
//          where mm denotes the month and MM  denotes the minutes. Each seminar should be put on
//          a separate table row with cells Seminar name, Date and Participation. The user should be
//          able to sort the seminars by Name or Date in Ascending/Descending order. On hover over
//          a seminar’s name, a details box should appear. The box should contain information about
//          the lecturer and a description. See the example below. The box should follow the cursor
//          and disappear when the mouse leaves the seminar’s name. Styling the page is optional.
//          Semantic HTML is required. Use objects for handling the seminar data.

header("Content-Type: text/html; charset=utf-8");

// left to speedup testing
$input = <<<EOD
Debugging with WordPress-Mario Peshev-28-08-2014 18:00 WordPress is a free and open source blogging tool and a content management system (CMS) based on PHP and MySQL...
First steps with Laravel-Ivan Vankov-31-08-2014 19:00 Laravel is a free, open source PHP web application framework, designed for the development of model–view–controller (MVC) web applications. According to...
JavaScript with .NET-Pavel Kolev-12-09-2014 17:00 JavaScript (JS) is a dynamic computer programming language. It is most commonly used as part of web browsers, whose implementations allow client-side scripts to interact with the user, control the browser, communicate asynchronously...
SEO optimization, social networks, digital marketing-Ognyan Mladenov-05-07-2014 18:00 Search engine optimization (SEO) is the process of affecting the visibility of a website or a web page in a search engine's "natural" or un-paid ("organic") search results. In general, the earlier (or higher ranked on the search results page), and more frequently...
Basic Game Theory-Georgi Georgiev-16-06-2014 15:00 Game theory is a study of strategic decision making. Specifically, it is "the study of mathematical models of conflict and cooperation between intelligent rational decision-makers". An alternative term suggested "as a more descriptive name for the discipline" is interactive decision theory. Game theory is mainly used in economics...
EOD;

require_once('Seminar.php');

function parse($text)
{
    $data = array();
    preg_match_all('/(.*)-([a-zA-Z\s]+)-(\d{2}-\d{2}-\d{4}\s?\d{2}:\d{2})\s?(.*)/', $text, $data, PREG_SET_ORDER);
    $len = count($data);
    $seminars = array();
    if ($len > 0) {
        for ($i = 0; $i < $len; $i++) {
            $seminars[] = new Seminar($data[$i][1], $data[$i][2], $data[$i][3], $data[$i][4]);
        }
    }

    return $seminars;
}

function echoAsTable($seminarData)
{
    $result = '<form action="" method="get"></form><table><thead><tr><th>Seminar name</th><th>Date</th><th>Participate</th></tr></thead><tbody>';
    for ($i = 0; $i < count($seminarData); $i++) {
        $result .= '<tr>';
        $details = "<div id='details-{$i}'><span>Lecturer:</span>" .
            htmlentities($seminarData[$i]->getLecturer()) .
            "<br/><span>Details:</span>" .
            htmlentities($seminarData[$i]->getDetails()) .
            "</div>";
        $result .= "<td><a href='#top' id='seminar-{$i}'>" .
            htmlentities($seminarData[$i]->getName()) . $details .
            "</td>";
        $result .= "<td>" .
            htmlentities($seminarData[$i]->getFormatedTime()) .
            "</td>";
        $result .= "<td><input type='button' name='signup-seminar{$i}' value='SIGN UP'/></td>";
        $result .= "</tr>";

    }

    return $result . "</tbody></table></form>";
}

if (!empty($_POST['content'])) {
    $content = $_POST['content'];
    $sort = $_POST['sort'];
    $order = $_POST['order'];
    $content = parse($content);
    if (count($content) > 0) {
        usort($content, function ($a, $b) use ($order) {
            global $sort;
            if ($sort === 'name') {
                if ($order === "ascending") {
                    return $a->getName() > $b->getName();
                } else {
                    return $b->getName() > $a->getName();
                }
            } else {
                if ($order === "ascending") {
                    return $a->getTime() > $b->getTime();
                } else {
                    return $b->getTime() > $a->getTime();
                }
            }
        });

        $result = echoAsTable($content);
    } else {
        $result = 'No valid data provided!';
    }
} else {
    $result = '';
}
?>

<!doctype html>
<html>
<head>
    <title>SoftUni Seminar Generator</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body name="top">
<form action="" method="post">
    <textarea name="content" id="content"><?= $input; ?></textarea>
    <label for="sort">Sort by: </label>
    <select name="sort" id="sort">
        <option value="name" selected="selected">Name</option>
        <option value="date">Date</option>
    </select>
    <label for="order">Order by: </label>
    <select name="order" id="order">
        <option value="ascending" selected="selected">Ascending</option>
        <option value="descending">Descending</option>
    </select>
    <input type="submit" value="Submit"/>
</form>
<p><?= $result ?></p>
<script src="scripts/script.js"></script>
<script>
    document.getElementById('order').value = "<?php echo $_POST['order']; ?>";
    document.getElementById('sort').value = "<?php echo $_POST['sort']; ?>";
</script>
</body>
</html>