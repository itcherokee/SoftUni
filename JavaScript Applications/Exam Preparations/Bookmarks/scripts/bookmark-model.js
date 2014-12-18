var app = app || {};

app.model = (function () {
    var dal = app.dal,
        errorInfo = app.errors,
        bookmarks = [],
        mainSelector,
        mainOutputCallback;

    function userDataHandling(operation) {
        var $this = this;
        return operation({username: this.username, password: this.password})
            .then(function (data) {
                $this.sessionId = data.sessionToken;
                $this.id = data.objectId;
                $this.password = '';
                return $this
            }, function (error) {
                errorInfo.loginError();
            });
    }

    var User = (function () {
        function User(username, password) {
            this.username = username;
            this.password = password;
        }

        User.prototype.login = function () {
            return userDataHandling.call(this, dal.loginUser);
        };

        User.prototype.register = function () {
            return userDataHandling.call(this, dal.registerUser);
        };

        return User;
    }());

    var Bookmark = (function () {
        function Bookmark(title, url, id) {
            this.id = id || '';
            this.title = title;
            this.url = url;
        }

        Bookmark.prototype.add = function () {
            var acl = {};
            acl[sessionStorage.getObject('user').objectId] = {"write": true, "read": true};
            var data =
            {
                title: this.title,
                url: this.url,
                ACL: acl
            },
                $this = this;
            return dal.addBookmark(data)
                .then(
                function (data) {
                    $this.id = data.objectId;
                    return data
                },
                function (error) {
                    errorInfo.addBookmarkError(error);
                }
            )
        };

        Bookmark.prototype.del = function () {
            return dal.deleteBookmark(this.id);
        };

        return Bookmark;
    }());

    function fetchBookmarks() {
        return dal.getBookmarks()
            .then(
            function (data) {
                bookmarks = [];
                $(data['results']).each(function (_, item) {
                    var bookmark = new Bookmark( item.title, item.url, item.objectId);
                    bookmarks.push(bookmark);
                });
                return bookmarks;
//                mainOutputCallback(mainSelector, books);
            },
            function (error) {
                errorInfo.loadBookmarksError(error);
            })
    }

    return {
//        load: function (selector, outputCallback) {
//            mainSelector = selector;
//            mainOutputCallback = outputCallback;
//            loadBookmarks();
//        },
        fetchBookmarks: fetchBookmarks,
        Bookmark: Bookmark,
        User: User
    }
}());