<?php

abstract class Room implements iReservable
{
    private $reservations = Array();
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;

    protected function __construct($roomNumber, $price, $bedCount, $hasBalcony, $roomType, $extras, $hasRestroom)
    {
        $this->setRoomNumber($roomNumber);
        $this->setPrice($price);
        $this->setBedCount($bedCount);
        $this->setHasBalcony($hasBalcony);
        $this->setRoomType($roomType);
        $this->setExtras($extras);
        $this->setHasRestroom($hasBalcony);
    }

    function __set($name, $value)
    {
        if (empty($name)) {
            throw new InvalidArgumentException("property cannot be null!");
        }

        $this->$name = $value;
    }

    private function setBedCount($value)
    {
        if (empty($value)) {
            throw new InvalidArgumentException("Bed count cannot be null or/and must be only digits!");
        }

        $this->bedCount = $value;
    }

    public function getBedCount()
    {
        return $this->bedCount;
    }

    private function setExtras($extras)
    {
        $this->extras = $extras;
    }

    public function getExtras()
    {
        return $this->extras;
    }

    private function setHasBalcony($value)
    {
        if (!is_bool($value)) {
            throw new InvalidArgumentException("hasBalcony cannot be null or/and must be only boolean value!");
        }

        $this->hasBalcony = $value;
    }

    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    private function setHasRestroom($value)
    {
        if (!is_bool($value)) {
            throw new InvalidArgumentException("hasRestroom cannot be null or/and must be only boolean value!");
        }

        $this->hasRestroom = $value;
    }

    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    private function setPrice($value)
    {
        if (empty($value) || !is_numeric($value)) {
            throw new InvalidArgumentException("Price cannot be null or/and must be only valid double!");
        }

        $this->price = floatval($value);
    }

    public function getPrice()
    {
        return $this->price;
    }

    public function getReservations()
    {
        return $this->reservations;
    }

    private function setRoomNumber($value)
    {
        if (empty($value) || !ctype_digit($value)) {
            throw new InvalidArgumentException("Room number cannot be null or/and must be only digits!");
        }

        $this->roomNumber = $value;
    }

    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    private function setRoomType(RoomType $value)
    {
        if (empty($value) || !($value instanceof RoomType)) {
            throw new InvalidArgumentException("Room type cannot be null or/and must be RoomType type!");
        }

        $this->roomType = $value;
    }

    public function getRoomType()
    {
        return $this->roomType;
    }

    function addReservation(Reservation $reservation)
    {
        if (empty($reservation) || !($reservation instanceof Reservation)) {
            throw new InvalidArgumentException("Reservation cannot be null or/and must be Reservation type!");
        }

        if (count($this->reservations) == 0) {
            $this->reservations[] = $reservation;
        } else {
            if ($this->isCollidingReservationExists($reservation)) {
                throw new EReservationException();
            }

            $this->reservations[] = $reservation;
        }
    }

    function removeReservation(Reservation $reservation)
    {
        if (empty($reservation) || !($reservation instanceof Reservation)) {
            throw new InvalidArgumentException("Reservation cannot be null or/and must be Reservation type!");
        }

        for ($i = 0; $i < count($this->reservations); $i++) {
            if ($this->reservations[$i]->getStartDate() == $reservation->getStartDate()) {
                unset($this->reservations[$i]);
            }
        }
    }

    function __toString()
    {
        $output = "Room number: {$this->getRoomNumber()}\r\n" .
            "Room type: {$this->getRoomType()}\r\n" .
            "Number of beds: {$this->getBedCount()}\r\n" .
            "Price: {$this->getPrice()}\r\n" .
            "Has balcony: {$this->boolToEnglish($this->getHasBalcony())}\r\n" .
            "Has restroom: {$this->boolToEnglish($this->getHasRestroom())}\r\n" .
            "Extras: {$this->getExtras()}\r\n" .
            "Reservations: ";
        if (count($this->reservations) == 0) {
            $output .= "none\r\n";
        } else {
            $output .= "\r\n";
            foreach ($this->reservations as $reservation) {
                $output .= $reservation . "\r\n";
            }
        }

        return $output;
    }

    private function boolToEnglish($callback)
    {
        return $callback ? "yes" : "no";
    }

    private function isCollidingReservationExists(Reservation $reservation)
    {
        $reservationStartDate = $reservation->getStartDate();
        $reservationEndDate = $reservation->getEndDate();

        for ($i = 0; $i < count($this->reservations); $i++) {
            if ($reservationStartDate > $this->reservations[$i]->getEndDate() ||
                $reservationEndDate < $this->reservations[$i]->getStartDate()
            ) {
                return true;
            }

            return false;
        }
    }
}
