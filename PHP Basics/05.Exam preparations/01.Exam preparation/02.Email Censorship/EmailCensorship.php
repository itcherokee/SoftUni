<?php
$text = $_GET['text'];
$blacklist = preg_split('/\s+/', preg_replace('/\*/', '', $_GET['blacklist']), -1, PREG_SPLIT_NO_EMPTY);

function censor($text, $blacklist)
{
        $emails = preg_replace_callback('/([a-zA-Z0-9_\-+]+)\@{1}([a-zA-Z0-9\-]+)\.{1}([a-zA-Z0-9\-\.]+)/', function ($match) use ($blacklist) {
        foreach ($blacklist as $censor) {
            if (preg_match("/$censor/", $match[0])) {
                $pos = strrpos($match[0],$censor);
                if ($pos){
                    if(strlen($match[0]) === $pos + (strlen($censor)+1)){
                        return "<a href=\"mailto:{$match[0]}\">{$match[0]}</a>";
                    }
                }

                return str_repeat('*', strlen($match[0]));
            }
        }

        return "<a href=\"mailto:{$match[0]}\">{$match[0]}</a>";
    }, $text);

    return $emails;
}

echo "<p>".censor($text, $blacklist)."</p>";
?>
