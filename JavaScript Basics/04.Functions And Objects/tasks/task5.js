// Task 5:  Write a JavaScript function reverseWordsInString(str)
//          to reverse the characters of every word in the string
//          but leaves the words in the same order. Words are
//          considered to be sequences of characters separated by spaces.

var taskFive = function () {
    "use strict";
    var input;

    var reverseWordsInString = function (text) {
        var words = text.split(' ');

        function reverseWord(word) {
            return word.split('').reverse().join('');
        }

        words.forEach(function(element, index, arr){
            arr[index] = reverseWord(arr[index]);
        });

        return words.join(' ');
    };

    input = prompt('Enter text');
    return reverseWordsInString(input);
};