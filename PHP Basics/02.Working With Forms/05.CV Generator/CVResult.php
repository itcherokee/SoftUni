<?php
header('Content-Type: text/html; charset=utf-8');
session_start();
$data = '';
if (!$_SESSION['form_data']) {
    header("Location: ./CVGenerator.php");
} else {
    $data = $_SESSION['form_data'];
}

?>

<!DOCTYPE html>
<html>
<head>
    <title>CV Generator</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<table>
    <thead>
    <tr>
        <th colspan="2">Personal Information</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>First Name</td>
        <td><?= $data['fname'] ?></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td><?= $data['lname'] ?></td>
    </tr>
    <tr>
        <td>Email</td>
        <td><?= $data['email'] ?></td>
    </tr>
    <tr>
        <td>Phone Number</td>
        <td><?= $data['phone'] ?></td>
    </tr>
    <tr>
        <td>Gender</td>
        <td><?= $data['gender'] ?></td>

    </tr>
    <tr>
        <td>Birthday</td>
        <td><?= $data['birthday'] ?></td>
    </tr>
    <tr>
        <td>Nationality</td>
        <td><?= $data['nationality'] ?></td>
    </tr>
    </tbody>
</table>
<table>
    <thead>
    <tr>
        <th colspan="2">Last Work Position</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Company Name</td>
        <td><?= $data['company'] ?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?= $data['company-from'] ?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?= $data['company-to'] ?></td>
    </tr>
    </tbody>
</table>
<table>
    <thead>
    <tr>
        <th colspan="2">Computer Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Skill Level</th>
                </tr>
                </thead>
                <tbody>
                <?php
                for ($i = 0; $i < count($data['programming']); $i++): ?>
                    <tr>
                        <td><?= $data['programming'][$i] ?></td>
                        <td><?= $data['level'][$i] ?></td>
                    </tr>
                <?php endfor; ?>
                </tbody>
            </table>
        </td>
    </tr>
    </tbody>
</table>
<table>
    <thead>
    <tr>
        <th colspan="2">Other Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Comprehension</th>
                    <th>Reading</th>
                    <th>Writing</th>
                </tr>
                </thead>
                <tbody>
                <?php
                for ($i = 0; $i < count($data['skill']); $i++): ?>
                    <tr>
                        <td><?= $data['skill'][$i] ?></td>
                        <td><?= $data['comprehension'][$i] ?></td>
                        <td><?= $data['reading'][$i] ?></td>
                        <td><?= $data['writing'][$i] ?></td>
                    </tr>
                <?php endfor; ?>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td>Driver's license</td>
        <td><?= implode(", ", $data['category']) ?></td>
    </tr>
    </tbody>
</table>
</body>
</html>

