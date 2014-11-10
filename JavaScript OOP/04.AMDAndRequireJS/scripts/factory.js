define(['container', 'section', 'item'], function (Container, Section, Item) {
    var Factory = (function () {
        var moduleLoaded;
        function Factory(module, text) {
            switch (module) {
                case 'container' :
                    moduleLoaded = new Container(text);
                    moduleLoaded.addToDom(document.body);
                    break;
                case 'section':
                    moduleLoaded = new Section(text);
                    break;
                case 'item':
                    moduleLoaded = new Item(text);
                    break;
                default:
                    throw new Error("Undefined module provided.");
            }
        }

        return Factory;
    }());

    return Factory;
});