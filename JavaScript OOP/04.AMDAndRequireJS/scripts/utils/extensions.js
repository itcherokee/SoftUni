define(function () {
    'use strict';

    Object.prototype.inherits = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    return{
        createInput: function (placeholder) {
            var input = document.createElement('input');
            input.type = 'text';
            input.placeholder = placeholder;
            return input;
        },

        createButton: function (value) {
            var button = document.createElement('input');
            button.type = 'button';
            button.value = value;
            return button;
        },

        setTitle: function (title) {
            if (!title) {
                throw Error("Invalid text content provided");
            }

            return title;
        }
    };
});






