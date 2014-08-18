// Task 07: Write a JavaScript function calcSupply(value) that accepts the following parameters: your age,
//          your maximum age, estimate amount of your favorite food per day (as a number). The function
//          calculates how many of the food you will eat for the rest of your life. Write JS program
//          lifetimeSupplyCalc.js that calculates the amount of a few foods that you will eat.
//          The result should be printed on the console. Run the program through Node.js. Note: we assume
//          that there are no leap years.

(function () {
    "use strict";
    function Person(age, maxAge, favoriteFood, amountPerDayEaten) {

        this.age = age;
        this.maxAge = maxAge;
        this.food = {
            name: favoriteFood,
            dailyQuota: amountPerDayEaten
        };
    }

    function calcSupply(age, maxAge, nameOfTheFood, amountOfFoodPerDay) {
        var totalFood;
        age = age || 0;
        maxAge = maxAge || 0;
        amountOfFoodPerDay = amountOfFoodPerDay || 0;
        if (isNaN(age) || isNaN(maxAge) || isNaN(amountOfFoodPerDay) ||
            (age * maxAge * amountOfFoodPerDay) === 0) {
            throw 'Invalid data provided!';
        }

        totalFood = ( maxAge - age) * 365 * amountOfFoodPerDay;
        return  totalFood + 'kg of ' + nameOfTheFood + ' would be enough until I am ' + maxAge + ' years old.';
    }

    var personOne = new Person(38, 118, 'chocolate', 0.5),
        personTwo = new Person(20, 87, 'fruits', 2),
        personThree = new Person(16, 102, 'nuts', 1.1);

    console.log(calcSupply(personOne.age, personOne.maxAge, personOne.food.name, personOne.food.dailyQuota));
    console.log(calcSupply(personTwo.age, personTwo.maxAge, personTwo.food.name, personTwo.food.dailyQuota));
    console.log(calcSupply(personThree.age, personThree.maxAge, personThree.food.name, personThree.food.dailyQuota));
}());