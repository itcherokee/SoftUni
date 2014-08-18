// Task 4:  Write a JavaScript function biggerThanNeighbors(index, arr) that accept
//          a number and an integer array as parameters. The function should return
//          a Boolean number: whether the element at the given position in the array
//          is bigger than its two neighbors (when such exist). It should return
//          undefined when the index doesn't exist.

var taskFour = function () {
    "use strict";
    var position,
        numbers,
        output;

    var biggerThanNeighbors = function (position, numbers) {
        var result,
            target,
            areAllNumbers;

        result = 'invalid input data';
        if (arguments.length === 2) {
            if (!isNaN(position) && (numbers instanceof Array) &&
                    isFinite(position) && (position % 1 === 0)) {
                areAllNumbers = numbers.every(function (element, index, arr) {
                    return !isNaN(element);
                });

                if (!areAllNumbers) {
                    return result;
                }

                position = +position;
                if (numbers[position] === undefined) {
                    return undefined;
                }

                if (position === 0 || position === numbers.length - 1) {
                    return 'only one neighbor';
                }

                target = numbers[position];
                result = !!(numbers[position - 1] < target && target > numbers[position + 1]);
            }
        }

        return result;
    };

    position = prompt("Enter position of number").split(/[\s*,*]+/)[0];
    numbers = prompt("Enter numbers separated by comma").split(/[\s*,*]+/);
    output = biggerThanNeighbors(position, numbers);
    switch (output) {
        case false:
            output = 'not bigger';
            break;
        case true:
            output = 'bigger';
            break;
        case undefined:
            output = 'invalid index';
            break;
        default:
            break;
    }

    return output;
};