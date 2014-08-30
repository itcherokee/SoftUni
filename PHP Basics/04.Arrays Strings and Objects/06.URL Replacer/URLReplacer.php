<?php
// Task 06: Write a PHP program URLReplacer.php that takes a text from a textarea and
//          replaces all URLs with the HTML syntax <a href= "…" ></a> with a special
//          forum-style syntax [URL=…][/URL].

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

if (!empty($_POST[TEXT])) {
    $inputText = $_POST[TEXT];
    $result = preg_replace('/<\s*\/a\s*>/','[/URL]',$inputText);
    $result = preg_replace('/<a\s*href=(["\'])(.*?)(["\'])>/', '[URL=\2]',$result);
} else {
    $result = '';
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>URL Extractor</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<main>
    <form action="" method="post">
        <div>
            <label for="text">Text: </label>
            <textarea name="text" id="text"></textarea>
        </div>
        <input type="submit" value="Replace"/>
    </form>
    <?= parseInput($result); ?>
</main>
<script>
    document.getElementById('text').value = "<?php echo $_POST[TEXT]; ?>";
</script>
</body>
</html>