<?php

class Seminar
{
    private $name;
    private $lecturer;
    private $time;
    private $details;

    function __construct($name, $lecturer, $time, $details)
    {
        $this->name = $name;
        $this->lecturer = $lecturer;
        $this->time = strtotime($time);
        $this->details = $details;
    }

    public function getName()
    {
        return $this->name;
    }

    public function getLecturer()
    {
        return $this->lecturer;
    }

    public function getTime()
    {
        return $this->time;
    }

    public function getFormatedTime()
    {
        return date('d-m-Y H:i', $this->time);
    }

    public function getDetails()
    {
        return $this->details;
    }
}
?>