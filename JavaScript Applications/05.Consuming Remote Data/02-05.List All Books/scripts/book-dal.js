var app = app || {};
(function (scope) {
    var APP_ID = '1WPbGmiY4oJEo4axk0OfIalegAbw7YXuNoRt0bFk',
        REST_API_ID = 'urImEBiZjvYprnhb9KG3oxWUpS9RDG4UAyQ6aidN',
        APP_URL = 'https://api.parse.com/1/classes/';

    function ajax(method, resource, data, success, error) {
        var contentType = 'application/json',
            url = resource || '',
            payload = data || {},
            headers = {
                'X-Parse-Application-Id': APP_ID,
                'X-Parse-REST-API-Key': REST_API_ID
            },
            methodToBeUsed = method || 'GET',
            serviceAddress = APP_URL + url || APP_URL;

        $.ajax({
            method: methodToBeUsed,
            url: serviceAddress,
            headers: headers,
            contentType: contentType,
            data: JSON.stringify(payload),
            success: success,
            error: error
        });

    }

    var dal = (function () {
        function addBook(data, success, error) {
           return ajax('POST', 'Book', data, success, error);
        }

        function editBook(id, data, success, error) {
           return ajax('PUT', 'Book/' + id, data, success, error);
        }

        function deleteBook(id, success, error) {
           return ajax('DELETE', 'Book/' + id, {}, success, error);
        }

        function listBooks(success, error) {
           return ajax('GET', 'Book', {}, success, error);
        }

        return {
            addBook: addBook,
            editBook: editBook,
            deleteBook: deleteBook,
            listBooks: listBooks
        }
    }());

    scope.dal = dal;
}(app));