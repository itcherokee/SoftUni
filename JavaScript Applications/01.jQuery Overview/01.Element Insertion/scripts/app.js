// Task 1:  Using jQuery write a script for adding elements before/after other elements.

(function () {
    function addToDom(source, sibbling, position) {
        var whereToAppend = $.inArray(position,['before', 'after']) > -1 ? position : 'after',
            sourceElement,
            siblingElement;

        function convertToJquery(item) {
            if (item.nodeType) {
                return $(item);
            } else if (item.jquery) {
                return item;
            } else {
                throw new Error('None or not a DOM or jQuery object provided');
            }
        }

        sourceElement = convertToJquery(source);
        if (sourceElement !== $(document.body) &&
            sourceElement !== $(document) && sourceElement !== $(document.head)) {
            siblingElement = convertToJquery(sibbling);
            switch (whereToAppend) {
                case 'after':
                    siblingElement.insertAfter(sourceElement);
                    break;
                case 'before':
                    siblingElement.insertBefore(sourceElement);
                    break;
                default:
                    throw new Error('Invalid position specified for insertion of new DOM element.');
                    break;
            }
        } else {
            throw new Error('Invalid source has been specified.');
        }
    }

    $(function () {
        var DIV = {text: 'I am a DIV'},
            HEADING = {text: 'I am a beatiful paragraph'},
            BUTTON = {text: 'The best ever button'},
            paragraph = $('p');

        $('button').on('click', function () {
            var whereToPlaceIt = $('#where').val(),
                elementType = $('#element').val();

            switch (elementType) {
                case 'div':
                    addToDom(paragraph, $('<div>', DIV), whereToPlaceIt);
                    break;
                case 'h1':
                    addToDom(document.getElementsByTagName('p')[0], $('<h1>', HEADING), whereToPlaceIt);
                    break;
                case 'button':
                    addToDom(paragraph, $('<button>', BUTTON), whereToPlaceIt);
                    break;
                default :
                    throw new Error('Invalid element specified.');
                    break;
            }
        });
    })
}());