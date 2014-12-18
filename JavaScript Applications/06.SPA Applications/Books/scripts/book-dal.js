var app = app || {};
(function (scope) {
    var APP_ID = '1WPbGmiY4oJEo4axk0OfIalegAbw7YXuNoRt0bFk',
        REST_API_ID = 'urImEBiZjvYprnhb9KG3oxWUpS9RDG4UAyQ6aidN',
        APP_URL = 'https://api.parse.com/1/classes/';

    function ajax(method, resource, data) {
        var contentType = 'application/json',
            url = resource || '',
            payload = data || {},
            headers = {
                'X-Parse-Application-Id': APP_ID,
                'X-Parse-REST-API-Key': REST_API_ID
            },
            methodToBeUsed = method || 'GET',
            serviceAddress = APP_URL + url || APP_URL,
            defer = Q.defer();

        $.ajax({
            method: methodToBeUsed,
            url: serviceAddress,
            headers: headers,
            contentType: contentType,
            data: JSON.stringify(payload),
            success: function (data) {
                notify('success');
                defer.resolve(data);
            },
            error: function (error) {
                notify('error', error);
                defer.reject(error)
            }
        });

        return defer.promise;
    }

    var dal = (function () {
        function addBook(data) {
            return ajax('POST', 'Book', data);
        }

        function editBook(id, data) {
            return ajax('PUT', 'Book/' + id, data);
        }

        function deleteBook(id) {
            return ajax('DELETE', 'Book/' + id, {});
        }

        function listBooks() {
            return ajax('GET', 'Book', {});
        }

        return {
            addBook: addBook,
            editBook: editBook,
            deleteBook: deleteBook,
            listBooks: listBooks
        }
    }());

    function notify(type, message) {
        var status = type && (type === 'success' || type === 'error') ? type : 'unknown';
        switch (status) {
            case 'success':
                noty({
                        text: 'Ajax request successfully completed',
                        type: 'success',
                        layout: 'bottomLeft',
                        timeout: 5000}
                );
                break;
            case 'error':
                noty({
                        text: message,//'Unsuccessful ajax request.',
                        type: 'error',
                        layout: 'bottomLeft',
                        timeout: 5000}
                );
                break;
            default:
                noty({
                        text: 'Unknown error.',
                        type: 'alert',
                        layout: 'topCenter',
                        timeout: 5000}
                );
        }
    }

    scope.dal = dal;
}(app));