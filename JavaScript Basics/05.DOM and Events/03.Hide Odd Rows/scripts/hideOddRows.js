// Task 3:  You are given an HTML file holding a table of elements and a button titled "Hide Odd Rows".
//          Write JavaScript code hideOddRows.js that attaches to the button lick event and hides
//          the odd rows of the table when clicked.

(function () {
    "use strict";
    var button = document.getElementById('btnHideOddRows');

    button.addEventListener("click", (function () {
        var rows = document.getElementsByTagName('tr'),
            index, len;

        for (index = 0, len = rows.length; index < len; index += 1) {
            rows[index].className = 'visible';
        }

        return function () {
            var visibleRows = document.getElementsByClassName('visible'),
                allRows = document.getElementsByTagName('tr'),
                index, len;

            for (index = 0, len = visibleRows.length; index < len; index += 1) {
                if (index % 2 === 0) {
                    visibleRows[index].style.display = 'none';
                }
            }

            for (index = 0, len = visibleRows.length; index < len; index += 1) {
                if (allRows[index].style.display === 'none') {
                    allRows[index].className = 'hidden';
                }
            }
        }
    }()));
}());