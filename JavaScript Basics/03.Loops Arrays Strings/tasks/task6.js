// Task 6:  Write a JavaScript function findMaxSequence(value) that
//          finds the maximal sequence of equal elements in an array
//          and returns the result as an array. If there is more than
//          one sequence with the same maximal length, print
//          the rightmost one.

var taskSix = function () {
    "use strict";
    var input;

    function findMaxSequence(value) {
        var index,
            len,
            result,
            count,
            element,
            newElement,
            maxCount,
            maxElement;

        function recordMax(element, count) {
            maxElement = element;
            maxCount = count;
        }

        maxCount = 0;
        maxElement = '';
        len = value.length;
        if (len > 0) {
            count = 1;
            element = value[0];
            recordMax(element, count);
            for (index = 1; index < len; index += 1) {
                newElement = value[index];
                if (newElement !== element) {
                    if (count >= maxCount) {
                        if (index + 1 === len && count === 1) {
                            recordMax(value[len - 1], count);
                        } else {
                            recordMax(element, count);
                        }
                    }

                    count = 1;
                    element = newElement;
                } else {
                    count += 1;
                    if (index + 1 === len) {
                        recordMax(element, count);
                    }
                }
            }
        }

//        result = Array(maxCount + 1).join(maxElement).split('');
        result = [];
        for(index = 0; index < maxCount; index+=1){
            result.push(maxElement);
        }

        return result;
    }

    input = prompt('Enter sequence of elements spited by comma').split(/[\s*,*]+/);
    return findMaxSequence(input);
};