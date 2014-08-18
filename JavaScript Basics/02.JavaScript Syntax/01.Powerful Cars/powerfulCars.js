// Task 01: Write a JavaScript function convertKWtoHP(value) to convert car’s kW into hp (horse power).
//          Write a JS program powerfulCars.js that converts a few sample values to hp (see the examples below).
//          The result should be printed on the console, rounded up to the second sign after the decimal point.
//          Run the program through Node.js.
//
//  Note:   In Homework examples is used Electrical horsepower, which is still rare, so I assume is a mistake,
//          but you can still test it by providing second argument as a string "electrical" to function call.

(function () {
    "use strict";
    function convertKWtoHP(kiloWats, horsePowerType) {

        horsePowerType = horsePowerType || "metric";
        kiloWats = kiloWats || 0;
        var multiplier = 0,
            hpType = {
                mechanical: 0.745699872,
                electrical: 0.745699872,  // this one is used for electrical cars and represent the output that engine provides
                metric: 0.745699872  // this one is used by internal-combustion engine manufacturers in Europe & Japan
            };
        switch (horsePowerType) {
            case "electrical":
                multiplier = hpType.electrical;
                break;
            case "mechanical":
                multiplier = hpType.mechanical;
                break;
            case "metric":
                multiplier = hpType.metric;
                break;
        }

        return (kiloWats / multiplier);
    }

    var firstKwValue = 75,
        secondKwValue = 150,
        thirdKwValue = 1000,
        hpType = "metric";

    console.log(firstKwValue + 'kW is equal to ' + convertKWtoHP(firstKwValue, hpType).toFixed(2) + ' horse powers (' + hpType + ').');
    console.log(secondKwValue + 'kW is equal to ' + convertKWtoHP(secondKwValue, hpType).toFixed(2) + ' horse powers (' + hpType + ').');
    console.log(thirdKwValue + 'kW is equal to ' + convertKWtoHP(thirdKwValue, hpType).toFixed(2) + ' horse powers (' + hpType + ').');
}());