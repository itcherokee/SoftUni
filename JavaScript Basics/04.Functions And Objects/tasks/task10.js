// Task 10*: Write a JavaScript function clone(obj) that accept as parameter
//           an object of reference type.  The function should return a deep
//           copy of the object. Write a second function
//           compareObjects(obj, objCopy) that compare the two objects by
//           reference (==) and print on the console the output given below.

var taskTen = function () {
    "use strict";
    var output,
        parent,
        child;

    var clone = function (obj) {
        var copy = obj instanceof Array? [] : {},
            key;

        for (key in obj) {
            if (obj.hasOwnProperty(key)) {
                if (typeof obj[key] === 'object') {
                    if (obj[key] instanceof Array) {
                        copy[key] = [];
                    } else {
                        copy[key] = {};
                    }

                    copy[key] = clone(obj[key]);
                } else {
                    copy[key] = obj[key];
                }
            }
        }

        return copy;
    };

    var compareObjects = function (obj, objCopy) {
        return obj == objCopy;
    };

    parent = {
        name: 'Pesho',
        age: 21,
        marks:[6,5,4],
        info: {hair: 'blond'},
        say : function(){return "I'm " + this.name}
    };

    child = clone(parent); // a deep copy
    output = 'Initial object: ' + JSON.stringify(parent) +
        '<br/><br/>Operation: child = clone(parent)<br/>"parent" == "child" --&gt; ' +
        compareObjects(parent, child);

    child = parent; // not a deep copy
    output += '<br/>Operation: child = parent<br/>"parent" == "child" --&gt; ' +
        compareObjects(parent, child);

    return output;
};