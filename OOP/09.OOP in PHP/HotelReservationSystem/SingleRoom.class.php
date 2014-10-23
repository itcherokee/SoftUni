<?php

class SingleRoom extends Room
{
    const HAS_RESTROOM = true;
    const HAS_BALCONY = false;
    const BED_COUNT = 1;
    const EXTRAS = "TV, air-conditioner";

    function __construct($roomNumber, $price)
    {
        if (!empty($roomNumber) && ctype_digit($roomNumber) && !empty($price) && is_numeric($price)) {
            parent::__construct(intval($roomNumber), doubleval($price),
                self::BED_COUNT, self::HAS_BALCONY, new RoomType(RoomType::STANDARD), self::EXTRAS, self::HAS_RESTROOM);
        } else {
            throw new InvalidArgumentException("Invalid parameters provided.");
        }
    }
}