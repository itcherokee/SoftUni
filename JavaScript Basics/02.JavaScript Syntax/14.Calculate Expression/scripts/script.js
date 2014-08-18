(function () {
    "use strict";
    String.prototype.htmlEscape = function () {
        var escapedStr = String(this).replace(/&/g, '&amp;');
        escapedStr = escapedStr.replace(/</g, '&lt;');
        escapedStr = escapedStr.replace(/>/g, '&gt;');
        escapedStr = escapedStr.replace(/"/g, '&quot;');
        escapedStr = escapedStr.replace(/'/g, '&#39');
        return escapedStr;
    }

    var button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', function () {
        var input,
            output,
            fixedOutput;
        input = document.getElementById('expression');
        output = document.getElementById('result');
        try {
            fixedOutput = input.value.htmlEscape();
            output.innerHTML = eval(fixedOutput);

        }
        catch (e) {
            output.innerHTML = "Invalid inoput detected!";
        }
    });
}());