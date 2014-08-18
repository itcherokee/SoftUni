// Task 10: Write a JavaScript function reverseString(value)
//          that reverses string and returns it.

var taskTen = function () {
    "use strict";
    var input;

    var reverseString = function (string) {
        return string.split('').reverse().join('');
    };

    input = prompt('Enter some string');
    return reverseString(input);
};