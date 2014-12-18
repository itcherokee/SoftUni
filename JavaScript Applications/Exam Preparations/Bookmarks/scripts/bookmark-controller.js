var app = app || {};
app.controller = (function () {
    var model = app.model,
        error = app.errors,
        bookmarks = [];
//
//        function attachAddEvent() {
//            $('#content').on('click', '.new-button', function () {
//                var book = new app.model.Book();
//                book.title = $('#new-title').val();
//                book.author = $('#new-author').val();
//                book.isbn = $('#new-isbn').val();
//                if (book.title && book.author && book.isbn) {
//                    book.addBook();
//                }
//            })
//        }
//
//        function attachDeleteEvent() {
//            $('#content').on('click', '.delete-button', function () {
//                var book = $(this).closest('tr').data('book');
//                book.deleteBook();
//            })
//        }
//
//        function attachEditEvent() {
//            $('#content').on('click', '.edit-button', function () {
//                var row = $(this).closest('tr');
//                var editRow = app.view.editRow(row);
//                editRow.on('click', '.save-button', function () {
//                    var $book = $(this).closest('tr').data('book');
//                    $book.title = $('#edit-title').val();
//                    $book.author = $('#edit-author').val();
//                    $book.isbn = $('#edit-isbn').val();
//                    if ($book.title && $book.author && $book.isbn) {
//                        $book.editBook();
//                    }
//                });
//            })
//        }
//
//        function attachEvents() {
//            attachAddEvent();
//            attachDeleteEvent();
//            attachEditEvent()
//        }
    function showLogin(selector) {
        selector.load('./templates/login.html');
        selector.on('click', '#login-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var currentUser = new model.User(username, password);
            currentUser.login().then(function (user) {
                sessionStorage.setObject('user', user);
                $('#username').val('');
                $('#password').val('');
            }, function (error) {
                error.loginError(error);
            });
        })
    }

    function showRegister(selector) {
        selector.load('./templates/register.html');
        selector.on('click', '#register-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var currentUser = new model.User(username, password);
            currentUser.register().then(function (user) {
                sessionStorage.setObject('user', user);
                $('#username').val('');
                $('#password').val('');
            }, function (error) {
                error.registerError(error);
            });
        })
    }

    function loadBookmarks(selector) {
        model.fetchBookmarks()
            .then(function (data) {
                bookmarks['results'] = data;
                $.get('templates/bookmarks.html', function (template) {
                    var output = Mustache.render(template, bookmarks);
                    $(selector).html(output);
                })
            });
    }

    function showBookmarks(selector) {
        loadBookmarks(selector);

        selector.on('click', '#delete-bookmark-button', function () {
            var bookmarkId = $(this).parent().data('objectId');
            var bookmark = $.grep(bookmarks.results, function (item) {
                return item.id == bookmarkId;
            })[0];
            bookmark.del()
                .then(function () {
                    loadBookmarks();
                }, function (error) {
                    error.showBookmarksError(error);
                });
        });

        selector.on('click', '#create-bookmark-button', function () {
            var title = $('#title').val();
            var url = $('#url').val();
            var bookmark = new model.Bookmark(title, url);
            bookmark.add()
                .then(function () {
                    loadBookmarks();
                }, function (error) {
                    error.addBookmarkError(error);
                });
        });
    }

    function showHome(selector){
        selector.load('./templates/welcome.html');
    }

    function start() {
//            app.model.load($('#content'), app.view.show);
//            attachEvents();


    }

    return {
        showLogin: showLogin,
        showRegister : showRegister,
        showBookmarks : showBookmarks,
        showHome : showHome
    }
}());