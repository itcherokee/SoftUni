// Task 02: Write a JavaScript function roundNumber(value) that rounds floating-point number using
//          Math.round(), Math.floor(). Write a JS program roundingNumbers.js that rounds a few
//          sample values. Run the program through Node.js.

(function () {
    "use strict";
    function roundNumber(value) {
        value = value || 0;
        if (isNaN(value)) {
            return;
        }

        return Math.floor(value) + '\n' + Math.round(value);
    }

    var firstNumber = 22.7,
        secondNumber = 12.3,
        thirdNumber = 58.7;

    console.log(roundNumber(firstNumber));
    console.log(roundNumber(secondNumber));
    console.log(roundNumber(thirdNumber));
}());