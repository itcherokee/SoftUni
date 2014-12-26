'use strict';

angular.module('CtrlAndMarkup').factory('dataService', [ '$http', '$q', function ($http, $q) {
    function read() {
        var defer = $q.defer();
        $http.get('resources/data.json')
            .success(function (result) {
                defer.resolve(result);
            })
            .error(function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    function save(data) {
        var defer = $q.defer();
        var jsonData = json.stringify(data);
        $http.post('resources/data.json', jsonData)
            .success(function (result) {
                defer.resolve(result);
            })
            .error(function (error) {
                defer.reject(error);
            });
    }

    return {
        read: read,
        save: save
    }
}]);