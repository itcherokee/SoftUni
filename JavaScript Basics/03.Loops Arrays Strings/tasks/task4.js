// Task 4:  Write a JavaScript function createArray(value) that
//          allocates array of 20 integers and initializes each
//          element by its index multiplied by 5.

var taskFour = function () {
    "use strict";
    var numbers = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

    var createArray = function (numberArray) {
        numberArray.forEach(function (element, index, array) {
            array[index] = index * 5;
        });

        return numberArray.join(', ');
    };

    return createArray(numbers);
};