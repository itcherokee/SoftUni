'use strict';

angular.module('introToAngular', ['ngRoute']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/student', {
                templateUrl: 'templates/studentPageView.html',
                controller: 'StudentPage',
                controllerAs: 'student'
            })
            .when('/image', {
                templateUrl: 'templates/BindImageView.html',
                controller: 'BindImage',
                controllerAs: 'bindImg'
            })
            .when('/tiger', {
                templateUrl: 'templates/tigerView.html',
                controller: 'Tiger',
                controllerAs: 'tiger'
            })
            .otherwise({
                redirectTo: '/student'
            });
    }]);
