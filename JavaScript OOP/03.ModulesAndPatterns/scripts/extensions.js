'use strict';

function createInput(placeholder) {
    var input = document.createElement('input');
    input.type = 'text';
    input.placeholder = placeholder;
    return input;
}

function createButton(value) {
    var button = document.createElement('input');
    button.type = 'button';
    button.value = value;
    return button;
}

Object.prototype.inherits = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

function setTitle(title) {
    if (!title) {
        throw Error("Invalid text content provided");
    }

    return title;
}




