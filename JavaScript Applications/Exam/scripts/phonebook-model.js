'use strict';
var app = app || {};

app.model = (function () {
    var dal = app.dal,
        phones = [];

    function userDataHandling(operation) {
        var $this = this;
        return operation({username: this.username, password: this.password, fullName: this.fullName})
            .then(function (data) {
                $this.sessionId = data.sessionToken;
                if (data.fullName) {
                    $this.fullName = data.fullName;
                }
                $this.id = data.objectId;
                $this.password = '';
                return $this
            });
    }

    var User = (function () {
        function User(username, password, fullName) {
            this.username = username;
            this.password = password;
            this.fullName = fullName || '';
        }

        User.prototype.login = function () {
            return userDataHandling.call(this, dal.loginUser);
        };

        User.prototype.register = function () {
            return userDataHandling.call(this, dal.registerUser);
        };

        User.prototype.edit = function () {
            var $this = this;
            return dal.editUser({username: this.username, password: this.password, fullName: this.fullName})
                .then(function (data) {
                    $this.sessionId = data.sessionToken;
                    $this.fullName = data.fullName;
                    $this.id = data.objectId;
                    $this.password = '';
                })
        };

        return User;
    }());

    var PhonebookEntry = (function () {
        function PhonebookEntry(person, number, id) {
            this.id = id || '';
            this.person = person || '';
            this.number = number || '';
        }

        PhonebookEntry.prototype.add = function () {
            var acl = {};
            acl[sessionStorage.getObject('user').id] = {"write": true, "read": true};
            var data =
                {
                    person: this.person,
                    number: this.number,
                    ACL: acl
                },
                $this = this;
            return dal.addPhone(data)
                .then(
                function (data) {
                    $this.id = data.objectId;
                    return data
                }
            )
        };

        PhonebookEntry.prototype.edit = function () {
            var data =
            {
                person: this.person,
                number: this.number
            };
            return dal.editPhone(this.id, data);
        };

        PhonebookEntry.prototype.del = function () {
            return dal.deletePhone(this.id);
        };

        return PhonebookEntry;
    }());

    function fetchPhonebook() {
        return dal.getPhones()
            .then(
            function (data) {
                phones = [];
                $(data['results']).each(function (_, item) {
                    var phoneEntry = new PhonebookEntry(item.person, item.number, item.objectId);
                    phones.push(phoneEntry);
                });
                return phones;
            })
    }

    return {
        fetchPhonebook: fetchPhonebook,
        PhonebookEntry: PhonebookEntry,
        User: User
    }
}());