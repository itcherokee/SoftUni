<?php

class EReservationException extends Exception
{
    private $message = "Reservation already exists!";

    public function __construct()
    {
        parent::__construct($this->message, 0, null);
    }

    public function __toString()
    {
        return __CLASS__ . ": [{$this->code}]: {$this->message}\n";
    }
}
