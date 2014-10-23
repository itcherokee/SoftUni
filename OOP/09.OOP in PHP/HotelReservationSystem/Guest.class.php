<?php

class Guest
{
    private $firstName;
    private $lastName;
    private $id;

    function __construct($firstName, $lastName, $id)
    {
        $this->setFirstName($firstName);
        $this->setId($id);
        $this->setLastName($lastName);
    }

    private function setFirstName($firstName)
    {
        if (empty($firstName) || !ctype_alpha($firstName)) {
            throw new InvalidArgumentException("First name cannot be null/empty or consist of other chars than letters!");
        }

        $this->firstName = $firstName;
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    private function setId($id)
    {
        if ((is_int($id) || is_double($id))){
            $this->id = strval($id);
        } else if (is_string($id) && ctype_digit($id)) {
            $this->id = $id;
        } else {
            throw new InvalidArgumentException("Id (EGN) cannot be null/empty or consist of other chars than numbers!");
        }
    }

    public function getId()
    {
        return $this->id;
    }

    private function setLastName($lastName)
    {
        if (empty($lastName) || !ctype_alpha($lastName)) {
            throw new InvalidArgumentException("Last name cannot be null/empty or consist of other chars than letters!");
        }

        $this->lastName = $lastName;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    function __toString()
    {
        return "{$this->getFirstName()} {$this->getLastName()}";
    }
}