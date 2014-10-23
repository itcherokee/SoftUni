<?php

class Reservation
{
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, Guest $guest)
    {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    private function setEndDate($endDate)
    {
        $this->endDate = $endDate;
    }

    public function getEndDate()
    {
        $date = new DateTime();
        $date->setTimestamp($this->endDate);
        return $date;
    }

    private function setGuest($guest)
    {
        $this->guest = $guest;
    }

    public function getGuest()
    {
        return $this->guest;
    }

    private function setStartDate($startDate)
    {
        $this->startDate = $startDate;
    }

    public function getStartDate()
    {
        $date = new DateTime();
        $date->setTimestamp($this->startDate);
        return $date;
    }

    public function getStartDateAsString()
    {
        $date = new DateTime();
        $date->setTimestamp($this->startDate);
        return $date;
    }

    function __toString()
    {
        $output = "Guest info: {$this->getGuest()}\r\n" .
            "Start date: {$this->getStartDate()->format('d-m-Y')}\r\n" .
            "End date: {$this->getEndDate()->format('d-m-Y')}\r\n";

        return $output;
    }


} 