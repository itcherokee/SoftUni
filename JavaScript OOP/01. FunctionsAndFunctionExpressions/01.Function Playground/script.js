/*
 Create a function with no parameters. Perform the following operations:
 •	The function should print the number of its arguments and each of the arguments' type.
 o	Call the function with different number and type of arguments.
 •	The function should print the this object. Compare the results when calling the function from:
 o	Global scope
 o	Function scope
 o	Over the object
 o	Use call and apply to call the function with parameters and without parameters
 */

function parameters() {
    "use strict";
    var parametersCount = arguments.length,
        elements = [],
        self = this,
        index;

    var toString = function(){
      return  self;
    };

    for (index = 0; index < parametersCount; index += 1) {
        elements.push(arguments[index] + ' - ' + typeof arguments[index]);
    }

    return 'Elements count = ' + parametersCount + '\nElements:\n' + elements.join('\n');
}

//console.log(parameters(1, 2, 3, "34", "dsdsd", function(){}, new Number("1234"), new Object()));
var func =
console.log(parameters());
//console.log(parameters.toString());

