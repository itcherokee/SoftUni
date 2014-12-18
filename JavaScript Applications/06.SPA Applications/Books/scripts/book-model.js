var app = app || {};
(function (scope) {
    var model = (function () {
        var books = [],
            mainSelector,
            mainOutputCallback;

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
                })
                    .then(function () {
                        loadBooks();
                    })
                    .done();
            };

            Book.prototype.editBook = function () {
                scope.dal.editBook(this.id, {
                    'title': this.title,
                    'author': this.author,
                    'isbn': this.isbn
                })
                    .then(function () {
                        loadBooks();
                    })
                    .done();
            };

            Book.prototype.deleteBook = function () {
                scope.dal.deleteBook(this.id)
                    .then(function () {
                        loadBooks()
                    })
                    .done();
            };

            return Book;
        }());

        function loadBooks() {
            scope.dal.listBooks()
                .then(function (data) {
                    books = [];
                    $(data['results']).each(function (_, item) {
                        var book = new Book(item.objectId, item.title, item.author, item.isbn);
                        books.push(book);
                    });
                    mainOutputCallback(mainSelector, books);
                })
                .done();
        }

        return {
            load:
            function (selector, outputCallback) {
                mainSelector = selector;
                mainOutputCallback = outputCallback;
                loadBooks();
            },
            Book: Book
        }
    }());

    scope.model = model;
}(app));