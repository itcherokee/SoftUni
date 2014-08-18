// Task 09: Write a JavaScript function treeHouseCompare(value) that accepts the following parameters:
//          integers a and b. The function compares the area of the house and the area of the tree (Figure 1)
//          and returns the name of the figure with bigger area (house or tree) and the value of the area.
//          Write JS program treehouse.js that compares a few houses and trees. The result should be printed
//          on the console. Run the program through Node.js

(function () {
    "use strict";
    function treeHouseCompare(a, b) {
        var houseArea,
            treeArea;

        if (isNaN(a) || !isFinite(a)  || a <= 0 || isNaN(b) || !isFinite(b)  || b <= 0) {
            return;
        }

        function calcHouse(value) {
            var body,
                roof;
            body = value * value;
            roof = (value * (value / 3 * 2)) / 2;
            return body + roof;
        }

        function calcTree(value) {
            var crown,
                trunk,
                measure;
            measure = value / 3;
            crown = Math.PI * Math.pow(measure * 2, 2);
            trunk = measure * value;
            return crown + trunk;
        }

        houseArea = calcHouse(a);
        treeArea = calcTree(b);
        return houseArea > treeArea ? 'house/' + houseArea.toFixed(2) : houseArea === treeArea ? 'equal/' + houseArea.toFixed(2) : 'tree/' + treeArea.toFixed(2);
    }

    console.log(treeHouseCompare(3, 2));
    console.log(treeHouseCompare(3, 3));
    console.log(treeHouseCompare(4, 5));
}());