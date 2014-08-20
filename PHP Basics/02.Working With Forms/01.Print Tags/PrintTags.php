<?php
// Task 01: Write a PHP script PrintTags.php which generates an HTML input text
//          field and a submit button. In the text field the user must enter
//          different tags, separated by a comma and a space (", "). When the
//          information is submitted, the script should split the tags, put them
//          in an array and print out the array. Semantic HTML is required.
//          Styling is not required.

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
    <?php

    // first solution - more HTML semantic correct
    //    if (isset($_GET['tags']) && !empty($_GET['tags'])) {
    //        $tags = preg_split('/[\s,]+/', htmlentities($_GET['tags']));
    //        echo '<ol start="0"><li>' . implode("</li><li>", $tags) . "</li></ol>";
    //    }

    // second solution - identical as task definition example output
    if (isset($_GET['tags']) && !empty($_GET['tags'])) {
        $tags = preg_split('/[\s,]+/', htmlentities($_GET['tags']));
        for ($i = 0; $i < count($tags); $i++) {
            echo "$i : $tags[$i]<br />";
        }
    }
    ?>
</section>
</body>
</html>