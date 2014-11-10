/*
 Create a module for working with the console object. The module should support the following functionality:
 •	Writing a line to the console
 •	Writing a line to the console using formatting (with placeholders)
 •	Writing to the console should call toString() to each element
 •	Writing errors and warnings to the console with and without format
 */

var specialConsole = (function () {

    String.prototype.formatString = stringFormat;

    function replaceAtPlaceholder(input, searchFor, replaceWith) {
        var pattern = new RegExp(searchFor, 'g');
        input = input.replace(pattern, replaceWith);
        return input;
    }

    function stringFormat(format) {
        var output = '';
        if (format.length) {
            output = format[0];
            if (format.length <= 1) {
                return output;
            }

            for (var placeIndex = 1; placeIndex < format.length; placeIndex++) {
                output = replaceAtPlaceholder(output, '\\{'
                    + (placeIndex - 1) + '\\}', format[placeIndex].toString());
            }
        }

        return output;
    }

    function writeLine(msg) {
        console.log(String().formatString(arguments));
    }

    function writeError(msg) {
        console.error(String().formatString(arguments));
    }

    function writeWarning(msg) {
        console.warn(String().formatString(arguments));
    }

    return {
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError
    }
})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello parameters");
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeLine("Message: {0}", new Object());
