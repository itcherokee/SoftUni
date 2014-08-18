// Task 12: Write a JavaScript function countSubstringOccur(value) that
//          accepts as parameter an array of 2 elements arr [keyword, text].
//          The function finds how many times a substring is contained
//          in a given text (perform case insensitive search).

var taskTwelve = function () {
    "use strict";
    var keyword,
        text;

    var countSubstringOccur = function (input) {
        var keyword,
            text,
            occurrences,
            result;

        keyword = input[0];
        text = input[1];
        occurrences = text.match(new RegExp(keyword,'gi'));
        if(occurrences === null){
            result = 0;
        } else {
            result = occurrences.length;
        }

        return result.toString();

    };

    keyword = prompt('Enter word to search');
    text = prompt('Enter text where to search for the word');
    return countSubstringOccur([keyword, text]);
};
