// Task 14: Write a JavaScript function findPalindromes(value)
//          that extracts from a given text all palindromes,
//          e.g. "ABBA", "lamal", "exe".

var taskFourteen = function () {
    "use strict";
    var input;

    var findPalindromes = function (value) {
        var words,
            result,
            index,
            len,
            letterIndex,
            letterLength,
            isPalindrome;

        words = value.toLowerCase().split(/[\W^_]+/gim);
        result = [];
        for (index = 0, len = words.length; index < len; index += 1) {
            letterLength = words[index].length;
            if (letterLength) {
                isPalindrome = true;
                for (letterIndex = 0; letterIndex < letterLength; letterIndex += 1) {
                    if (words[index][letterIndex] !== words[index][letterLength - letterIndex - 1]) {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome) {
                    result.push(words[index]);
                }
            }
        }

        return result.join(', ');
    };

    input = prompt('Enter some text');
    return findPalindromes(input);
};