///*
// Problem 2.	DOM Traversal
// You are given an HTML file. Write a function that traverses all child elements of an element
// by a given CSS selector and prints all found elements in the format:
// <Element name>: id="<id>", class="<class>"
// Print each element on a new line. Indent child elements.
// */

var traverse = function traverse(selector) {
    "use strict";
    var root = document.querySelector(selector);
    if (root !== "undefined" && root.hasChildNodes()) {
        traverseChild(root, '');
    }

    function traverseChild(currentNode, spacing) {
        var idAttr = currentNode.getAttribute('id'),
            classAttr = currentNode.getAttribute('class'),
            idValue = idAttr ? ' id="' + idAttr + '"' : '',
            classValue = classAttr ? ' class="' + classAttr + '"' : '';

        console.log(spacing + currentNode.nodeName.toLowerCase() + ':' + idValue + classValue);

        if (currentNode.hasChildNodes()) {
            Array.prototype.forEach.call(currentNode.childNodes, function (child) {
                if (child.nodeType === currentNode.ELEMENT_NODE) {
                    traverseChild(child, spacing + "    ");
                }
            });
        }
    }
};

var selector = ".birds";
traverse(selector);
