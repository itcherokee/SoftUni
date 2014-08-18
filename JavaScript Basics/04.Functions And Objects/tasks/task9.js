// Task 9*:  Write a JavaScript function removeItem(value) that accept as parameter
//           a number or string. The function should remove all elements with
//           the given value from an array. Attach the function to the Array type.
//           You may need to read about prototypes in JavaScript and how to attach
//           methods to object types. You should return as a result the modified array.

var taskNine = function () {
    "use strict";
    var arrayOne,
        arrayTwo,
        result;

    Array.prototype.removeItem = function (item) {
        var output = this;
        switch (typeof item) {
            case 'string':
                item = output.indexOf(item, 0);
                // intentionally left to bypass to next 'case' - same operation
            case 'number':
                output.splice(item, 1);
                break;
            default:
                // leave the original array intact
        }

        return output;
    };

    arrayOne = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
    arrayTwo = ['hi', 'bye', 'hello' ];

    result = 'Array 1: ' + arrayOne + '<br/> Result: ' + arrayOne.removeItem(1) + ' - element[1] removed <br/>' +
        'Array 2: ' + arrayTwo + '<br/> Result: ' + arrayTwo.removeItem('bye') + ' - element "bye" removed  <br/>';

    return result;
};