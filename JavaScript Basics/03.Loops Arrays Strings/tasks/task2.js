// Task 02: Write a JavaScript function findMinAndMax(value) that accepts
//          as parameter an array of numbers. The function finds the minimum
//          and the maximum number.

var taskTwo = function () {
    "use strict";
    var input;

    var findMinAndMax = function (numbers) {
        var output,
            min,
            max;

        min = Math.min.apply(this, numbers);
        max = Math.max.apply(this, numbers);
        if (isNaN(min)){
            output = 'Invalid input detected!';
        } else {
            output = 'input: ' + input + '; Min -&gt; ' + min + '; Max -&gt; ' + max + ';' + "<br />";
        }

        return output;
    };

    input = prompt("Enter numbers separated by comma").split(/[\s*,*]+/);
    return findMinAndMax(input);
};