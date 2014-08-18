// Task 17: Write a JavaScript function extractContent(value) that
//          extracts the text content from given HTML fragment
//          (given as string). The function should return anything
//          that is in a tag, without the tags.

var taskSeventeen = function () {
    "use strict";
    var input;

    var extractContent = function (htmlFragment) {
        var text,
            result,
            index,
            len,
            textNode;

        // text = htmlFragment.match(/[^>]+.*?[<$]+/g);
        // text = htmlFragment.match(/>([^<]+)</g);
        // text = htmlFragment.match(/(?:>)\w+(?=<\/)/g);

        text = htmlFragment.match(/>([^</]+)</g);
        result = [];
        for (index = 0 , len = text.length; index < len; index += 1) {
            textNode = text[index];
            if (textNode.match(/\t+/g)) {
                continue;
            }

            result.push(textNode.slice(1, textNode.length - 1));
        }

        return result.join('');
    };

    input = prompt('Enter HTML fragment');
    return extractContent(input);
};