// Task 2:  You are given a HTML file holding several <div> elements. Write a JavaScript
//          code to print the text content of all <div> elements as unordered list.

(function () {
    "use strict";
    var result = document.getElementById('result');

    function extractText(node) {
        var container = document.createDocumentFragment(),
            item,
            li;
        for (item in node) {
            if (node.hasOwnProperty(item)) {
                // if you want to exclude empty divs from UL - uncomment the fragment in "if" condition
                if (node[item].nodeName === 'DIV' /* && node[item].childNodes.length */) {
                    li = document.createElement('LI');
                    li.innerHTML = node[item].innerText.replace(/[\r\n]+/g, '<br/>');
                    container.appendChild(li);
                }
            }
        }

        return container;
    }

    result.appendChild(extractText(document.body.childNodes));
}());