var todo = todo || {};
(function (scope) {
    function Container(title) {
        scope.DomElement.call(this, title);
    }

    Container.inherits(scope.DomElement);
    Container.prototype.addToDom = function (parent) {
        var container,
            content,
            title,
            input,
            button;

        container = document.createElement('main');
        container.id = 'container';
        title = document.createElement('h1');
        title.innerHTML = this.toString();
        container.appendChild(title);
        content = document.createElement('section');
        container.appendChild(content);

        input = createInput('Title...');
        container.appendChild(input);

        button = createButton('New Section');
        button.addEventListener('click', function () {
            var title = input.value;
            var newSection = new todo.Section(title);
            newSection.addToDom(content);
            input.value = '';

        });
        container.appendChild(button);
        parent.appendChild(container);
    };

    Container.prototype.toString = function () {
        return this._title + ' <span style="font-style: italic;">TODO</span> List';
    };

    scope.Container = Container;
}(todo));