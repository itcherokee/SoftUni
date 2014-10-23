<?php

function __autoload($className)
{
    $filename = "./" . $className . ".class.php";
    require_once($filename);
}


$room = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = strtotime("24.10.2014");
$endDate = strtotime("26.10.2014");
$reservation = new Reservation($startDate, $endDate, $guest);
BookingManager::bookRoom($room, $reservation);

$rooms = Array(
    new SingleRoom(1401, 99),
    new SingleRoom(1403, 99),
    new BedRoom(1402, 199),
    new BedRoom(1404, 230),
    new BedRoom(1402, 299),
    new Apartment(1405, 249),
    new Apartment(1406, 1199));

echo "\r\n****************\r\n";
echo "\r\nExpensive rooms:\r\n";
echo "\r\n****************\r\n";
$expensiveRooms = array_filter($rooms, function (Room $room) {
    if ($room->getPrice() <= 250) {
        return true;
    }
    return false;
});
foreach ($expensiveRooms as $room) {
    echo $room . "\r\n";
}

echo "\r\n*******************\r\n";
echo "\r\nRooms with balcony:\r\n";
echo "\r\n*******************\r\n";
$roomsWithBalcony = array_filter($rooms, function (Room $room) {
    if ($room->getHasBalcony()) {
        return true;
    }
    return false;
});
foreach ($roomsWithBalcony as $room) {
    echo $room . "\r\n";
}

echo "\r\n*******************\r\n";
echo "\r\nRooms with bathtub:\r\n";
echo "\r\n*******************";
$roomsWithBathtub = array_map (function (Room $room) {
    $extras = explode(", ", $room->getExtras());
    if (in_array("bathtub", $extras)) {
        return $room->getRoomNumber();
    }
},$rooms);
foreach ($roomsWithBathtub as $room) {
    echo $room . "\r\n";
}