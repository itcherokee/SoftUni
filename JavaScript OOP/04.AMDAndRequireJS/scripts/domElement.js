define(['extensions'],function (extensions) {
    var DomElement = (function () {
        function DomElement(title) {
            this._title = extensions.setTitle(title);
        }

        DomElement.prototype.toString = function () {
            return this._title;
        };

        return DomElement;
    }());

    return DomElement;
});