<?php

class BookingManager
{
    public static function bookRoom(Room $room, Reservation $reservation)
    {
        try {
            $room->addReservation($reservation);
            $output = "Room <strong>{$room->getRoomNumber()}</strong> successfully booked for " .
                "<strong>{$reservation->getGuest()}</strong> from " .
                "<time>{$reservation->getStartDate()->format("d.m.Y")}</time> to " .
                "<time>{$reservation->getEndDate()->format("d.m.Y")}</time>!";
            echo $output;
        } catch (EReservationException $e) {
            echo $e->getMessage();
        }
    }
}