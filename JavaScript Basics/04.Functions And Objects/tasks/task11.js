// Task 11***: Write a JavaScript function group(persons) that groups an array of
//             persons by age, first or last name. Create a Person constructor
//             to add every person in the person array. The group(persons)
//             function must return an associative array, with keys – the groups
//             (age, firstName and lastName) and values – arrays with persons in
//             this group. Print on the console every entry of the returned
//             associative array. Use function overloading (i.e. just one function).
//              You may need to find how to use constructors.

var taskEleven = function () {
    "use strict";
    var persons;

    var group = function (persons, groupBy) {
        var result = {},
            key = '';

        persons.forEach(function (currentElement) {
            switch(groupBy){
                case 'age':
                        key = currentElement.age;
                    break;
                case 'firstname':
                        key = currentElement.firstname;
                    break;
                case 'lastname':
                        key = currentElement.lastname;
                    break;
            }

            if (!result[key]) {
                result[key] = [];
            }

            result[key].push(currentElement);
        });

        return result;
    };

    var Person = function (firstname, lastname, age) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
    };

    Person.prototype.toString = function () {
        return this.firstname + ' ' + this.lastname + '(age ' + this.age + ')';
    };

    var format = function (groupedPersons) {
        var result = '',
            key;

        if (groupedPersons) {
            for (key in groupedPersons) {
                if (groupedPersons.hasOwnProperty(key)) {
                    result += 'Group ' + key + ' : [' + groupedPersons[key].map(function (el) {
                        return el.toString();
                    }).join(', ') + ']<br/>';
                }
            }
        } else {
            result = 'undefined';
        }

        return result;
    };

    persons = [];
    persons.push(new Person("Scott", "Guthrie", 38));
    persons.push(new Person("Scott", "Johns", 36));
    persons.push(new Person("Scott", "Hanselman", 39));
    persons.push(new Person("Jesse", "Liberty", 57));
    persons.push(new Person("Jon", "Skeet", 38));

    return 'By "firstname": <br/>' + format(group(persons, 'firstname')) +
        '<br/>By "age": <br/>' + format(group(persons, 'age')) +
        '<br/>By "lastname": <br/>' + format(group(persons, 'lastname'));
};