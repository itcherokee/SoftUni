var app = app || {}
$(function(){

//    var baseUrl = 'https://api.parse.com/1/'
//    var ajaxRequester = app.ajaxRequester.get();
//    var data = app.data.get(baseUrl, ajaxRequester);
    var controller = app.controller;
//    controller.attachEventHandlers();

    app.router = Sammy(function () {
        var $selector = $('#content');

//        var selector = '#wrapper';
        this.get('#/', function (){
            controller.showHome($selector);
        });

        this.get('#/login', function () {
            controller.showLogin($selector);
        });

        this.get('#/register', function () {
            controller.showRegister($selector);
        });

        this.get('#/bookmarks', function () {
            // this.redirect('#/login');
            controller.showBookmarks($selector);
        });
    });

    app.router.run('#/');


//    app.controller.start();
});