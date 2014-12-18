'use strict';
var app = app || {};

$(function () {
    var selector = '#wrapper',
        controller = app.controller;

    controller.attachEventHandlers(selector);

    app.router = Sammy(function () {
        this.get('#/', function () {
            controller.showHome(selector);
        });

        this.get('#/login', function () {
            controller.showLogin(selector);
        });

        this.get('#/register', function () {
            controller.showRegister(selector);
        });

        this.get('#/phonebook', function () {
            controller.showPhonebook(selector);
        });

        this.get('#/addPhone', function () {
            controller.showAddPhone(selector);
        });

        this.get('#/editProfile', function () {
            controller.showEditProfile(selector);
        });

        this.get('#/logout', function () {
            controller.showLogout(selector);
        });
    });

    app.router.run('#/');
});