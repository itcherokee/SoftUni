<?php
$list = preg_split('/\W+/', $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);
$prices = array('CPU' => 85, 'ROM' => 45, 'RAM' => 35, 'VIA' => 45);
$amount = 0;
$number_of_computers = 0;

$parts = array();
for ($i = 0; $i < count($list); $i++) {
    if (isset($parts[$list[$i]])) {
        $parts[$list[$i]]++;
    } else {
        $parts[$list[$i]] = 1;
    }
}

asort($parts); // sort parts with max items at the top
foreach ($parts as $part => $pieces) {
    if ($pieces >= 5) {
        $amount -= ($prices[$part] / 2) * $pieces;
    } else {
        $amount -= $prices[$part] * $pieces;
    }
}

if (count($parts) == 4){
    $number_of_computers = $parts[array_keys($parts)[0]];
    $amount += ($number_of_computers * 420);
}

$parts_left = assemblePCs($parts, $number_of_computers);
$amount += sellParts($parts, $prices);

$win = $amount > 0 ? "gained":"lost";
echo "<ul><li>{$number_of_computers} computers assembled</li><li>{$parts_left} parts left</li></ul><p>Nakov {$win} {$amount} leva</p>";

function sellParts(&$parts, &$prices)
{
    $result = 0;
    foreach ($parts as $part => $items) {
        if ($items > 0) {
            $result += $prices[$part] / 2 * $items;
        }
    }

    return $result;
}

function assemblePCs(&$parts, $number_of_PCs)
{
    $parts_left = 0;
    foreach ($parts as $part => $pieces) {
        if ($pieces > 0){
            $parts[$part] -= $number_of_PCs;
            $parts_left += $parts[$part];
        }
    }

    return $parts_left;
}