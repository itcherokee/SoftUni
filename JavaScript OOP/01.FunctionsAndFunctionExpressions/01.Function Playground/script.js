/*
 Problem 1.	Function Playground
 Create a function with no parameters. Perform the following operations:
 •	The function should print the number of its arguments and each of the arguments' type.
 -	Call the function with different number and type of arguments.
 •	The function should print the this object. Compare the results when calling the function from:
 -	Global scope
 -	Function scope
 -	Over the object
 -	Use call and apply to call the function with parameters and without parameters*/

function parameters() {
    "use strict";
    var parametersCount = arguments.length,
        args = Array.prototype.slice.call(arguments),
        elements = [],
        output;

    args.forEach(function (element) {
        elements.push(element + ' - ' + typeof element);
    });

    output = 'Elements count = ' + parametersCount;
    if (elements.length) {
        output += '\nElements:\n' + elements.join('\n');
    }

    return output;
}

var values = [1, 2, 3, "34", "Nakov", function () {
}, new Number("1234"), {}];

console.log(parameters());
console.log();
console.log(parameters.apply(null, values));
console.log();
console.log(parameters.call(null, {}, 12));
console.log();
values.forEach(function (item) {
    console.log(parameters(item));
});
