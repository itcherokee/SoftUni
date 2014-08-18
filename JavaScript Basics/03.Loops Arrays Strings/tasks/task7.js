// Task 7:  Write a JavaScript function findMaxSequence(value) that
//          finds the maximal increasing sequence in an array of numbers
//          and returns the result as an array. If there is no increasing
//          sequence the function returns 'no'.

var taskSeven = function () {
    "use strict";
    var input;

    var findMaxSequence = function (value) {
        var index,
            len,
            output,
            startIndex,
            maxStartIndex,
            element,
            newElement,
            count,
            maxCount;

        element = parseFloat(value[0]);
        count = 1;
        startIndex = 0;
        maxCount = 0;
        len = value.length;
        for (index = 1; index < len; index += 1) {
            newElement = parseFloat(value[index]);
            if (element < newElement) {
                count += 1;
            } else {
                if (maxCount < count) {
                    maxStartIndex = startIndex;
                    maxCount = count;
                }

                count = 1;
                startIndex = index;
            }

            element = newElement;
        }

        if (maxCount < count) {
            maxStartIndex = startIndex;
            maxCount = count;
        }

        if (maxCount > 1) {
            output = [];
            for (index = maxStartIndex; index < maxStartIndex + maxCount; index += 1) {
                output.push(value[index]);
            }
        } else {
            output = 'no';
        }

        return output;
    };

    input = prompt("Enter sequence of numbers split by commas").split(/[\s*,*]+/);
    return findMaxSequence(input);
};