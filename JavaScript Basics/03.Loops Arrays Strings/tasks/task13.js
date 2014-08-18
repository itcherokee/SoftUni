// Task 13: Write a JavaScript function replaceSpaces(value) that
//          replaces the white-space characters in a text with &nbsp;.

var taskThirteen = function () {
    "use strict";
    var input;

    var replaceSpaces = function (input) {
        var pattern,
            result;

        pattern = /[\s+]/gm;
        result = input.replace(pattern, '&nbsp;');

        // place breakpoint in the browser here to see the result
        return result;

    };

    input = prompt('Enter some text with spaces');
    return replaceSpaces(input);
};