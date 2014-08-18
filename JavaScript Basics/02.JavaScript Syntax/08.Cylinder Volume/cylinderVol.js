// Task 08: Write a JavaScript function calcCylinderVol(value) that accepts the following parameters: radius and
//          the height of a straight circular cylinder. The function calculates the volume of the cylinder.
//          Write JS program cylinderVol.js that calculates the volume of a few cylinders. The result should be
//          printed on the console. Run the program through Node.js

(function () {
    "use strict";
    function Cylinder(radius, height) {
        this.radius = radius;
        this.height = height;
    }

    function calcCylinderVol(radius, height) {
        return Math.PI * radius * radius * height;
    }

    var cylinderOne = new Cylinder(2, 4),
        cylinderTwo = new Cylinder(5, 8),
        cylinderThree = new Cylinder(12, 3);

    console.log(calcCylinderVol(cylinderOne.radius, cylinderOne.height).toFixed(3));
    console.log(calcCylinderVol(cylinderTwo.radius, cylinderTwo.height).toFixed(3));
    console.log(calcCylinderVol(cylinderThree.radius, cylinderThree.height).toFixed(3));
}());