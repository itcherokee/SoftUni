// Task 16: Write a JavaScript function findCardFrequency(value) that
//          that accepts the following parameters: array of several
//          cards (face + suit), separated by a space. The function
//          calculates and prints at the console the frequency of each
//          card face in format "card_face -> frequency". The frequency
//          is calculated by the formula appearances / N and is expressed
//          in percentages with exactly 2 digits after the decimal point.
//          The card faces with their frequency should be printed in the
//          order of the card face's first appearance in the input.
//          The same card can appear multiple times in the input,
//          but its face should be listed only once in the output.

var taskSixteen = function () {
    "use strict";
    var input;

    var findCardFrequency = function (cards) {
        var words,
            result,
            groupedWords,
            index,
            len,
            wordLength,
            keys,
            count;

        words = cards.toUpperCase().split(/[\s\W^_]+/);

        // count and group cards excluding empty ones
        keys = [];
        groupedWords = {};
        count = 0;
        for (index = 0, len = words.length; index < len; index += 1) {
            wordLength = words[index].length;
            if (wordLength) {
                count += 1;
                if (groupedWords[words[index]]) {
                    groupedWords[words[index]] += 1;
                } else {
                    groupedWords[words[index]] = 1;
                    keys.push(words[index]);
                }
            }
        }

        // parse & calculate output
        result = '';
        for (index = 0, len = keys.length; index < len; index += 1) {
            result += keys[index] + ' -&gt; ' + (groupedWords[keys[index]] / count * 100).toFixed(2) + '%<br />';
        }

        return result;
    };

    input = prompt('Enter some cards (face+suit)');
    return findCardFrequency(input);
};