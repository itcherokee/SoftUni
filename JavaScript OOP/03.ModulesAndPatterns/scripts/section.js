var todo = todo || {};
(function (scope) {
    function Section(title) {
        scope.DomElement.call(this, title);
    }

    Section.inherits(scope.DomElement);
    Section.prototype.addToDom = function (parent) {
        var section,
            content,
            title,
            list,
            input,
            button;

        section = document.createElement('article');
        section.id = 'section';
        content = document.createElement('div');
        title = document.createElement('h2');
        title.innerHTML = this.toString();
        content.appendChild(title);
        list = document.createElement('ul');
        content.appendChild(list);
        section.appendChild(content);

        input = createInput('Add item...');
        section.appendChild(input);

        button = createButton('+');
        button.addEventListener('click', function () {
            var task = input.value;
            var newItem = new todo.Item(task);
            newItem.addToDom(list);
            input.value = '';
        });

        section.appendChild(button);
        parent.appendChild(section);
    };

    scope.Section = Section;
}(todo));