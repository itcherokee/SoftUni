// Task 04: Write a JavaScript function isPrime(value) that checks if an integer number is prime.
//          Write JS program primeChecker.js that checks if a few numbers are prime. The result
//          should be printed on the console (true or false) on the console.
//          Run the program through Node.js

(function () {
    "use strict";
    function isPrime(value) {
        var isPrime,
            divider,
            maxDivider;
        if (isNaN(value) || !isFinite(value) || value % 1 !== 0 || value <= 1) {
            return;
        }

        isPrime = true;
        divider = 2;
        maxDivider = Math.sqrt(value);
        while (divider <= maxDivider) {
            if (value % divider === 0) {
                isPrime = false;
                break;
            }

            divider += 1;
        }

        return isPrime;
    }

    var firstNumber = 7,
        secondNumber = 254,
        thirdNumber = 587;

    console.log(isPrime(firstNumber));
    console.log(isPrime(secondNumber));
    console.log(isPrime(thirdNumber));
}());