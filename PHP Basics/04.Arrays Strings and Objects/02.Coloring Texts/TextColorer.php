<?php
// Task 2:  Write a PHP program TextColorer.php that takes a text from a textfield,
//          colors each character according to its ASCII value and prints the result.
//          If the ASCII value of a character is odd, the character should be printed
//          in blue. If it’s even, it should be printed in red.

header ("Content-Type: text/html; charset=utf-8");

function findAllChars($chars)
{
    $chars = preg_replace('/\s+/u', '', $chars);
    $result = preg_split('//u', $chars, -1, PREG_SPLIT_NO_EMPTY);
    return $result;
}

function formatChars($chars)
{
    $result = '';
    for ($i = 0; $i < count($chars); $i++){
        if (ord($chars[$i]) % 2 === 0 ){
            $class = 'even';
        } else {
            $class = 'odd';
        }

        $result .= "<span class='{$class}'>{$chars[$i]}</span> ";
    }

    return $result;
}

//$_GET['text'] = "What a wonderful world!";
$result = '';
if (!empty($_GET['text'])) {
    $input = htmlentities($_GET['text']);
    $result = findAllChars($input);
    if (count($result) <= 0) {
        $result = 'No chars found!';
    } else {
        $result = formatChars($result);
    }
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Text Colorer</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<main>
    <form action="" method="get">
        <textarea name="text" id="text" cols="50" rows="5"></textarea>
        <input type="submit" value="Color text"/>
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

