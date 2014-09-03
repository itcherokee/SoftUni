<?php
$sortColumn = $_GET['column'];
$sortOrder = $_GET['order'];
$studentsInfo = $_GET['students'];


class Student
{
    public $id;
    public $name;
    public $email;
    public $type;
    public $result;

    function __construct($id, $name, $email, $type, $result)
    {
        $this->id = $id;
        $this->name = $name;
        $this->email = $email;
        $this->type = $type;
        $this->result = (int)$result;
    }
}

$id = 1;
$students = array();
$allStudents = preg_split('/\r\n/', $studentsInfo, -1, PREG_SPLIT_NO_EMPTY);
for ($i = 0; $i < count($allStudents); $i++) {
    $student = preg_split('/,\s*/', $allStudents[$i], -1, PREG_SPLIT_NO_EMPTY);
    $students[] = new Student($id, $student[0], $student[1], $student[2], $student[3]);
    $id++;
}

usort($students, function ($a, $b) use ($sortColumn, $sortOrder) {
    $result = "";
    switch ($sortColumn) {
        case "id":
            if ($sortOrder == 'ascending') {
                $result = $a->id - $b->id;
            } else {
                $result = $b->id - $a->id;
            }
            break;
        case "username":
            if ($sortOrder == 'ascending') {
                if ($a->name === $b->name) {
                    $result = $a->id - $b->id;
                } else {
                    $result = $a->name > $b->name;
                }

            } else {
                if ($a->name === $b->name) {
                    $result = $b->id - $a->id;
                } else {
                    $result = $b->name < $a->name;
                }
            }
            break;
        case "result":
            if ($sortOrder == 'ascending') {
                if ($a->result === $b->result) {
                    $result = $a->id - $b->id;
                } else {
                    $result = $a->result - $b->result;
                }

            } else {
                if ($a->result === $b->result) {
                    $result = $b->id - $a->id;
                } else {
                    $result = $b->result - $a->result;
                }
            }
            break;
    }

    return $result;
});

echo printResult($students);

function printResult($data)
{
    $result = "<thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";
    for ($row = 0; $row < count($data); $row++) {
        $result .= "<tr>";
        $result .= "<td>" . htmlspecialchars($data[$row]->id) . "</td>";
        $result .= "<td>" . htmlspecialchars($data[$row]->name) . "</td>";
        $result .= "<td>" . htmlspecialchars($data[$row]->email) . "</td>";
        $result .= "<td>" . htmlspecialchars($data[$row]->type) . "</td>";
        $result .= "<td>" . htmlspecialchars($data[$row]->result) . "</td>";
        $result .= "</tr>";
    }
    return "<table>{$result}</table>";
}