<?php
// Task 4:  Write a PHP script HTMLTagsCounter.php which generates an HTML form like in the example below.
//          It should contain a label, an input text field and a submit button. The user enters HTML tag 
//          in the input field. If the tag is valid, the script should print “Valid HTML tag!”, and if it 
//          is invalid – “Invalid HTML Tag!”. On the second line, there should be a score counter. For every 
//          valid tag entered, the score should increase by 1.
//          Hint: You may use sessions. Use an array to store all valid HTML5 tags

$isValid = false;
$tags = array('a', 'abbr', 'acronym', 'address', 'applet', 'area', 'article', 'aside', 'audio', 'b', 'base',
    'basefont', 'bdi', 'bdo', 'bgsound', 'big', 'blink', 'blockquote', 'body', 'br', 'button', 'canvas',
    'caption', 'center', 'cite', 'code', 'col', 'colgroup', 'content', 'data', 'datalist', 'dd', 'decorator',
    'del', 'details', 'dfn', 'dialog', 'dir', 'div', 'dl', 'dt', 'element', 'em', 'embed', 'fieldset', 'figcaption',
    'figure', 'font', 'footer', 'form', 'frame', 'frameset', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'head', 'header',
    'hgroup', 'hr', 'html', 'i', 'iframe', 'img', 'input', 'ins', 'isindex', 'kbd', 'keygen', 'label', 'legend', 'li',
    'link', 'listing', 'main', 'map', 'mark', 'marquee', 'menu', 'menuitem', 'meta', 'meter', 'nav', 'nobr', 'noframes',
    'noscript', 'object', 'ol', 'optgroup', 'option', 'output', 'p', 'param', 'picture', 'plaintext', 'pre', 'progress',
    'q', 'rp', 'rt', 'ruby', 's', 'samp', 'script', 'section', 'select', 'shadow', 'small', 'source', 'spacer', 'span',
    'strike', 'strong', 'style', 'sub', 'summary', 'sup', 'table', 'tbody', 'td', 'template', 'textarea', 'tfoot', 'th',
    'thead', 'time', 'title', 'tr', 'track', 'tt', 'u', 'ul', 'var', 'video', 'wbr', 'xmp'
);
session_start();
if (!isset($_SESSION['score'])) {
    $_SESSION['score'] = 0;
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>HTML Tags Counter</title>
    <style>
        label {
            display: block;
        }

        div {
            font-weight: bold;
            font-size: 1.5em;;
        }
    </style>
</head>
<body>
<section>
    <form action="" method="get">
        <label for="tag">Enter HTML tag:</label>
        <input type="text" name="tag" id="tag"/>
        <input type="submit"/>
    </form>
    <br/>
    <?php
    if (isset($_GET['tag'])) :
        if (in_array(strtolower($_GET['tag']), $tags)) {
            $isValid = true;
            $_SESSION['score']++;
        }
        ?>
        <div><?= $isValid ? "Valid" : "Invalid" ?> HTML tag!</div>
        <div>Score: <?= $_SESSION['score']; ?></div>
    <?php endif; ?>
</section>
</body>
</html>