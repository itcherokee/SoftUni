<?php
// Task 02: Write a PHP script SumTwoNumbers.php that decleares two variables, firstNumber
//          and secondNumber. They should hold integer or floating-point numbers (hard-coded values).
//          Print their sum in the output in the format shown in the examples below. The numbers
//          should be rounded to the second number after the decimal point. Find in Internet how
//          to round a given number in PHP.

$firstNumber = 1.567808;
$secondNumber = 0.356;
echo '$firstNumber + $secondNumber = ';
echo "$firstNumber + $secondNumber = ";
echo number_format((double)($firstNumber + $secondNumber), 2, '.', '');
?>