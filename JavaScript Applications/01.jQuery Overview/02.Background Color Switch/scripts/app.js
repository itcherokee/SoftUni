// Task 2:  Write a script using jQuery for switching the background color of elements with a specified class.
//          The input should be read from an input form.

(function () {
    function toggleColor(cssClass, color) {
        var selectedItems = $(cssClass),
            currentlyColoredClass;

        function clearColoring(){
            $(currentlyColoredClass).css('background','inherit');
        }

        if (selectedItems.length > 0) {
            clearColoring();
            selectedItems.css('background',color);
        } else {
            $('#error').text('No such class in the code.').css('color','red');
        }
    }

    $(function () {
        $('button').on('click', function () {
            var color = $('#classColor').val(),
                selClass = '.' + $('#cssClass').val();

            $('#error').text('');
            toggleColor(selClass, color);
        });
    })
}());