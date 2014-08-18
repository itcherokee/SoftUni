// Task 5:  Write a JavaScript function compareChars(value) that
//          compares two arrays of chars lexicographically (letter by letter).
//
// Note:    The task says lexicographically, but there is no anything that is
//          lexicographical in the given demo and the expected/required answer.

var taskFive = function () {
    "use strict";
    var arrayOne,
        arrayTwo;

    var compareChars = function (arrayOne, arrayTwo) {
        var index,
            len,
            output,
            newLine;

        // compare arrays' lengths to find shorter one
        len = arrayOne.length < arrayTwo ? arrayOne.length : arrayTwo.length;

        //compare char by char
        //(order of precedence: symbols, numbers, upper case char, lower case char)
        output = 'Equal';
        for (index = 0; index < len; index += 1) {
            if (arrayOne[index] !== arrayTwo[index]) {
                output = 'Not Equal';
                break;
            }
        }

        newLine = '<br />';
        return 'Array 1: ' + arrayOne.join(', ') + newLine +
            'Array 2: ' + arrayTwo.join(', ') + newLine +
            output + newLine;
    };

    arrayOne = prompt('Enter first sequence of characters spited by comma').split(/[\s*,*]+/);
    arrayTwo = prompt('Enter first sequence of characters spited by comma').split(/[\s*,*]+/);
    return compareChars(arrayOne, arrayTwo);
};