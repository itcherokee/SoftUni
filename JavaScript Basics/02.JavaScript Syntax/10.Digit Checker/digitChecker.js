// Task 10: Write a JavaScript function checkDigit(value) that finds if the third digit (right-to-left) of
//          an integer number n (n>1000) is 3. Write JS program digitChecker.js that checks a few numbers.
//          The result (true or false) should be printed on the console. Run the program through Node.js

(function () {
    "use strict";
    function checkDigit(number) {
        if (isNaN(number) || !isFinite(number) || number % 1 !== 0 || number <= 1000) {
            throw 'Invalid number provided!';
        }

        return Math.floor(number / 100) % 10 === 3;
    }

    var firstNumber = -1235,
        secondNumber = 25368,
        thirdNumber = 123456;

    try {
        console.log(checkDigit(firstNumber));
        console.log(checkDigit(secondNumber));
        console.log(checkDigit(thirdNumber));
    }
    catch (e) {
        console.log(e);
    }
}());