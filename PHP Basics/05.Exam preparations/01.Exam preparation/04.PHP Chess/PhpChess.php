<?php
$input = $_GET['board'];
function discover($abr)
{
    $name = "$abr";
    switch ($abr) {
        case "R":
            $name = "Rook";
            break;
        case "H":
            $name = "Horseman";
            break;
        case "B":
            $name = "Bishop";
            break;
        case "K":
            $name = "King";
            break;
        case "Q":
            $name = "Queen";
            break;
        case "P":
            $name = "Pawn";
            break;
        case " ":
            $name = " ";
            break;
        default:
            error();
            break;
    }

    return $name;
}

function countPieces($row)
{
    global $json;
    $pieces = array('Rook', 'Horseman', 'Bishop', 'King', 'Queen', 'Pawn', ' ');
    for ($i = 0; $i < 8; $i++) {
        $piece = discover($row[$i]);
        if (in_array($piece, $pieces)) {
            if ($piece !== ' ') {
                if (isset($json[$piece])) {
                    $json[$piece]++;
                } else {
                    $json[$piece] = 1;
                }
            }
        } else {
            error();
        }
    }
}

function drawBoard($board)
{
    $result = "<table>";
    for ($row = 0; $row < 8; $row++) {
        $result .= "<tr>";
        for ($col = 0; $col < 8; $col++) {
            $result .= "<td>{$board[$row][$col]}</td>";
        }
        $result .= "</tr>";
    }

    return "{$result}</table>";
}

function error()
{
    echo "<h1>Invalid chess board</h1>";
    die();
}

$json = array();
$result = 'OK';
$board = array();
$rows = preg_split('/\//', $input, -1, PREG_SPLIT_NO_EMPTY);
if (count($rows) === 8) {
    for ($i = 0; $i < count($rows); $i++) {
        $board[$i] = preg_split('/\-/', $rows[$i], -1);
        if (count($board[$i]) === 8) {
            countPieces($board[$i]);
        } else {
            error();
        }
    }
} else {
    error();
}


echo drawBoard($board);
if (count($json) > 0) {
    ksort($json);
    echo json_encode($json);
} else {
    echo "{}";
}