<?php
date_default_timezone_set('Europe/Sofia');
$texts = preg_split('/\n/', $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);
$matches = array();
$result = '';
$pattern = '/(^[a-zA-Z\s\-]+?)\s*%\s*([a-zA-Z\s\-\.]+?)\s*;\s*([0-9]{2}\-[0-9]{2}\-[0-9]{4})\s*\-\s*(.*)/';
for ($i = 0; $i < count($texts); $i++) {
    $numOfMatches = preg_match_all($pattern, $texts[$i], $matches, PREG_SET_ORDER);
    if ($numOfMatches === 1) {
        $article = '<div>' . "\n";
        $title = htmlspecialchars(trim($matches[0][1]));
        $article .= "<b>Topic:</b> <span>{$title}</span>" . "\n";
        $author = htmlspecialchars(trim($matches[0][2]));
        $article .= "<b>Author:</b> <span>{$author}</span>" . "\n";
        $month = date('F', strtotime(trim($matches[0][3])));
        $article .= "<b>When:</b> <span>{$month}</span>" . "\n";
        $summary = trim($matches[0][4]);
        if (strlen($summary) > 100) {
            $summary = substr($summary, 0, 100);
        }
        $summary = htmlspecialchars($summary);
        $article .= "<b>Summary:</b> <span>{$summary}...</span>" . "\n</div>\n";
        $result .= $article;
    }
}

echo $result;