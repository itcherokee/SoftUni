var todo = todo || {};
(function (scope) {
    function Item(content) {
        scope.DomElement.call(this, content);
    }

    Item.prototype = Object.create(scope.DomElement.prototype);
    Item.prototype.constructor = Item;

    Item.prototype.addToDom = function (parent) {
        var item,
            checkbox,
            itemSpan;

        item = document.createElement('li');
        checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        itemSpan = document.createElement('span');
        itemSpan.appendChild(document.createTextNode(this.toString()));
        checkbox.addEventListener('change', function () {
            if (checkbox.checked) {
                itemSpan.className = 'checked';
            } else {
                itemSpan.className = '';
            }
        });
        item.appendChild(checkbox);
        item.appendChild(itemSpan);
        parent.appendChild(item);
    };

   scope.Item = Item;
}(todo));