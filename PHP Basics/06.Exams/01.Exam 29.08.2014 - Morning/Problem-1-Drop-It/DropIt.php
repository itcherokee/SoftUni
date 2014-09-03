<?php
$text = str_split($_GET['text']);
$minFontSize = $_GET['minFontSize'];
$maxFontSize = $_GET['maxFontSize'];
$fontStep = (int)$_GET['step'];

define ("FONTSTRIKE", 'text-decoration:line-through;');
$result = '';
$strike = '';
$char = '';
$font = $minFontSize;
for ($i = 0; $i < count($text); $i++) {
    $char = $text[$i];
    $strike = ord($char) % 2 === 0 ? FONTSTRIKE : '';
    $charOut = htmlspecialchars($char);
    $result .= "<span style='" . "font-size:$font;{$strike}'>{$charOut}</span>";
    if (ctype_alpha($char)) {
        $font += $fontStep;
        $isChar = true;
    } else {
        $isChar = false;
    }

    if (($font >= $maxFontSize || $font == $minFontSize) && $isChar) {
        $fontStep *= -1;
    }
}

echo $result;