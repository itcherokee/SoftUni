<?php
// Task 03: Write a PHP script DumpVariable.php that declares a variable. If the variable
//          is numeric, print it by the built-in function var_dump(). If the variable is
//          not numeric, print its type at the input.

//$variable = "hello";
$variable = 15;
//$variable = 1.234;
//$variable = array(1, 2, 3);
//$variable = (object)[2, 34];

// first solution
$variableType = gettype($variable);
switch ($variableType) {
    case 'integer':
    case 'float':
    case 'double':
        var_dump($variable);
        break;
    default:
        echo $variableType;
        break;
}

// second solution
//if (is_numeric($variable)){
//    var_dump($variable);
//} else {
//   echo gettype($variable);
//}
?>