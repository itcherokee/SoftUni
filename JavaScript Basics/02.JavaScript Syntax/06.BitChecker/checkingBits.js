// Task 06: Write a JavaScript function bitChecker(value) that finds if the bit 3 an integer
//          number (counting from 0) is 1. Write JS program checkingBits.js to check a few numbers.
//          The result (true or false) should be printed on the console. Run the program through Node.js.

(function () {
    "use strict";
    function bitChecker(value, bit) {
        bit = bit || 3;
        if (isNaN(value)) {
            return;
        }

        return (value & (1 << bit)) != 0;
    }

    var firstNumber = 333,
        secondNumber = 425,
        thirdNumber = 2567564754;

    console.log(bitChecker(firstNumber));
    console.log(bitChecker(secondNumber));
    console.log(bitChecker(thirdNumber));
}());