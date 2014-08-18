// Task 11: Write a JavaScript function checkBrackets(value) to check
//          if in a given expression the brackets are put correctly.

var taskEleven = function () {
    "use strict";
    var input;

    var checkBrackets = function (expression) {
        var brackets,
            index,
            len,
            justStarted,
            incorrect,
            leftBracket,
            rightBracket;

        brackets = [];
        justStarted = true;
        incorrect = 'incorrect';
        leftBracket = '(';
        rightBracket = ')';
        for (index = 0, len = expression.length; index < len; index += 1) {
            if (expression[index] !== leftBracket && expression[index] !== rightBracket) {
                continue;
            }

            if (justStarted) {
                if (expression[index] === leftBracket) {
                    brackets.push(expression[index]);
                    justStarted = false;
                } else {
                    return incorrect;
                }
            } else {
                if (expression[index] === leftBracket && index+1 !== len){
                    brackets.push(expression[index]);
                } else if (expression[index] === rightBracket && brackets[brackets.length -1] === leftBracket){
                    brackets.pop();
                } else {
                    return incorrect;
                }
            }
        }

        if (brackets.length === 0){
            return 'correct';
        } else {
            return incorrect;
        }
    };

    input = prompt('Enter some expression with brackets');
    return checkBrackets(input);
};