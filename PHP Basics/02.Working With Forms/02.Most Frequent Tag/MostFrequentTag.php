<?php
// Task 02: Write a PHP script MostFrequentTag.php which generates an HTML input
//          text field and a submit button. In the text field the user must enter
//          different tags, separated by a comma and a space (", ").
//          When the information is submitted, the script should generate a list
//          of the tags, sorted by frequency. Then you must print:
//          "Most Frequent Tag is: [most frequent tag]".
//          Semantic HTML is required. Styling is not required.

header('Content-Type: text/html; charset=utf-8');
?>

<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
</head>
<body>
<section>
    <form action="" method="get">
        <p>Enter Tags:</p>
        <input type="text" name="tags"/>
        <input type="submit"/>
    </form>
    <p>
        <?php
        if (isset($_GET['tags']) && !empty($_GET['tags'])) {
            $tags = preg_split('/[\s,]+/', htmlentities($_GET['tags']));
            $tagsFiltered = array();
            for ($i = 0; $i < count($tags); $i++) {
                if (array_key_exists($tags[$i], $tagsFiltered)) {
                    $tagsFiltered[$tags[$i]] += 1;
                } else {
                    $tagsFiltered[$tags[$i]] = 1;
                }
            }

            arsort($tagsFiltered);
            $maxTagFrequencies = reset($tagsFiltered);
            $mostFrequent = array();
            foreach ($tagsFiltered as $key => $value) {
                if ($value === $maxTagFrequencies) {
                    $mostFrequent[] = $key;
                }
                echo "$key : $value times.<br />";
            }

            echo "<p>Most Frequent Tag is: " . implode(", ", $mostFrequent) . "</p>";
        }
        ?>
    </p>
</section>
</body>
</html>
