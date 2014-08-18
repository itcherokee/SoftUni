// Task 15: Write a JavaScript function findMostFreqWord(value) that
//          finds the most frequent word in a text and prints it, as
//          well as how many times it appears in format "word -> count".
//          Consider any non-letter character as a word separator.
//          Ignore the character casing. If several words have the same
//          maximal frequency, print all of them in alphabetical order.

var taskFifteen = function () {
    "use strict";
    var input;

    var findMostFreqWord = function (string) {
        var words,
            result,
            groupedWords,
            index,
            len,
            wordLength,
            maxCount,
            maxKeys,
            key;

        words = string.toLowerCase().split(/[\W^_]+/gim);
        groupedWords = {};
        maxCount = 0;

        // count and group words excluding empty ones
        for (index = 0, len = words.length; index < len; index += 1) {
            wordLength = words[index].length;
            if (wordLength) {
                if (groupedWords[words[index]]) {
                    groupedWords[words[index]] += 1;
                } else {
                    groupedWords[words[index]] = 1;
                }

                if (maxCount < groupedWords[words[index]]) {
                    maxCount = groupedWords[words[index]];
                }
            }
        }

        // find most frequent
        maxKeys = [];
        for (key in groupedWords) {
            if (groupedWords[key] === maxCount) {
                maxKeys.push(key);
            }
        }

        // sort keys with max frequency
        maxKeys.sort();

        // parse output
        result = '';
        for (index = 0, len = maxKeys.length; index < len; index += 1) {
            result += maxKeys[index] + ' -&gt; ' + groupedWords[maxKeys[index]] + ' times <br />';
        }

        return result;
    };

    input = prompt('Enter some text');
    return findMostFreqWord(input);
};