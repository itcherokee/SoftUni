<?php

class RoomType
{
    const STANDARD = 'Standard';
    const GOLD = 'Gold';
    const DIAMOND = 'Diamond';

    public $roomType;

    function __construct($roomType)
    {
        if ($roomType == self::STANDARD || $roomType == self::DIAMOND || $roomType == self::GOLD) {
            $this->roomType = $roomType;
        } else {
            throw new InvalidArgumentException("Invalid room type specified.");
        }
    }

    function __toString(){
        return $this->roomType;
    }
}