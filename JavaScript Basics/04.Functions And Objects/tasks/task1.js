// Task 1:  Write a JavaScript function lastDigitAsText(number) that
//          returns the last digit of given integer as an English word.

var taskOne = function () {
    "use strict";
    var input;

    var lastDigitAsText = function (number) {
        var lastDigit,
            output;

        if (!isNaN(number) && isFinite(number) && number % 1 === 0) {
            lastDigit = +(number % 10); // implicitly convert to number
            if (lastDigit < 0) {
                lastDigit *= -1;
            }

            switch (lastDigit){
                case 0:
                    output = 'Zero';
                    break;
                case 1:
                    output = 'One';
                    break;
                case 2:
                    output = 'Two';
                    break;
                case 3:
                    output = 'Three';
                    break;
                case 4:
                    output = 'Four';
                    break;
                case 5:
                    output = 'Five';
                    break;
                case 6:
                    output = 'Six';
                    break;
                case 7:
                    output = 'Seven';
                    break;
                case 8:
                    output = 'Eight';
                    break;
                case 9:
                    output = 'Nine';
                    break;
                default:
                    output = 'something unusual and impossible happened here!';
                    break;
            }
        } else {
            output = 'not a number detected or it was real or not finite!';
        }

        return output;
    };

    input = prompt("Enter a number (integer)");
    return lastDigitAsText(input);
};