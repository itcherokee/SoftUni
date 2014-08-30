<?php
// Task 6:  Write a PHP script StringModifier.php which receives a string from an input form and
//          modifies it according to the selected option (radio button). You should support the following
//          operations: palindrome check, reverse string, split to extract leters only, hash the string
//          with the default PHP hashing algorithm, shuffle the string characters randomly. The result
//          should be displayed right under the input field. Styling the page is optional. Think about
//          which of the modification can be achieved with already built-in functions in PHP.
//          Where necessary, write your own algorithms to modify the given string. Hint: Use the crypt()
//          function for the "Hash String" modification.

header("Content-Type: text/html; charset=utf8");
require('./functions.php');
if (!empty($_POST['user-input'])) {
    $string = htmlentities($_POST['user-input']);
    $selection = htmlentities($_POST['option']);
    $result = '';
    switch ($selection) {
        case 'palindrome':
            if (isPalindrome($string)) {
                $result = "$string is a palindrome!";
            } else {
                $result = "$string is not a palindrome!";
            }
            break;
        case "shuffle" :
            $result = str_shuffle($string);
            break;
        case "reverse" :
            $result = reverse($string);
            break;
        case "hash" :
            $result = password_hash($string, PASSWORD_BCRYPT);
            break;
        case"split":
            $result = preg_replace('/[\P{L}]+/u', '', $string);
            $result = implode(' ', preg_split('//u', $result, -1, PREG_SPLIT_NO_EMPTY));
            break;
        default:
            $result = 'Unknown error occurred!';
    }
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Modify String</title>
</head>
<body>
<form action="" method="post">
    <input type="text" name="user-input" id="user-input"/>
    <input type="radio" name="option" value="palindrome" checked/>
    <span>Check Palindrome</span>
    <input type="radio" name="option" value="reverse"/>
    <span>Reverse String</span>
    <input type="radio" name="option" value="split"/>
    <span>Split</span>
    <input type="radio" name="option" value="hash"/>
    <span>Hash String</span>
    <input type="radio" name="option" value="shuffle"/>
    <span>Shuffle String</span>
    <input type="submit" value="Submit"/>
</form>
<?php if (!empty($_POST['user-input'])): ?>
    <div><?= $result ?></div>
<?php endif; ?>
<script>
    document.getElementById('user-input').value = "<?php  echo $_POST['user-input']; ?>";
</script>
</body>
</html>