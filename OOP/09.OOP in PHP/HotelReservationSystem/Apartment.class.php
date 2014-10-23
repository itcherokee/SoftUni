<?php

class Apartment extends Room
{
    const HAS_RESTROOM = true;
    const HAS_BALCONY = true;
    const BED_COUNT = 4;
    const EXTRAS = "TV, air-conditioner, refrigerator, kitchen box, mini-bar, bathtub, free Wi-fi";

    function __construct($roomNumber, $price)
    {
        if (!empty($roomNumber) && ctype_digit($roomNumber) && !empty($price) && is_numeric($price)) {
            parent::__construct(intval($roomNumber), doubleval($price),
                self::BED_COUNT, self::HAS_BALCONY, new RoomType(RoomType::DIAMOND), self::EXTRAS, self::HAS_RESTROOM);
        } else {
            throw new InvalidArgumentException("Invalid parameters provided.");
        }
    }
} 