<?php
//Task 5:   Write a PHP script CVGenerator.php which generates an HTML form like in the example below.
//          When the information is submitted (via Generate CV), the script should print out a simple
//          table-like CV. Semantic HTML is required. Styling is not required.

session_start();
header('Content-Type: text/html; charset=utf-8');
function parseInput($data)
{
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlentities($data);
    return $data;
}

function isValid($value, $includeNumbers = false)
{
    if (strlen($value) >= 2 && strlen($value <= 20)) {
        return $includeNumbers ? ctype_alnum($value) : ctype_alpha($value);
    }

    return false;
}

$fNameError = $lNameError = $emailError = $phoneError = $companyError = $programmingError = $skillError = '';
$allRequiredAreValid = true;
$allValues = array();

function parseRequired(&$formValues)
{
    global $fNameError, $lNameError, $emailError, $phoneError, $companyError, $programmingError, $skillError;
    define("INVALID_DATA", "* Invalid data provided!");
    define("MISSING_DATA", "* Field must have a value!");

    if (empty($_POST["fname"])) {
        $fNameError = MISSING_DATA;
        return false;
    } else {
        $fname = parseInput($_POST["fname"]);
        if (!isValid($fname)) {
            $fNameError = INVALID_DATA;
            return false;
        }

        $formValues['fname'] = $fname;
    }

    if (empty($_POST["lname"])) {
        $lNameError = MISSING_DATA;
        return false;
    } else {
        $lname = parseInput($_POST["lname"]);
        if (!isValid($lname)) {
            $lNameError = INVALID_DATA;
            return false;
        }
    }

    $formValues['lname'] = $lname;
    if (empty($_POST["email"])) {
        $emailError = MISSING_DATA;
        return false;
    } else {
        $email = filter_var($_POST["email"], FILTER_VALIDATE_EMAIL);
        if (!$email) {
            $emailError = INVALID_DATA;
            return false;
        }
    }

    $formValues['email'] = $email;
    if (empty($_POST["company"])) {
        $companyError = MISSING_DATA;
        return false;
    } else {
        $company = parseInput($_POST["company"]);
        if (!preg_match('/[A-Za-z0-9 ]/', $company)) {
            $companyError = INVALID_DATA;
            return false;
        }
    }

    $formValues['company'] = $company;
    if (empty($_POST["phone"])) {
        $phoneError = MISSING_DATA;
        return false;
    } else {
        $phone = parseInput($_POST["phone"]);
        if (!preg_match('/^\+?[\d\s-]*$/', $phone)) {
            $phoneError = INVALID_DATA;
            return false;
        }
    }

    $formValues['phone'] = $phone;
    $programmingLangs = $_POST["programming"];
    foreach ($programmingLangs as $language) {
        if (empty($language)) {
            $programmingError = MISSING_DATA;
            return false;
        } else {
            if (!isValid($language)) {
                $programmingError = INVALID_DATA;
                return false;
            }
        }
    }

    $formValues['programming'] = $programmingLangs;
    $skillLangs = $_POST["skill"];
    foreach ($skillLangs as $language) {
        if (empty($language)) {
            $skillError = MISSING_DATA;
            return false;
        } else {
            if (!isValid($language)) {
                $skillError = INVALID_DATA;
                return false;
            }
        }
    }

    $formValues['skill'] = $skillLangs;
    if (!empty($_POST['gender'])) {
        $formValues['gender'] = $_POST['gender'];
    } else {
        $formValues['gender'] = 'unknown';
    }
    $formValues['birthday'] = $_POST['birthday'];
    $formValues['nationality'] = $_POST['nationality'];
    $formValues['company-from'] = $_POST['company-from'];
    $formValues['company-to'] = $_POST['company-to'];
    $formValues['level'] = $_POST['level'];
    $formValues['comprehension'] = $_POST['comprehension'];
    $formValues['reading'] = $_POST['reading'];
    $formValues['writing'] = $_POST['writing'];
    $formValues['category'] = [];
    if (isset($_POST['catA'])) {
        $formValues['category'][] = $_POST['catA'];
    }
    if (isset($_POST['catB'])) {
        $formValues['category'][] = $_POST['catB'];
    }
    if (isset($_POST['catC'])) {
        $formValues['category'][] = $_POST['catC'];
    }
    return true;
}

if (isset($_POST['fname']) && isset($_POST['lname']) && isset($_POST['email']) && isset($_POST['phone']) &&
    isset($_POST['company']) && isset($_POST['programming']) && isset($_POST['skill'])
) {
    $allRequiredAreValid = parseRequired($allValues);
}

if (!empty($_POST) && $allRequiredAreValid) {
    $_SESSION['form_data'] = $allValues;
    header("Location: ./CVResult.php");
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>CV Generator</title>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<section>
    <form action="" method="post">
        <fieldset>
            <legend>Personal Information</legend>
            <div>
                <input type="text" name="fname" placeholder="First Name"/>
                <span class="error"><?= $fNameError; ?></span>
            </div>
            <div>
                <input type="text" name="lname" placeholder="Last Name"/>
                <span class="error"><?= $lNameError; ?></span>
            </div>
            <div>
                <input type="email" name="email" placeholder="Email"/>
                <span class="error"><?= $emailError; ?></span>
            </div>
            <div>
                <input type="tel" name="phone" placeholder="Phone Number"/>
                <span class="error"><?= $phoneError; ?></span>
            </div>
            <div>
                <label for="gender-female">Female</label>
                <input type="radio" name="gender" id="gender-female" value="Female"/>
                <label for="gender-male">Male</label>
                <input type="radio" name="gender" id="gender-male" value="Male"/>
            </div>
            <label for="birthday">Birthday</label>
            <input type="date" name="birthday" id="birthday" class="new-line"/>
            <label for="nationality">Nationality</label>
            <label for="nationality" id="nationality"></label>
            <select name="nationality" class="new-line">
                <option value="unknown" hidden="hidden">-Select-</option>
                <option value="Bulgarian">Bulgarian</option>
                <option value="Vietnamese">Vietnamese</option>
                <option value="Tadzhik">Tadzhik</option>
            </select>
        </fieldset>
        <fieldset>
            <legend>Last Work Position</legend>
            <div>
                <label for="company">Company Name</label>
                <input type="text" name="company" id="company"/>
                <span class="error"><?= $companyError; ?></span>

            </div>
            <div>
                <label for="company-from">From</label>
                <input type="date" name="company-from" id="company-from"/>
            </div>
            <div>
                <label for="company-to">To</label>
                <input type="date" name="company-to" id="company-to"/>
            </div>
        </fieldset>
        <fieldset>
            <legend>Computer Skills</legend>
            Programming Languages <span class="error"><?= $programmingError; ?></span>

            <div id="programming-languages"></div>
            <input type="button" value="Remove Language" id="remove-programming"/>
            <input type="button" value="Add Language" id="add-programming"/>
        </fieldset>
        <fieldset>
            <legend>Other Skills</legend>
            Languages <span class="error"><?= $skillError; ?></span>

            <div id="other-skills"></div>
            <input type="button" value="Remove Language" id="remove-skill"/>
            <input type="button" value="Add Language" id="add-skill"/>

            <div id="driver-license">
                <div>Driver's License</div>
                <label for="catB">B</label>
                <input type="checkbox" name="catB" id="catB" value="B"/>
                <label for="catA">A</label>
                <input type="checkbox" name="catA" id="catA" value="A"/>
                <label for="catC">C</label>
                <input type="checkbox" name="catC" id="catC" value="C"/>
            </div>
        </fieldset>
        <input type="submit" value="Generate CV"/>
    </form>
    <script src="scripts/script.js"></script>
</section>
</body>
</html>