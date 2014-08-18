// Task 13: Write a JavaScript function soothsayer(value) that accepts the following parameters (source arrays):
//          array of numbers, array of programming languages, array of cities, array of cars. Each array must
//          consist of five elements. The function must return an array result[] that consists of one random
//          item from each source array. Write a JS program that prints on the console the following output:
//          “You will work result[0] years on result[1]. You will live in result[2] and drive result[3].”.
//          Run the program through Node.js.

(function () {
    "use strict";
    function soothsayer() {
        var result,
            years,
            languages,
            cities,
            cars,
            input,
            message;

        function selectIndex() {
            return Math.floor(Math.random() * 5);
        }

        message = 'Too few arguments provided';
        input = Array.prototype.slice.call(arguments);
        if (input.length < 1) {
            throw message;
        }

        years = input[0][0];
        if (years.length < 5) {
            throw message + ' years!';
        }

        languages = input[0][1];
        if (languages.length < 5) {
            throw message + ' languages!';
        }

        cities = input[0][2];
        if (cities.length < 5) {
            throw message + ' city!';
        }

        cars = input[0][3];
        if (cars.length < 5) {
            throw message + ' cars!';
        }

        result = [];
        result.push(years[selectIndex()], languages[selectIndex()], cities[selectIndex()], cars[selectIndex()]);

        return 'You will work ' + result[0] + ' years on ' + result[1] + '. You will live in ' +
            result[2] + ' and drive ' + result[3] + '.';
    }

    var input = [[3, 5, 2, 7, 9],
        ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'],
        ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'],
        ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']];

    console.log(soothsayer(input));
}());