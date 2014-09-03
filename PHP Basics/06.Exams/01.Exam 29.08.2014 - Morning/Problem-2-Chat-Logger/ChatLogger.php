<?php
date_default_timezone_set('Europe/Sofia');
$currentTime = strtotime($_GET['currentDate']);
$messagesInput = preg_split('/\n/', $_GET['messages'], -1, PREG_SPLIT_NO_EMPTY);
$messages = parseInput($messagesInput);
ksort($messages, SORT_NUMERIC);
$result = '';
foreach ($messages as $message) {
    $result .= $message;
}

echo $result . lastActivityFrame($currentTime, end(array_keys($messages)));

function parseInput($messagesInput){
    $messages = array();
    for ($i = 0; $i < count($messagesInput); $i++) {
        preg_match('/(.*)\s*\/\s*((\d{2})\-(\d{2})\-(\d{4})\s(\d{1,2}\:\d{1,2}\:\d{1,2}))\s*/', $messagesInput[$i], $matches);
        $date = "{$matches[5]}-{$matches[4]}-{$matches[3]} {$matches[6]}";
        $time = strtotime(trim($date));
        $content = htmlspecialchars(trim($matches[1]));
        $messages[$time] = "<div>{$content}</div>\n";
    }

    return $messages;
}

function lastActivityFrame($currentTime, $lastTime){
    $elapsedTime = $currentTime - $lastTime;
    $timestamp = '';
    if (date('d', $currentTime - 86400) === date('d', $lastTime)) {
        $timestamp = "yesterday";
    } else if ($elapsedTime < 60) {
        $timestamp = "a few moments ago";
    } else if ($elapsedTime < 3600) {
        $timestamp = (int)($elapsedTime / 60) . " minute(s) ago";
    } else if ($elapsedTime < 86400) {
        if (date('d', $currentTime) === date('d', $lastTime)) {
            $timestamp = (int)($elapsedTime / 60 / 60) . " hour(s) ago";
        }
    } else {
        $timestamp = date('d-m-Y', $lastTime);
    }

    return "<p>Last active: <time>{$timestamp}</time></p>";
}