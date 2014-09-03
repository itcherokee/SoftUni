<?php
//$mainWord = (array)json_decode('{"row4":"operator"}');
//$wordsInput = json_decode('["system","like","generally","objects","need"]');
//
//$mainWord = (array)json_decode('{"row4":"operator"}');
//$wordsInput = json_decode('["system","like","generally","objects","need"]');

$mainWordRaw = (array)json_decode('{"row$%^%$^$^$4":"operatorka"}');
$dictionary = json_decode('["system","like","like","generally","objects","need"]');


//$mainWord = (array)json_decode($_GET['mainWord']);
//$wordsInput = json_decode($_GET['words']);

# RUNNING CODE


$mainWord = $mainWordRaw[array_keys($mainWordRaw)[0]];
$mainWordAsArrayOfChars = str_split($mainWord);

preg_match('/\d+/', array_keys($mainWordRaw)[0], $row); // row where is the main word
$row = $row[0] - 1;
$boardLength = strlen($mainWord); // length of the table rows & columns

$wordsCount = array();
$validWords = array();
for ($i = 0; $i < count($dictionary); $i++) {
    $intersection = array_intersect();
    if (isset($wordsCount[$dictionary[$i]])) {
        $wordsCount[$dictionary[$i]]++;
    } else {
        $wordsCount[$dictionary[$i]] = 1;
    }

    if (strlen($dictionary[$i]) > $boardLength) {
        continue;
    }

    $validWords[] = $dictionary[$i];
}

sortWordsByKey($wordsCount);
sortWordsByValue($validWords);
sortWordsByValue($dictionary);


//var_dump($validWords);
//var_dump($dictionary);
//var_dump($wordsCount);
echo "";

for ($validWordsIndex = 0; $validWordsIndex < count($validWords); $validWordsIndex++) {
    $currentValidWord = $validWords[$$validWordsIndex];
    if (strpos) {

    }
}

for ($mainCharIndex = 0; $mainCharIndex < strlen($mainWord); $mainCharIndex++) {
    $currentMainChar = $mainWord[$mainCharIndex];
    for ($wordIndex = 0; $wordIndex < count($validWords); $wordIndex++) {
        $currentWord = $validWords[$wordIndex];
        $offset = 0;
        $foundWordIndex = strpos($currentWord, $currentMainChar, $offset);
        // var_dump($wordsCount);
        while ($foundWordIndex !== false) {
            if (checkForValidiy($currentWord, $foundWordIndex)) {
                unset($wordsCount[$currentWord]);
                //unset($wordsCount[array_keys($wordsCount)[$wordIndex]]);
                $table = importWord($mainCharIndex, $currentWord, $foundWordIndex);
                $result = drawBoard($table, $boardLength);
                $wordsCount = calculateJson($wordsCount);
                $result .= json_encode($wordsCount);
                die($result);
            }
            $offset = $foundWordIndex + 1;
            $foundWordIndex = strpos($currentWord, $currentMainChar, $offset);
        }
    }
}


# FUNCTIONS

// sort first longest words
function sortWordsByKey(&$array)
{
    uksort($array, function ($a, $b) {
        if (strlen($a) === strlen($b)) {
            return 0;
        }

        return strlen($a) < strlen($b) ? 1 : -1;
    });
}

function sortWordsByValue(&$array)
{
    usort($array, function ($a, $b) {
        if (strlen($a) === strlen($b)) {
            return 0;
        }

        return strlen($a) < strlen($b) ? 1 : -1;
    });
}

// draw board with words
function drawBoard($table, $length)
{
    $result = "<table border='1'>";
    for ($row = 0; $row < $length; $row++) {
        $result .= "<tr>";
        for ($col = 0; $col < $length; $col++) {
            $result .= "<td style='width:20px;height:20px;'>{$table[$row][$col]}</td>";
        }
        $result .= "</tr>";
    }

    return "{$result}</table>";
}

// calculate all words left value
function calculateJson($array)
{
    $result = array();
    foreach ($array as $key => $value) {
        $sum = 0;
        for ($i = 0; $i < strlen($key); $i++) {
            $sum += ord($key[$i]);
        }
        $result[$key] = $sum * $value;
    }

    ksort($result);
    return $result;
}

// checks does current word is posible to be imported
function checkForValidiy($currentWord, $index)
{
    global $boardLength, $row;
    $currentWordLength = strlen($currentWord);
    $charsToEnd = ($currentWordLength - 1) - $index;
    $charsToStart = ($currentWordLength - 1) - $charsToEnd;
    $isNotOutOfEndBorder = $charsToEnd + $row <= $boardLength - 1;
    $isNotOutOfStartBorder = $row - $charsToStart >= 0;

    if ($isNotOutOfStartBorder && $isNotOutOfEndBorder) {
        return true;
    }

    return false;
}

// import discovered word into array representing board
function importWord($mainCharIndex, $currentWord, $foundWordIndex)
{
    global $boardLength, $row, $mainWord;
    $result = array();
    for ($r = 0; $r < $boardLength; $r++) {
        $currentRow = array();
        for ($c = 0; $c < $boardLength; $c++) {
            if ($r === $row[0] - 1) {
                $currentRow[] = $mainWord[array_keys($mainWord)[0]][$c];
            } else {
                $currentRow[] = '';
            }
        }
        $result[] = $currentRow;
    }

    // var_dump($result);
    $currentWordLength = strlen($currentWord);
    $charsToEnd = ($currentWordLength - 1) - $foundWordIndex;
    $charsToStart = ($currentWordLength - 1) - $charsToEnd;
    $startRow = ($row[0] - 1) - ($charsToStart);

//    $startRow = ($row[0] - 1) - (strlen($currentWord) - $foundWordIndex - 1);
    for ($r = $startRow; $r < strlen($currentWord); $r++) {
        $result[$r][$mainCharIndex] = $currentWord[$r];
    }

    //var_dump($result);

    return $result;
}