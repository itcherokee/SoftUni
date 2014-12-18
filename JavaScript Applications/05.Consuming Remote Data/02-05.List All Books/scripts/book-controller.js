var app = app || {};
(function (scope) {
    var controller = (function () {

        function attachAddEvent() {
            $('#content').on('click', '.new-button', function (event) {

                var book = new app.model.Book();
                book.title = $('#new-title').val();
                book.author = $('#new-author').val();
                book.isbn = $('#new-isbn').val();
                book.addBook();
            })
        }

        function attachDeleteEvent() {
            $('#content').on('click', '.delete-button', function (event) {
                var book = $(this).closest('tr').data('book');
                book.deleteBook();
            })
        }

        function attachEditEvent() {
            $('#content').on('click', '.edit-button', function (event) {
                var row = $(this).closest('tr');
                var editRow = app.view.editRow(row);
                editRow.on('click', '.save-button', function (event) {
                    var $book = $(this).closest('tr').data('book');
                    $book.title = $('#edit-title').val();
                    $book.author = $('#edit-author').val();
                    $book.isbn = $('#edit-isbn').val();
                    $book.editBook();
                    app.model.load('#content', app.view.show)
                });
            })
        }

        function attachEvents() {
            attachAddEvent();
            attachDeleteEvent();
            attachEditEvent()
        }

        function start() {
            app.model.load($('#content'), app.view.show);
            attachEvents();
        }

        return {
            start: start
        }
    }());

    scope.controller = controller;
}(app));