// Task 8:  Sorting an array means to arrange its elements
//          in increasing order. Write a JavaScript function
//          sortArray(value) to sort an array. Use the "selection sort"
//          algorithm: find the smallest element, move it at the first
//          position, find the smallest from the rest, move it at
//          the second position, etc.

var taskEight = function () {
    "use strict";
    var input;

    var sortArray = function (numbers) {
        var sortedArray,
            index,
            len,
            parsedNumber,
            smallestNumber,
            smallestNumberIndex;

        // convert string array to numbers array
        numbers.forEach(function (element, index, array) {
            parsedNumber = parseFloat(array[index]);
            if (isNaN(parsedNumber)) {
                return "not a number detected in the input data!"
            }

            array[index] = parsedNumber;
        });

        sortedArray = [];
        while (numbers.length > 0) {
            smallestNumber = numbers[0];
            smallestNumberIndex = 0;
            for (index = 1, len = numbers.length; index < len; index += 1) {
                if (smallestNumber < numbers[index]) {
                    continue;
                }

                smallestNumber = numbers[index];
                smallestNumberIndex = index;
            }

            numbers.splice(smallestNumberIndex,1);
            sortedArray.push(smallestNumber);
        }

        return sortedArray;
    };

    input = prompt('Enter sequence of numbers spited by comma').split(/[\s*,*]+/);
    return sortArray(input).join(', ');
};