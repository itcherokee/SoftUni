// Task 02: Write a JavaScript function findNthDigit(arr) that accepts
//          as a parameter an array of two numbers num and n and returns
//          the n-th digit of given decimal number num counted from right
//          to left. Return undefined when the number does not have
//          n-th digit.

var taskTwo = function () {
    "use strict";
    var input,
        result;

    // parameter format: [ n - nth number, num - number to be processed]
    var findNthDigit = function (numbers) {
        var output,
            number,
            index,
            decimalPointPos;

        if (numbers.constructor === Array && arguments[0].length > 1) {
            number = numbers[1];
            index = numbers[0];
            if (!isNaN(number) && !isNaN(index) && isFinite(number) &&
                    isFinite(index) && index % 1 === 0 && index > 0) {
                if (number % 1 !== 0) {
                    decimalPointPos = number.indexOf('.');
                    if (decimalPointPos === -1) {
                        decimalPointPos = number.indexOf(',');
                    }

                    number = number.slice(0, decimalPointPos) +
                            number.slice(decimalPointPos + 1);
                }

                if (number.length < index) {
                    return;
                }

                output = number[number.length - index];
            } else {
                throw 'Invalid content of array has been provided (not a number, real number as index, etc.)!';
            }
        } else {
            throw 'Invalid input has been provided (not an array) or less than two elements in the array!';
        }

        return output;
    };

    input = prompt("Enter numbers separated by comma [index (>0), number]").split(/[\s*,*]+/);
    try {
        result = findNthDigit(input) || 'The number doesn’t have ' + input[0] + ' digits';
    }
    catch (e) {
        result = e;
    }

    return result;
};