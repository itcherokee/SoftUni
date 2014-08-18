// Task 1:  Write a JavaScript function printNumbers(n) that accepts as parameter
//          integer n. The function finds all integer numbers from 1 to n that are
//          not divisible by 4 or by 5.

var taskOne = function () {
    "use strict";
    var input;

    var printNumbers = function (upperBoarder) {
        var index,
            result,
            output;

        result = [];
        output = 'no';
        if (!isNaN(upperBoarder) && upperBoarder >= 1) {
            for (index = 1; index <= upperBoarder; index++) {
                if (index % 4 !== 0 && index % 5 !== 0) {
                    result.push(index);
                }
            }

            output = result.join(',');
        }

        return output;
    };

    input = parseInt(prompt("Enter upper border N"), 10);
    return printNumbers(input);
};