<?php
// Task 1:  Write a PHP program WordMapper.php that takes a text from a textarea and prints
//          each word and the number of times it occurs in the text. The search should be
//          case-insensitive. The result should be printed as an HTML table.

header("Content-Type: text/html; charset=utf-8");

function countWords($words)
{
    $onlyWords = preg_split('/\P{L}+/u', $words, -1,PREG_SPLIT_NO_EMPTY);
    $result = array();
    for ($i = 0; $i < count($onlyWords); $i++) {
        $key = strtolower($onlyWords[$i]);
        if (isset($result[$key])) {
            $result[$key]++;
        } else {
            $result[$key] = 1;
        }
    }

    return $result;
}

function formatWordsAsTable($words)
{
    $result = '<table><tbody>';
    foreach ($words as $word => $count) {
        $result .= "<tr><td>$word</td><td>$count</td></tr>";
    }

    return $result . '</tbody></table>';
}

$result = '';
if (!empty($_GET['text'])) {
    $input = htmlentities($_GET['text']);
    $result = countWords($input);
    if (count($result) <= 0) {
        $result = 'No words found!';
    } else {
         $result = formatWordsAsTable($result);
    }
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Word Mapping</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<main>
    <form action="" method="get">
        <textarea name="text" id="text" cols="50" rows="5"></textarea>
        <input type="submit" value="Count words"/>
    </form>
    <?php if (!empty($_GET['text'])): ?>
        <div><?= $result ?></div>
    <?php endif; ?>
</main>
<script>
    document.getElementById('text').value = "<?= $_GET['text']; ?>";
</script>
</body>
</html>