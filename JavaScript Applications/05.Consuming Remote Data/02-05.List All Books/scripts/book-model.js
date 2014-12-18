var app = app || {};
(function (scope) {
    var model = (function () {
        var books = [],
            mainSelector,
            mainOutputCallback;

        function success() {
            notify('success');
        }

        function error() {
            notify('error');
            return {};
        }

        var Book = (function () {
            function Book(id, title, author, isbn) {

                this.id = id;
                this.title = title;
                this.author = author;
                this.isbn = isbn;
            }

            Book.prototype.addBook = function () {
                scope.dal.addBook({
                    'title': this.title,
                    'author': this.author,
                    'isbn': this.isbn
                }, function () {
                    success();
                    loadBooks();
                }, error)
            };

            Book.prototype.editBook = function () {
                scope.dal.editBook(this.id, {
                    'title': this.title,
                    'author': this.author,
                    'isbn': this.isbn
                }, function () {
                    success();
                    loadBooks();
                }, error)
            };

            Book.prototype.deleteBook = function () {
                scope.dal.deleteBook(this.id, function () {
                    success();
                    loadBooks();
                }, error)
            };

            return Book;
        }());

        function loadBooks() {
            scope.dal.listBooks(function (data) {
                success();
                books = [];
                $(data['results']).each(function (_, item) {
                    var book = new Book(item.objectId, item.title, item.author, item.isbn);
                    books.push(book);
                });
                mainOutputCallback(mainSelector, books);
            }, error);
        }

        return {
            load: function (selector, outputCallback) {
                mainSelector = selector;
                mainOutputCallback = outputCallback;
                loadBooks();
            },
            Book : Book
        }
    }());

    function notify(type) {
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
                        text: 'Unsuccessful ajax request.',
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

    scope.model = model;
}(app));