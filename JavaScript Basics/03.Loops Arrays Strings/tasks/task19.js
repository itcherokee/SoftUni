// Task 19: Write a JavaScript function fixCasing(value) that accepts
//          a text as a parameter. The function must change the text
//          in all regions as follows:
//              o	<upcase>text</upcase> to uppercase
//              o	<lowcase>text</lowcase> to lowercase
//              o	<mixcase>text</mixcase> to mixed casing (randomly)

var taskNineteen = function () {
    "use strict";

    String.prototype.htmlEscape = function () {
        var escapedStr = String(this).replace(/&/g, '&amp;');
        escapedStr = escapedStr.replace(/</g, '&lt;');
        escapedStr = escapedStr.replace(/>/g, '&gt;');
        escapedStr = escapedStr.replace(/"/g, '&quot;');
        escapedStr = escapedStr.replace(/'/g, "&#39");
        return escapedStr;
    };

    String.prototype.fixCasing = function () {
        var text = this.valueOf(),
            position = 0;

        while (position < text.length) {
            var openingTagStart = text.indexOf('<', position);
            if (openingTagStart === -1) {
                break;
            }

            var openingTagEnd = text.indexOf('>', position);
            var tagName = text.slice(openingTagStart + 1, openingTagEnd);
            var closingTag = '</' + tagName + '>';
            var closingTagStart = text.indexOf(closingTag);
            var tagContent = text.slice(openingTagEnd + 1, closingTagStart);

            switch (tagName) {
                case 'mixcase':
                    var mixcasedTagName = '';
                    for (var i = 0; i < tagContent.length; i += 1) {
                        switch (Math.floor(Math.random() * 2)) {
                            case 0:
                                mixcasedTagName += tagContent[i].toLowerCase();
                                break;
                            case 1:
                                mixcasedTagName += tagContent[i].toUpperCase();
                                break;
                        }
                    }

                    tagContent = mixcasedTagName;
                    break;
                case 'upcase':
                    tagContent = tagContent.toUpperCase();
                    break;
                case 'lowcase':
                    tagContent = tagContent.toLowerCase();
                    break;
                default:
                    throw "Unknown casing supplied!";
            }

            text = text.slice(0, openingTagStart) + tagContent + text.slice(closingTagStart + closingTag.length);
            position = openingTagStart + tagContent.length;
        }

        return text;
    };

    var execute = function () {
        var output = "Initial data has been hardcoded in order to simplify your task: <br />",
            text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>AnythinG</lowcase> else.";
        output += "Original text: " + text.htmlEscape() + '<br />';
        output += "Changed text: " + text.fixCasing() + '<br />';

        return output;
    };

    return execute();
};
