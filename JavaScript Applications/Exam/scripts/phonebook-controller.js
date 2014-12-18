'use strict';
var app = app || {};
app.controller = (function () {
    var model = app.model,
        notification = app.notify,
        phones = [];

    function changeTitle(text) {
        $('#header > span').text(text);
    }

    function isLoggedIn() {
        return sessionStorage.getObject('user') &&
            (sessionStorage.getObject('user').sessionId.length > 0) ? true : false;
    }

    function findPhonebookEntryByIdInRow(button) {
        var entryId = $(button).closest('tr').data('id');
        return $.grep(phones.results, function (item) {
            return item.id == entryId;
        })[0];
    }

    function findPhonebookEntryByIdInButton(button) {
        var entryId = $(button).data('id');
        return $.grep(phones.results, function (item) {
            return item.id == entryId;
        })[0];
    }

    function attachWelcomeAndRegisterFormLoginHandler(selector) {
        $(selector).on('click', '#welcome-login, #register-form a.link', function () {
            showLogin(selector);
        })
    }

    function attachWelcomeAndLoginFormRegisterHandler(selector) {
        $(selector).on('click', '#welcome-register, #login-form a.link', function () {
            showRegister(selector);
        })
    }

    function attachRegisterFormRegisterHandler(selector) {
        $(selector).on('click', '#register-form a.button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var fullName = $('#fullName').val();
            var currentUser = new model.User(username, password, fullName);
            currentUser.register()
                .then(function (user) {
                    sessionStorage.setObject('user', user);
                    $('#username').val('');
                    $('#password').val('');
                    $('#fullName').val('');
                    $(selector).data('user', currentUser);
                    notification.success('Successful registration');
                    showHome(selector);
                }, function () {
                    notification.error("Unsuccessful registration attempt.");
                });
        })
    }

    function attachLoginFormLoginHandler(selector) {
        $(selector).on('click', '#login-form a.button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var currentUser = new model.User(username, password);
            currentUser.login()
                .then(function (user) {
                    sessionStorage.setObject('user', user);
                    $('#username').val('');
                    $('#password').val('');
                    $('#fullName').val('');
                    $(selector).data('user', currentUser);
                    notification.success('Login successful');
                    showHome(selector);
                }, function () {
                    notification.error('Invalid login');
                });
        })
    }

    function attachListAddPhoneHandler(selector) {
        $(selector).on('click', '#phones-form-addphone-button', function () {
            showAddPhone(selector);
        })
    }

    function attachListEditPhoneHandler(selector) {
        $(selector).on('click', '#phones-form-edit-button', function () {
            var entry = findPhonebookEntryByIdInRow(this);
            showEditPhone(selector, entry);
        })
    }

    function attachListDeletePhoneHandler(selector) {
        $(selector).on('click', '#phones-form-delete-button', function () {
            var entry = findPhonebookEntryByIdInRow(this);
            showDeletePhone(selector, entry);
        });
    }

    function attachFormCancelHandler(selector) {
        $(selector).on('click', '#edit-form-cancel-button, #delete-form-cancel-button, #add-form-cancel-button',
            function () {
                showPhonebook(selector);
            })
    }

    function attachDeleteFormDeleteHandler(selector) {
        $(selector).on('click', '#delete-form-delete-button', function () {
            var entry = findPhonebookEntryByIdInButton(this);
            entry.del()
                .then(function () {
                    notification.success('Phonebook entry successfully deleted.');
                    showPhonebook(selector);
                }, function () {
                    notification.error('Phonebook entry was not deleted.');
                    showPhonebook(selector);
                });
        })
    }

    function attachEditFormEditHandler(selector) {
        $(selector).on('click', '#edit-form-edit-button', function () {
            var entry = findPhonebookEntryByIdInButton(this);
            entry.person = $('#personName').val();
            entry.number = $('#phoneNumber').val();
            entry.edit()
                .then(function () {
                    notification.success('Phonebook entry successfully updated.');
                    showPhonebook(selector);
                },
                function () {
                    notification.error('Phonebook entry update failed.');
                    showPhonebook(selector);
                });
        })
    }

    function attachAddFormAddHandler(selector) {
        $(selector).on('click', '#add-form-add-button', function () {
            var person = $('#personName').val(),
                number = $('#phoneNumber').val();
            var entry = new model.PhonebookEntry(person, number);
            entry.add()
                .then(function () {
                    notification.success('Phonebook entry successfully added.');
                    showPhonebook(selector);
                },
                function () {
                    notification.error('Phonebook entry was not added.')
                    showAddPhone(selector);
                });
        })
    }

    function attachEditProfileEditHandler(selector) {
        $(selector).on('click', '#edit-profile-edit-button', function () {
            var user = $(this).data('user');
            user.username = $('#username').val();
            user.number = $('#fullName').val();
            user.password = $('#password').val();
            user.edit()
                .then(function () {
                    notification.success('User profile successfully updated.');
                    showHome(selector);
                },
                function () {
                    notification.error('User profile update failed.');
                    var storedUser = sessionStorage.getObject('user');
                    var user = new model.User(storedUser.person, '******', storedUser.fullName);
                    showEditProfile(selector, user);
                });
        })
    }

    function attachEditProfileCancelHandler(selector) {
        $(selector).on('click', '#edit-profile-cancel-button',
            function () {
                showHome(selector);
            })
    }

    function attachEventHandlers(selector) {
        attachWelcomeAndRegisterFormLoginHandler(selector);
        attachWelcomeAndLoginFormRegisterHandler(selector);
        attachLoginFormLoginHandler(selector);
        attachRegisterFormRegisterHandler(selector);
        attachListAddPhoneHandler(selector);
        attachListEditPhoneHandler(selector);
        attachListDeletePhoneHandler(selector);
        attachFormCancelHandler(selector);
        attachDeleteFormDeleteHandler(selector);
        attachEditFormEditHandler(selector);
        attachAddFormAddHandler(selector);
        attachEditProfileEditHandler(selector);
        attachEditProfileCancelHandler(selector);
    }

    function showHome(selector) {
        if (isLoggedIn()) {
            $('nav').load('./templates/menu.html');
            changeTitle(' - Home');
            $.get('templates/home.html', function (template) {
                var output = Mustache.render(template, $(selector).data('user'));
                $(selector).html(output);
            });
        } else {
            $(selector).load('./templates/welcome.html');
            changeTitle(' - Welcome');
        }
    }

    function showLogin(selector) {
        $(selector).load('./templates/login.html');
        changeTitle(' - Login');
    }

    function showRegister(selector) {
        $(selector).load('./templates/register.html');
        changeTitle(' - Register');
    }

    function showPhonebook(selector) {
        if (isLoggedIn()) {
            $('nav').load('./templates/menu.html');
            changeTitle(' - List');
            model.fetchPhonebook()
                .then(function (data) {
                    phones['results'] = data;
                    $.get('templates/phonebook.html', function (template) {
                        var output = Mustache.render(template, phones);
                        $(selector).html(output);
                    })
                },
                function () {
                    notification.error('Phonebook cannot be shown now due to connection problems.');
                });
        }
    }

    function showAddPhone(selector) {
        if (isLoggedIn()) {
            $('nav').load('./templates/menu.html');
            $(selector).load('./templates/addPhone.html');
            changeTitle(' - Add Phone');
        }
    }

    function showEditPhone(selector, data) {
        if (isLoggedIn()) {
            $('nav').load('./templates/menu.html');
            $.get('templates/editPhone.html', function (template) {
                var output = Mustache.render(template, data);
                $(selector).html(output);
            });
            changeTitle(' - Edit Phone');
        }
    }

    function showDeletePhone(selector, data) {
        if (isLoggedIn()) {
            $('nav').load('./templates/menu.html');
            $.get('templates/deletePhone.html', function (template) {
                var output = Mustache.render(template, data);
                $(selector).html(output);
            });
            changeTitle(' - Delete Phone');
        }
    }

    function showEditProfile(selector) {
        if (isLoggedIn()) {
            $('nav').load('./templates/menu.html');
            var storedUser = sessionStorage.getObject('user');
            var user = new model.User(storedUser.username, '******', storedUser.fullName);
            $.get('templates/userEdit.html', function (template) {
                var output = Mustache.render(template, user);
                $(selector).html(output);
            });
            $('#edit-profile-edit-button').data('user', user);
            changeTitle(' - Edit Profile');
        }
    }

    function showLogout(selector) {
        if (isLoggedIn()) {
            sessionStorage.removeItem('user');
            $('nav').empty();
            notification.success('Successful logout.');
        }
        showHome(selector);
    }

    return {
        showHome: showHome,
        showLogin: showLogin,
        showRegister: showRegister,
        showPhonebook: showPhonebook,
        showAddPhone: showAddPhone,
        showEditPhone: showEditPhone,
        showDeletePhone: showDeletePhone,
        showEditProfile: showEditProfile,
        showLogout: showLogout,
        attachEventHandlers: attachEventHandlers
    }
}());