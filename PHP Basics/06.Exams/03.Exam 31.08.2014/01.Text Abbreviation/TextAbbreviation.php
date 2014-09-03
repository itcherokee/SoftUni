<?php
$inputText = $_GET['list'];
$size = (int)$_GET['maxSize'];

$linesRaw = preg_split('/\r\n/', $inputText, -1, PREG_SPLIT_NO_EMPTY);

for ($i = 0; $i < count($linesRaw); $i++) {
    $linesRaw[$i] = (trim($linesRaw[$i]));
    if ($linesRaw[$i] != '') {
        if (strlen($linesRaw[$i]) > $size){
            $linesRaw[$i] = substr($linesRaw[$i],0,$size) . "...";
        }
        $lines[] = "<li>". htmlspecialchars($linesRaw[$i]) . "</li>";
    }
}

echo "<ul>". implode('',$lines) ."</ul>";
