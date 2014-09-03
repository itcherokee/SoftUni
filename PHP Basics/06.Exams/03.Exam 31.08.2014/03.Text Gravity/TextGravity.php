<?php
$inputText = $_GET['text'];
$inputLength = (int)$_GET['lineLength'];
$length = strlen($inputText);
$matrix = str_split($inputText, $inputLength);
for ($i = 0; $i < count($matrix); $i++) {
    $lineLength = strlen($matrix[$i]);
    if ($lineLength < $inputLength) {
        $matrix[$i] = $matrix[$i] . str_repeat(' ', $inputLength - $lineLength);
    }
    $matrix[$i] = str_split($matrix[$i]);
}

$numberOfRows = count($matrix);
for ($col = 0; $col < $inputLength; $col++) {
    $currentWord = '';
    for ($row = 0; $row < $numberOfRows; $row++) {
        $currentWord .= $matrix[$row][$col];
    }
    $currentWord = str_replace(' ', '', $currentWord);
    $wordLength = strlen($currentWord);
    if ($wordLength < $numberOfRows) {
        $currentWord = str_pad($currentWord, $numberOfRows, " ", STR_PAD_LEFT);
    }

    for ($n = $numberOfRows - 1; $n >= 0; $n--) {
        $matrix[$n][$col] = $currentWord[$n];
    }
}

$result = "";
for ($row = 0; $row < $numberOfRows; $row++) {
    $result .= "<tr>";
    for ($col = 0; $col < $inputLength; $col++) {
        $result .= "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
    }
    $result .= "</tr>";
}
echo "<table>{$result}<table>";
