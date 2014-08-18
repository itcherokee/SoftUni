// Task 5:  Write a JavaScript code that prints the mouse coordinates in
//          a text area when we move the mouse over the HTML document.

(function () {
    "use strict";
    var textarea = document.getElementById('info');

    function announce(e) {
        textarea.innerHTML += 'X:' + e.clientX + '; Y:' + e.clientY + ' Time: ' + new Date() + '\n';
        textarea.scrollTop = textarea.scrollHeight;
    }

    document.addEventListener("mousemove", announce);
}());
