var todo = todo || {};
(function (scope) {
    function DomElement(title) {
        this._title = setTitle(title);
    }

    DomElement.prototype.toString = function () {
        return this._title;
    };

    scope.DomElement = DomElement;
}(todo));
