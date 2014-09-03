<?php
$inputBoard = $_GET['board'];
$inputStartPosition = $_GET['beginning'];
$inputMoves = $_GET['moves'];

$moves = preg_split('/\s+/', $inputMoves, -1, PREG_SPLIT_NO_EMPTY);
$startPosition = preg_split('/\s+/', $inputStartPosition, -1, PREG_SPLIT_NO_EMPTY);
$position = array(((int)$startPosition[0]) - 1, ((int)$startPosition[1]) - 1);
$board = preg_split('/\|/', $inputBoard, -1, PREG_SPLIT_NO_EMPTY);
$totalInns = 0;
for ($i = 0; $i < 4; $i++) {
    $board[$i] = preg_split('/\s+/', $board[$i], -1, PREG_SPLIT_NO_EMPTY);
    $totalInnsInRow = array_count_values($board[$i]);
    if (isset($totalInnsInRow['I'])) {
        $totalInns += (int)$totalInnsInRow['I'];
    }
}

$coins = 50;
$inns = 0;
for ($i = 0; $i < count($moves); $i++) {
    if ($inns > 0) {
        $coins +=  ($inns * 20);
    }
    $position = move($position, $moves[$i]);
    switch ($board[$position[0]][$position[1]]) {
        case 'S':
            $i += 2;
            break;
        case "P":
            if ($coins >= 5) {
                $coins -= 5;
            } else {
                die ("<p>You lost! You ran out of money!<p>");
            }
            break;
        case "F":
            $coins += 20;
            break;
        case "V":
            $coins *= 10;
            break;
        case "N":
            die ("<p>You won! Nakov's force was with you!<p>");
            break;
        case "I":
            if ($coins >= 100) {
                $inns++;
                $coins -= 100;
                if ($totalInns === $inns) {
                    die("<p>You won! You own the village now! You have {$coins} coins!<p>");
                } else if ($coins < 0) {
                    die ("<p>You lost! You ran out of money!<p>");
                }
            } else {
                if ($coins >= 10) {
                    $coins -= 10;
                } else {
                    die ("<p>You lost! You ran out of money!<p>");
                }
            }
            break;
    }


}
die("<p>You lost! No more moves! You have {$coins} coins!<p>");

function move($currentPosition, $steps)
{
    $row = $currentPosition[0];
    $col = $currentPosition[1];
    for ($i = (int)$steps; $i > 0; $i--) {

        if ($row == 0 && $col < 3) { //  posoka [0,1] (right)
            $col += 1;
        } else if ($row < 3 && $col == 3) { // posoka [1,0] (down)
            $row += 1;
        } else if ($row == 3 && $col > 0) { // posoka [0,-1] (left)
            $col -= 1;
        } else if ($row > 0 && $col == 0) { // posoka [-1,0] (up)
            $row -= 1;
        }
    }

    return array($row, $col);
}