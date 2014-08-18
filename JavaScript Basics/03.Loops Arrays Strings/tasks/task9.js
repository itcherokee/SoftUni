// Task 9:  Write a JavaScript function findMostFreqNum(value) that finds
//          the most frequent number in an array. If multiple numbers appear
//          the same maximal number of times, print the leftmost of them.

var taskNine = function () {
    "use strict";
    var input;

    var findMostFreqNum = function (input) {
        var parsedNumber,
            index,
            len,
            mostFrequent,
            mostFrequentCount,
            mostFrequentPosition,
            newElement,
            numbers,
            elements,
            key;

        var Element = function (position, count) {
            this.position = position;
            this.count = count;
        };

        // convert string array to numbers array
        numbers = input.slice();
        numbers.forEach(function (element, index, array) {
            parsedNumber = parseFloat(array[index]);
            if (isNaN(parsedNumber)) {
                return "not a number detected in the input data!"
            }

            array[index] = parsedNumber;
        });

        elements = {};
        for (index = 0, len = numbers.length; index < len; index += 1) {
            newElement = numbers[index];
            if (elements[newElement]) {
                elements[newElement].count += 1;
            } else {
                elements[newElement] = new Element(index, 1);
            }
        }

        mostFrequentCount = 0;
        mostFrequentPosition = -1;
        for (key in elements){
            if (elements[key].count > mostFrequentCount){
                mostFrequentCount = elements[key].count;
                mostFrequent = key;
                mostFrequentPosition = elements[key].position;
            } else if (elements[key].count === mostFrequentCount){
                if (elements[key].position < mostFrequentPosition){
                    mostFrequentCount = elements[key].count;
                    mostFrequent = key;
                    mostFrequentPosition = elements[key].position;
                }
            }
        }

        return mostFrequent + ' (' + mostFrequentCount + ' times)';
    };

    input = prompt('Enter sequence of numbers spited by comma').split(/[\s*,*]+/);
    return findMostFreqNum(input);
};