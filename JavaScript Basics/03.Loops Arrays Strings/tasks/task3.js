// Task 3:  Write a JavaScript function displayProperties(value) that
//          displays all the properties of the "document" object in
//          alphabetical order.

var taskThree = function () {
    "use strict";

    var displayProperties = function () {
        var result,
            property;

        result = [];
        for (property in document) {
            if(document.hasOwnProperty(property)){
                result.push(property);
            }
        }

        result.sort(function(a,b){
            return a.toLowerCase().localeCompare(b.toLowerCase());
        });

        return result.join("<br />");
    };

    return displayProperties();
};