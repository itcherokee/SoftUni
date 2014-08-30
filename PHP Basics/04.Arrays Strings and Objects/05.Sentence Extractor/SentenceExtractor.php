<?php
// Task 5:  Write a PHP program SentenceExtractor.php that takes a text from a textarea and a word
//          from an input field and prints all sentences from the text, containing that word.
//          A sentence is any sequence of words ending with ., ! or ?.

header("Content-Type: text/html; charset=utf-8");
mb_internal_encoding("UTF-8");

function parseInput($data)
{
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlentities($data);
    return $data;
}

define ("TEXT", "text");
define ("WORD", "word");

if (!empty($_POST[TEXT]) && !empty($_POST[WORD])) {
    $sentences = array();
    $result = '';
    $ok = preg_match_all('/.*?(\.\s?|\?\s?|!\s?)/u', $_POST[TEXT], $sentences);
    for ($i = 0; $i < count($sentences[0]); $i++) {
        if (mb_stripos($sentences[0][$i], " " . $_POST[WORD] . " ") ||
            mb_stripos($sentences[0][$i], " " . $_POST[WORD] . "?") ||
            mb_stripos($sentences[0][$i], " " . $_POST[WORD] . ".") ||
            mb_stripos($sentences[0][$i], " " . $_POST[WORD] . "!"))
        {
            $result .= $sentences[0][$i];
        }
    }
} else {
    $result = '';
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Sentence Extractor</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<main>
    <form action="" method="post">
        <div>
            <label for="text">Text: </label>
            <textarea name="text" id="text"></textarea>
        </div>
        <div>
            <label for="word">Word: </label>
            <input type="text" name="word" id="word"/>
        </div>
        <input type="submit" value="Search"/>
    </form>
    <?= parseInput($result); ?>
</main>
<script>
    document.getElementById('text').value = "<?php echo $_POST[TEXT]; ?>";
    document.getElementById('word').value = "<?php echo $_POST[WORD]; ?>";
</script>
</body>
</html>