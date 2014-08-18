// Task 3:  Write a JavaScript function findLargestBySumOfDigits(nums) that
//          takes as an input a sequence of positive integer numbers and returns
//          the element with the largest sum of its digits. The function should
//          take a variable number of arguments. It should return undefined
//          when 0 arguments are passed or when some of the arguments is not
//          an integer number.

var taskThree = function () {
    "use strict";
    var input;

    var findLargestBySumOfDigits = function () {
        var error = 'undefined',
            maxNumber = error,
            numbers,
            len,
            index,
            maxSum,
            currentNumber,
            currentNumberLength,
            sum,
            digitIndex;


        if (arguments.length > 0) {
            numbers = Array.prototype.slice.apply(arguments);
            maxSum = 0;
            len = numbers.length;
            for (index = 0; index < len; index +=1){
                sum = 0;
                currentNumber = +numbers[index];
                if (currentNumber % 1 !== 0){
                    return error;
                }

                if (currentNumber < 0) {
                    currentNumber *= -1;
                }

                currentNumberLength =  Math.ceil(Math.log(currentNumber + 1) / Math.LN10);
                for (digitIndex = 0; digitIndex < currentNumberLength; digitIndex+=1){
                    sum += currentNumber % 10;
                    if(currentNumber < 10){
                        continue;
                    }

                    currentNumber /= 10;
                }

                // sum = (currentNumber % 9 == 0 && currentNumber !== 0) ? 9 : currentNumber % 9;
                if (sum > maxSum) {
                    maxNumber = +numbers[index];
                    maxSum = sum;
                }
            }
        }

        return maxNumber;
    };

    input = prompt("Enter numbers separated by comma").split(/[\s*,*]+/);
    return findLargestBySumOfDigits.apply(this, input);
};