// Task 12: Write a JavaScript function variablesTypes(value) that accepts the following parameters:
//          name, age, isMale (true or false), array of your favorite foods. The function must return
//          the values of the variables and their types.

(function () {
    "use strict";
    function variablesTypes(value) {
        var name,
            age,
            isMale,
            foods;
        name = 'My name: ' + value[0] + ' // type is ' + typeof value[0];
        age = '\nMy age: ' + value[1] + ' // type is ' + typeof value[1];
        isMale = '\nI am male: ' + value[2] + ' // type is ' + typeof value[2];
        foods = '\nMy favorite foods are: '+ value[3] + ' // type is ' + typeof value[3];
        return name + age + isMale + foods;
    }

    var input = ['Pesho', 22, true, ['fries', 'banana', 'cake']];

    console.log(variablesTypes(input));
}());