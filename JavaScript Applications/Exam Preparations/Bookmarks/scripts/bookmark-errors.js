'use strict';
var app = app || {};
app.errors = (function () {
    var notyData = {
        layout: 'topCenter',
        timeout: 5000
    };

    function success(message) {
        notyData.type = 'success';
        notyData.mesasge = message;
        noty(notyData);
    }

    function error(message) {
        notyData.type = 'error';
        notyData.mesasge = message;
        noty(notyData);
    }

    function loginError(message) {
        if (message) {
            error(message)
        } else {
            error('Unsuccessful login attempt.')
        }
    }

    function registerError(message) {
        if (message) {
            error(message)
        } else {
            error('Unsuccessful attempt register.')
        }
    }

    function addBookmarkError(message) {
        if (message) {
            error(message)
        } else {
            error('Unsuccessful bookmark addition.')
        }
    }

    function loadBookmarksError(message) {
        if (message) {
            error(message)
        } else {
            error('Unsuccessful bookmarks fetching.')
        }
    }

    function showBookmarksError(message) {
        if (message) {
            error(message)
        } else {
            error('Unable to display bookmarks.')
        }
    }

    return {
        loginError: loginError,
        registerError: registerError,
        addBookmarkError : addBookmarkError,
        loadBookmarksError :loadBookmarksError,
        showBookmarksError : showBookmarksError
    }
}());