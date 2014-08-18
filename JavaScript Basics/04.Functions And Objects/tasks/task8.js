// Task 8*: Write a JavaScript function sumTwoHugeNumbers(value)
//          that accepts as parameter an array of the two numbers
//          for summing. The input numbers are represented as strings.
//
//  Note:   Decided not to use external library. For the moment works
//          only with positive numbers.

var taskEight = function () {
    "use strict";
    var firstBigNumber,
        secondBigNumber;

    var sumTwoHugeNumbers = function (numbers) {
        var carryOver,
            result,
            digitSum,
            digitOne,
            digitTwo,
            numOneLength,
            numTwoLength,
            longest,
            index;

        if (numbers instanceof Array && numbers.length === 2 &&
                typeof numbers[0] === 'string' && typeof numbers[1] === 'string') {
            numbers[0] = numbers[0] || '0';
            numbers[1] = numbers[1] || '0';
            numOneLength = numbers[0].length - 1;
            numTwoLength = numbers[1].length - 1;
            longest = numOneLength >= numTwoLength ? numOneLength : numTwoLength;

            index = 0;
            carryOver = 0;
            result = '';
            while (longest > -1) {
                digitOne = +numbers[0][numOneLength - index] || 0;
                digitTwo = +numbers[1][numTwoLength - index] || 0;
                digitSum = digitOne + digitTwo + carryOver;
                if (digitSum > 9) {
                    carryOver = Math.floor(digitSum / 10);
                    digitSum = digitSum % 10;
                } else {
                    carryOver = 0;
                }

                result = digitSum + result;
                index += 1;
                longest -= 1;
            }

        }

        return result;
    };

    firstBigNumber = prompt('Enter first BIG number');
    secondBigNumber = prompt('Enter second BIG number');
    return sumTwoHugeNumbers([firstBigNumber, secondBigNumber]);
};