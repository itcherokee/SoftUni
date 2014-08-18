// Task 05: Write a JavaScript function divisionBy3(value) that finds the sum of digits of integer number n (n > 9)
//          and checks if the sum is divided by 3 without remainder. Write JS program divisionChecker.js to check
//          a few numbers. The result should be printed on the console (“the number is divided by 3 without remainder”
//          or “the number is not divided by 3 without remainder”). Run the program through Node.js

(function () {
    "use strict";
    function divisionBy3(value) {
        var sum,
            i,
            len;
        if (isNaN(value) || value < 10) {
            return;
        }

        value = value.toString();
        sum = '';
        len = value.length;
        for (i=0; i<len; i+=1){
            sum += +value[i];
            // the'+' sign before value[i] converts string back to number, it is not necessary,
            // because '%' below also converts the string back to number if it is not number
        }

        if (sum % 3 === 0) {
            return "the number is divided by 3 without remainder";
        }

        return "the number is not divided by 3 without remainder";
    }

    var firstNumber = 13,
        secondNumber = 189,
        thirdNumber = 591;

    console.log(divisionBy3(firstNumber));
    console.log(divisionBy3(secondNumber));
    console.log(divisionBy3(thirdNumber));
}());