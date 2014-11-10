///*
// Problem 3.	DOM Manipulation
// Create an IIFE module for working with the DOM tree. The module should support the following operations:
// •	Adding а DOM element to a parent element specified by selector
// •	Removing a child element from a parent specified by selector
// •	Attaching an event to a given selector by given event type and event hander
// •	Retrieving elements by a given CSS selector
// The module should reveal only its methods (i.e. everything else should be encapsulated).
// */

var domModule = function domModule() {
    "use strict";

    function appendChild(element, selector){
        var elements;

        if (selector && element instanceof Node) {
            elements = retrieveElements(selector);
            if (elements) {
                Array.prototype.forEach.call(elements, function (tag) {
                    tag.appendChild(element);
                })
            }
        }
    }

    function removeChild(parentSelector, childToRemoveSelector){
        var parentElements,
            childElement;

        if (parentSelector && childToRemoveSelector) {
            parentElements = retrieveElements(parentSelector);
            if (parentElements) {
                Array.prototype.forEach.call(parentElements, function (parent) {
                    childElement = parent.querySelector(childToRemoveSelector);
                    parent.removeChild(childElement);
                })
            }
        }
    }

    function addHandler(selector, event, handlerFunc) {
        var elements;

        if (selector && event && handlerFunc) {
            elements = retrieveElements(selector);
            if (elements) {
                Array.prototype.forEach.call(elements, function (element) {
                    element.addEventListener(event, handlerFunc);
                });
            }
        }
    }

    function retrieveElements(selector) {
        var selectorToBeUsed = (selector || '').trim();

        if (selectorToBeUsed) {
            return document.querySelectorAll(selectorToBeUsed);
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    }
}();


var liElement = document.createElement("li");
liElement.innerText = "new bird";
// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");
// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");
// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function() {alert("I'm a bird!")});
// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
console.log(elements);