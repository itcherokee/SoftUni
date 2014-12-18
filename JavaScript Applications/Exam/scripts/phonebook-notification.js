'use strict';
var app = app || {};
app.notify = (function () {
    var notyData = {
        layout: 'topCenter',
        closeWith: ['click']
    };

    function success(message) {
        notyData.type = 'success';
        notyData.text = message;
        notyData.timeout = 2000;
        noty(notyData);
    }

    function error(message) {
        notyData.type = 'error';
        notyData.text = message;
        notyData.timeout = 5000;
        notyData.buttons = [
            {
                text: "X",
                onClick: function ($noty) {
                    $noty.close();
                }
            }
        ];
        noty(notyData);
    }

    return {
        success: success,
        error: error
    }
}());