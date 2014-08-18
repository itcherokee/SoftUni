// Task 11: Write a JavaScript function convertDigitToWord(value) that prints the name of an integer
//          number n (0<n<10) in English using switch statement. Write JS program digitAsWord.js that
//          prints a few digits on the console. Run the program through Node.js.

(function () {
    "use strict";
    function convertDigitToWord(number) {
        var result;
        if (typeof number !== "number" || !isFinite(number) || number % 1 !== 0 || number < 0 || number > 9) {
            throw 'Invalid number provided!';
        }

        switch (number) {
            case 0:
                result = 'zero';
                break;
            case 1:
                result = 'one';
                break;
            case 2:
                result = 'two';
                break;
            case 3:
                result = 'three';
                break;
            case 4:
                result = 'four';
                break;
            case 5:
                result = 'five';
                break;
            case 6:
                result = 'six';
                break;
            case 7:
                result = 'seven';
                break;
            case 8:
                result = 'eight';
                break;
            case 9:
                result = 'nine';
                break;
        }

        return result;
    }

    var firstNumber = 8,
        secondNumber = 3,
        thirdNumber = 5;

    console.log(convertDigitToWord(firstNumber));
    console.log(convertDigitToWord(secondNumber));
    console.log(convertDigitToWord(thirdNumber));
}());