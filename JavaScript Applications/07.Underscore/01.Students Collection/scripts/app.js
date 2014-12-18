// Task 1:  Using Underscore.js, perform the following operations on the student collection given below:
//          • Get all students with age between 18 and 24
//          • Get all students whose first name is alphabetically before their last name
//          • Get only the names of all students from Bulgaria
//          • Get the last five students
//          • Get the first three students who are not from Bulgaria and are male

$(function () {
    var students = [
            {"gender": "Male", "firstName": "Joe", "lastName": "Riley", "age": 22, "country": "Russia"},
            {"gender": "Female", "firstName": "Lois", "lastName": "Morgan", "age": 41, "country": "Bulgaria"},
            {"gender": "Male", "firstName": "Roy", "lastName": "Wood", "age": 33, "country": "Russia"},
            {"gender": "Female", "firstName": "Diana", "lastName": "Freeman", "age": 40, "country": "Argentina"},
            {"gender": "Female", "firstName": "Bonnie", "lastName": "Hunter", "age": 23, "country": "Bulgaria"},
            {"gender": "Male", "firstName": "Joe", "lastName": "Young", "age": 16, "country": "Bulgaria"},
            {"gender": "Female", "firstName": "Kathryn", "lastName": "Murray", "age": 22, "country": "Indonesia"},
            {"gender": "Male", "firstName": "Dennis", "lastName": "Woods", "age": 37, "country": "Bulgaria"},
            {"gender": "Male", "firstName": "Billy", "lastName": "Patterson", "age": 24, "country": "Bulgaria"},
            {"gender": "Male", "firstName": "Willie", "lastName": "Gray", "age": 42, "country": "China"},
            {"gender": "Male", "firstName": "Justin", "lastName": "Lawson", "age": 38, "country": "Bulgaria"},
            {"gender": "Male", "firstName": "Ryan", "lastName": "Foster", "age": 24, "country": "Indonesia"},
            {"gender": "Male", "firstName": "Eugene", "lastName": "Morris", "age": 37, "country": "Bulgaria"},
            {"gender": "Male", "firstName": "Eugene", "lastName": "Rivera", "age": 45, "country": "Philippines"},
            {"gender": "Female", "firstName": "Kathleen", "lastName": "Hunter", "age": 28, "country": "Bulgaria"}
        ],
        template = '<li>' +
            '<strong>Name:</strong> {{firstName}} {{lastName}}, <strong>Gender:</strong> {{gender}}, ' +
            '<strong>Age:</strong> {{age}}, <strong>Country:</strong> {{country}}' +
            '</li>';

    var ageBetween,
        firstAlphabetical,
        fromBulgaria,
        firstThree;

    function show(selector, data) {
        _.each(data, function (person) {
            selector.append(Mustache.render(template, person));
        });
    }

    // Get all students with age between 18 and 24
    ageBetween = _.filter(students, function (student) {
        return student.age >= 18 && student.age <= 24;
    });
    show($('#age-between'), ageBetween);

    // Get all students whose first name is alphabetically before their last name
    firstAlphabetical = _.filter(students, function (student) {
        return student.firstName < student.lastName;
    });
    show($('#name-alphabetically'), firstAlphabetical);

    // Get only the names of all students from Bulgaria
    fromBulgaria = _.where(students, {country: 'Bulgaria'});
    show($('#names-bulgaria'), fromBulgaria);

    // Get the last five students
    show($('#last-five'), _.last(students, 5));

    // Get the first three students who are not from Bulgaria and are male
    firstThree = _.first(_.reject(_.where(students, {gender: 'Male'}), function (person) {
        return person.country === 'Bulgaria';
    }), 3);
    show($('#first-male-not-bg'), firstThree);
});