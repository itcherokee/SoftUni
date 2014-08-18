// Task 03: Write a JavaScript function evenNumber(value) that checks if an integer number is even.
//          Write JS program evenChecker.js to check if a few numbers are even. The result should
//          be printed on the console (true or false). Run the program through Node.js.

(function () {
    "use strict";
    function evenNumber(value) {
        if (isNaN(value)) {
            return;
        } else if (value < Math.pow(2,32) - 1) {
            return !(value & 1);
        }

        return value % 2 === 0;
    }

    var firstNumber = 3,
        secondNumber = 127,
        thirdNumber = 588;

    console.log(evenNumber(firstNumber));
    console.log(evenNumber(secondNumber));
    console.log(evenNumber(thirdNumber));
}());