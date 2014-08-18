// Task 1:  Crate a HTML page holding a "Like" button that changes
//          to "Unlike" when clicked, then again to "Like", etc.

(function () {
    "use strict";
    var button = document.getElementById('like-unlike');

    var toggle = (function () {
        var isLike = true;
        return function () {
            this.textContent = isLike ? "Unlike" : "Like";
            isLike = !isLike;
        };
    }());

    // 'mousedown' is used in order the text to be changed when button is pressed,
    // when using 'click', text is changed on releasing the mouse
    button.addEventListener("mousedown", toggle);
    button.addEventListener("keypress", toggle);
}());