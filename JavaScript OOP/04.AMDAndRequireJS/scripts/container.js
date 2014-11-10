define(['extensions', 'section', 'domElement'], function (extensions, Section, DomElement ) {
    var Container = (function () {
        function Container(title) {
            DomElement.call(this, title);
        }

        Container.inherits(DomElement);
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

            input = extensions.createInput('Title...');
            container.appendChild(input);

            button = extensions.createButton('New Section');
            button.addEventListener('click', function () {
                var title = input.value;
                var newSection = new Section(title);
                newSection.addToDom(content);
                input.value = '';

            });
            container.appendChild(button);
            parent.appendChild(container);
        };

        Container.prototype.toString = function () {
            return this._title + ' <span style="font-style: italic;">TODO</span> List';
        };

        return Container;
    }());

    return Container;
});