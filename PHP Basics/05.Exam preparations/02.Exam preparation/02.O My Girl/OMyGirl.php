<?php
$text = $_GET['text'];
$key = $_GET['key'];

function parseKey($key)
{
    $keyLength = strlen($key);
    $firstChar = ctype_alnum(($key[0])) ? $key[0] : "\\" . $key[0];
    $lastChar = ctype_alnum($key[$keyLength - 1]) ? $key[$keyLength - 1] : "\\" . $key[$keyLength - 1];
    $pattern = "$firstChar";
    $upChars = false;
    $lowChars = false;
    $digits = false;
    for ($i = 1; $i < $keyLength - 1; $i++) {
        if (ctype_alpha($key[$i])) { // alphabetic char match
            if ($key[$i] >= 'A' and $key[$i] <= 'Z') {
                if (!$upChars) {
                    $digits = false;
                    $lowChars = false;
                    $pattern .= '[A-Z]*';
                    $upChars = true;
                }
            } else if ($key[$i] >= 'a' and $key[$i] <= 'z') {
                if (!$lowChars) {
                    $digits = false;
                    $upChars = false;
                    $pattern .= '[a-z]*';
                    $lowChars = true;
                }
            }
        } else if (ctype_digit($key[$i])) { // digit char match
            if (!$digits) {
                $upChars = false;
                $lowChars = false;
                $pattern .= '[0-9]*';
                $digits = true;
            }
        } else {  // any other char match
            $pattern .= "\\$key[$i]";
            $upChars = false;
            $lowChars = false;
            $digits = false;
        }
    }

    return $pattern . $lastChar;
}

$pattern = parseKey($key);
$extractPattern = '/'. $pattern . '([\s\S]{2,6})' . $pattern . '/';
preg_match_all($extractPattern,$text,$result);

for($i=0;$i<count($result[1]);$i++){
    echo $result[1][$i];
}
