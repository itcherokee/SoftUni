var app = app || {};
app.dal = (function () {
    var APP_ID = 'oBDvS8nklOgFUeEu9DAOCG63jiVHzOqOdkhPVFJd',
        REST_API_ID = 'qXIhZ9sZrfQCWqVZPYiSCtkMu4UEYtHWiMGHW6jx',
        APP_URL = 'https://api.parse.com/1/',
        sessionId = '';

    function getSessionId (){

        return sessionStorage.getObject('user').sessionId;
    }

    function ajax(method, resource, data) {
        var contentType = 'application/json',
            url = resource || '',
            payload = data || {},
            headers = {
                'X-Parse-Application-Id': APP_ID,
                'X-Parse-REST-API-Key': REST_API_ID,
                'X-Parse-Session-Token': sessionId
            },
            methodToBeUsed = method || 'GET',
            serviceAddress = APP_URL + url || APP_URL,
            defer = Q.defer();

        $.ajax({
            method: methodToBeUsed,
            url: serviceAddress,
            headers: headers,
            contentType: contentType,
            data: payload,
            success: function (data) {
                ajaxSuccessNotify();
                defer.resolve(data);
            },
            error: function (error) {
                ajaxErrorNotify();
                defer.reject(error)
            }
        });

        return defer.promise;
    }

    function ajaxSuccessNotify() {
        noty(
            {
                text: 'Ajax request successfully completed',
                type: 'success',
                layout: 'topCenter',
                timeout: 5000
            }
        );
    }

    function ajaxErrorNotify() {
        noty(
            {
                text: 'Unsuccessful ajax request.',
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            }
        );
    }

//    var dal = (function () {
    function loginUser(data) {
        return ajax('GET', 'login', data);
    }

    function registerUser(data) {
        return ajax('POST', 'users', JSON.stringify(data));
    }

    function addBookmark(data) {
        sessionId = getSessionId();
        return ajax('POST', 'classes/Bookmark', JSON.stringify(data));
    }

//        function editBookmark(id, data) {
//            return ajax('PUT', 'classes/Book/' + id, data);
//        }

    function deleteBookmark(id) {
        sessionId = getSessionId();
        return ajax('DELETE', 'classes/Bookmark/' + id, {});
    }

    function getBookmarks() {
        sessionId = getSessionId();
        return ajax('GET', 'classes/Bookmark', {});
    }

    return {
        loginUser: loginUser,
        registerUser: registerUser,
        addBookmark: addBookmark,
//            editBook: editBook,
        deleteBookmark: deleteBookmark,
        getBookmarks: getBookmarks
    };
//    }());

    //scope.dal = dal;
}());