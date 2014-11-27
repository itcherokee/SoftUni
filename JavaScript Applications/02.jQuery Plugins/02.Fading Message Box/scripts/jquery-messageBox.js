// Task 2:  Create a jQuery plugin for fading in/fading out a message box. The plugin should support:
//          • Creating a message box (a div holding some text)
//          • Showing a success/error message in the box
//              o Showing is done by setting the opacity of the message from 0 to 1 in an interval of 1 second
//              o The message should disappear after 3 seconds

(function ($) {
    $.fn.messageBox = function () {
        var FADING_INTERVAL = 1000,
            DISAPPEAR_INTERVAL = 3000,
            $this = $(this);

        function createBox(message, type) {
            var element = $('<div>').css({
                background: type === 'error' ? 'red' : 'green',
                color: type === 'white',
                padding: '10px',
                margin: '10px',
                border: '1px solid black',
                width: 200,
                opacity: 0
            }).text(message);

            setTimeout(function () {
                $this.children().remove()
            }, DISAPPEAR_INTERVAL);

            return element;
        }

        function success(message) {
            $this.empty();
            $(createBox('Success: ' + message)).appendTo($this).animate({opacity: 1}, FADING_INTERVAL);
            return $this;
        }

        function error(message) {
            $this.empty();
            $(createBox('Error: ' + message, 'error')).appendTo($this).animate({opacity: 1}, FADING_INTERVAL);
            return $this;
        }

        return {
            success: success,
            error: error
        }
    }
}(jQuery));
