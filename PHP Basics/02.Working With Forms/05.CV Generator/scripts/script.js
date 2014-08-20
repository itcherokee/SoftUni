(function () {
    "use strict";
    var languagesId = 0,
        skillsId = 0,
        skillsDiv = document.getElementById('other-skills'),
        programmingDiv = document.getElementById('programming-languages');

    function createSelect(name, source) {
        var item = document.createDocumentFragment(),
            select = document.createElement('select'),
            values = source.slice(),
            element,
            i;

        values.unshift(name);
        select.setAttribute("name", name + '[]');
        for (i = 0; i < 4; i += 1) {
            element = document.createElement('option');
            element.setAttribute("value", values[i]);
            if (i === 0) {
                element.text = '-' + (values[i][0]).toUpperCase() + values[i].slice(1) + '-';
                element.setAttribute("hidden", "hidden");
                element.setAttribute("value", "n/a");
            } else {
                element.text = values[i];
            }

            select.appendChild(element);
        }

        item.appendChild(select);
        return item;
    }

    function createInput(name) {
        var item = document.createDocumentFragment(),
            inpt = document.createElement('input');

        inpt.setAttribute("name", name + '[]');
        inpt.setAttribute("type", "text");
        item.appendChild(inpt);
        return item;
    }

    function createOtherSkill() {
        var item = document.createDocumentFragment(),
            source = ['beginner', 'intermediate', 'advanced'],
            selects = ['comprehension', 'reading', 'writing'],
            div = document.createElement('div'),
            i;

        item.appendChild(div);
        div.appendChild(createInput("skill"));
        for (i = 0; i < 3; i += 1) {
            div.appendChild(createSelect(selects[i], source));
        }

        return item;
    }

    function createProgrammingLanguage() {
        var item = document.createDocumentFragment(),
            div = document.createElement('div'),
            source = ['Beginner', 'Programmer', 'Ninja'];

        item.appendChild(div);
        div.appendChild(createInput("programming"));
        div.appendChild(createSelect("level", source));
        return item;
    }

    document.getElementById('add-programming').addEventListener('click', function () {
        programmingDiv.appendChild(createProgrammingLanguage());
    });

    document.getElementById('remove-programming').addEventListener('click', function () {
        programmingDiv.removeChild(programmingDiv.lastChild);
    });

    document.getElementById('add-skill').addEventListener('click', function () {
        skillsDiv.appendChild(createOtherSkill());
    });

    document.getElementById('remove-skill').addEventListener('click', function () {
        skillsDiv.removeChild(skillsDiv.lastChild);
    });

    programmingDiv.appendChild(createProgrammingLanguage());
    skillsDiv.appendChild(createOtherSkill());
}());