<?php
$inputCode = $_GET['html'];

$endPattern = '/(<\/div>[\S\s]*?<!--\s*?(main|header|nav|article|section|aside|footer)\s*?-->)/';
$inputCode = preg_replace($endPattern, preg_replace('/\s*/', '', '</$2>', -1), $inputCode, -1); // ending tag
$tags = array("main", "header", "nav", "article", "section", "aside", "footer");
$lines = preg_split('/\r\n/', $inputCode, -1);
for ($row = 0; $row < count($lines); $row++) {
    $tag = strpos($lines[$row], '<div ');
    if ($tag !== false) { // otkrit DIV
        $id = strpos($lines[$row], ' id', $tag + 4);
        $class = strpos($lines[$row], ' class', $tag + 4);
        $isThereEqualSignClass = preg_match('/class[\s]*?=/', $lines[$row]);
        $isThereEqualSignId = preg_match('/id[\s]*?=/', $lines[$row]);
        if ($isThereEqualSignClass == 1 || $isThereEqualSignId == 1) {
            // check is there "=" after tags
            if ($id !== false && countQuotesUpToTag($lines[$row], $id)) { // otkrit ID
                $startQuote = strpos($lines[$row], '"', $id + 2);
                $endQuote = strpos($lines[$row], '"', $startQuote + 1);
                $tagName = trim(substr($lines[$row], $startQuote + 1, $endQuote - $startQuote - 1));
                if (in_array($tagName, $tags)) {
                    $toSearch = substr($lines[$row], $id, $endQuote - $id + 1);
                    $lines[$row] = str_replace($toSearch, '', $lines[$row], $lines[$row]);
                    $lines[$row] = str_replace('<div', "<$tagName", $lines[$row]);
                    $lines[$row] = rtrim(substr($lines[$row], 0, strlen($lines[$row]) - 1)) . ">";
                    $spaces = 0;
                    for ($i = $tag + strlen($tagName) + 1; $i < strlen($lines[$row]); $i++) {
                        if ($lines[$row][$i] == ' ') {
                            $spaces++;
                        } else {
                            if ($spaces > 1) {
                                $firstPart = substr($lines[$row], 0, $tag + strlen($tagName) + 1);
                                $secondPart = substr($lines[$row], $i);
                                $lines[$row] = $firstPart . " " . $secondPart;
                            }
                            break;
                        }
                    }

                    $lines[$row] = preg_replace('/[\s]+/', ' ', $lines[$row]);
                }
            } else if ($class !== false && countQuotesUpToTag($lines[$row], $class)) { // otkrit CLASS
                $startQuote = strpos($lines[$row], '"', $class + 5);
                $endQuote = strpos($lines[$row], '"', $startQuote + 1);
                $tagName = trim(substr($lines[$row], $startQuote + 1, $endQuote - $startQuote - 1));
                if (in_array($tagName, $tags)) {
                    $toSearch = substr($lines[$row], $class, $endQuote - $class + 1);
                    $lines[$row] = str_replace($toSearch, '', $lines[$row], $lines[$row]);
                    $lines[$row] = str_replace('<div', "<$tagName", $lines[$row]);
                    $lines[$row] = rtrim(substr($lines[$row], 0, strlen($lines[$row]) - 1)) . ">";
                    $spaces = 0;
                    for ($i = $tag + strlen($tagName) + 1; $i < strlen($lines[$row]); $i++) {
                        if ($lines[$row][$i] == ' ') {
                            $spaces++;
                        } else {
                            if ($spaces > 1) {
                                $firstPart = substr($lines[$row], 0, $tag + strlen($tagName) + 1);
                                $secondPart = substr($lines[$row], $i);
                                $lines[$row] = $firstPart . " " . $secondPart;
                            }

                            break;
                        }
                    }
                    $lines[$row] = preg_replace('/[\s]+/', ' ', $lines[$row]);
                }
            }
        }
    }
}

for ($i = 0; $i < count($lines); $i++) {
    echo $lines[$i] . "\n";
}

function countQuotesUpToTag($line, $tag)
{
    $count = 0;
    for ($i = 0; $i < strlen($line); $i++) {
        if ($i == $tag) {
            break;
        }
        if ($line[$i] == '"') {
            $count++;
        }
    }

    if ($count % 2 === 0) {
        return true;
    } else {
        return false;
    }
}

;