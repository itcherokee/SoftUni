<?php
// Task 4:  Write a PHP program TextFilter.php that takes a text from a textfield and a string of
//          banned words from a text input field. All words included in the ban list should be
//          replaced with asterisks "*", equal to the word’s length. The entries in the banlist
//          will be separated by a comma and space ", ".

header("Content-Type: text/html; charset=utf-8");
mb_internal_encoding("UTF-8");

function parseInput($data)
{
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlentities($data);
    return $data;
}

function censorWords($text, $bannedWords)
{
    $words = preg_replace_callback('/(\p{L}+)/u', function ($match) use ($bannedWords) {
        $word = $match[1];
        if (in_array(mb_strtolower($word), $bannedWords)) {
            return str_repeat('*', mb_strlen($match[1]));
        }
        return $match[1];
    }, $text);

    return $words;
}

function censorSequence($text, $bannedWords)
{
    foreach ($bannedWords as $censorWord) {
        $pattern = str_repeat('*', mb_strlen($censorWord));
        $text = str_ireplace($censorWord, $pattern, $text);
    }

    return $text;
}

define ("TEXT", "text");
define ("BANNEDWORDS", "banned-words");
define("WHOLEWORDS", "whole-words");

if (!empty($_POST[TEXT]) && !empty($_POST[BANNEDWORDS])) {
    $inputText = $_POST[TEXT];
    $inputBanedWords = mb_strtolower($_POST[BANNEDWORDS], 'UTF-8');
    $bannedWords = preg_split('/\P{L}+/u', parseInput($inputBanedWords), -1, PREG_SPLIT_NO_EMPTY);
    if (isset($_POST['whole-words'])) {
        $result = censorWords(parseInput($inputText), $bannedWords);
    } else {
        $result = censorSequence(parseInput($inputText), $bannedWords);
    }
} else {
    $result = '';
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Text Filter</title>
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
            <label for="banned-words">Banned words: </label>
            <input type="text" name="banned-words" id="banned-words"/>
        </div>
        <div>
            <input type="checkbox" name="whole-words" id="whole-words" />
            <span>Whole words only</span>
        </div>
        <input type="submit" value="Parse"/>
    </form>
    <?= $result; ?>
</main>
<script>
    document.getElementById('text').value = "<?php echo $_POST[TEXT]; ?>";
    document.getElementById('banned-words').value = "<?php echo $_POST[BANNEDWORDS]; ?>";
    document.getElementById('whole-words').checked = "<?php echo $_POST[WHOLEWORDS]; ?>";
</script>
</body>
</html>