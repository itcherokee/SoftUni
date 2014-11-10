define(['domElement', 'item', 'extensions'], function (DomElement, Item, extensions) {
    var Section = (function () {
        function Section(title) {
            DomElement.call(this, title);
        }

        Section.inherits(DomElement);
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

            input = extensions.createInput('Add item...');
            section.appendChild(input);

            button = extensions.createButton('+');
            button.addEventListener('click', function () {
                var task = input.value;
                var newItem = new Item(task);
                newItem.addToDom(list);
                input.value = '';
            });

            section.appendChild(button);
            parent.appendChild(section);
        };

        return Section;
    }());

    return Section;
});
