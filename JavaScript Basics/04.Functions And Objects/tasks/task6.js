// Task 6:  Write a JavaScript function countDivs(html) to count
//          the number of all DIVs in given HTML fragment passed
//          as string.

var taskSix = function () {
    "use strict";
    var input;

    function countDivs(htmlFragment) {
        var divs = htmlFragment.match(/<div/gmi);
        return divs.length;
    }

    input = prompt('Enter some HTML fragment');
    return countDivs(input);
};