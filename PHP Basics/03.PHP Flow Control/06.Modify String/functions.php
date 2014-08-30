<?php

function isPalindrome($string)
{
    $len = strlen($string);
    $areEqual = true;
    for ($i = 0; $i < $len; $i++) {
        if ($string[$i] !== $string[$len - $i - 1]) {
            $areEqual = false;
            break;
        }

        if ($i >= ($len - $i - 1)) {
            break;
        }
    }

    if ($areEqual) {
        return true;
    }

    return false;
}

function reverse($string)
{
    $len = strlen($string);
    $result = '';
    for ($i = 0; $i < $len; $i++) {
        $result = $string[$i] . $result;
    }

    return $result;
}