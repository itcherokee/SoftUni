// Task 7:  Write a JavaScript function findYoungestPerson(persons)
//          that accepts as parameter an array of persons, finds
//          the youngest person and returns his full name.

var taskSeven = function () {
    "use strict";
    var persons;

    var findYoungestPerson = function (people) {
        var yongestPerson = '',
            age;

        if (people instanceof Array){
            age = Number.MAX_VALUE;
            people.forEach(function(el, index, arr){
                if (age > el.age){
                    age = el.age;
                    yongestPerson = el.firstname + ' ' + el.lastname;
                }
            })
        }

        return 'The youngest person is ' + yongestPerson;
    };

    persons = [
        { firstname: 'George', lastname: 'Kolev', age: 32},
        { firstname: 'Bay', lastname: 'Ivan', age: 81},
        { firstname: 'Baba', lastname: 'Ginka', age: 40}
    ];

    return 'Initial data: <br/>' + JSON.stringify(persons) +
        '<br/>Result: <br/>' + findYoungestPerson(persons);
};