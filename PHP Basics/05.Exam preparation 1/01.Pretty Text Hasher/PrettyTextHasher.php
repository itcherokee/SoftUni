<?php
$content = $_GET['text'];
$hashValue = $_GET['hashValue'];
$fontSize = $_GET['fontSize'];
$fontStyle = $_GET['fontStyle'];

$text = '';
for ($i = 0; $i < strlen($content); $i++) {
    if ($i % 2 === 0) {
        $text .= chr(ord($content[$i]) + $hashValue);
    } else {
        $text .= chr(ord($content[$i]) - $hashValue);
    }
}

$font = "font-size:$fontSize;";

switch ($fontStyle) {
    case "italic":
        $style = 'font-style:italic;';
        break;
    case "bold":
        $style = 'font-weight:bold;';
        break;
    case "normal":
        $style = 'font-style:normal;';
        break;
};

echo "<p style=\"{$font}{$style}\">{$text}</p>";
?>