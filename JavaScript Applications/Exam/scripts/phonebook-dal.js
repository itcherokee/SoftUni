'use strict';
var app = app || {};

app.dal = (function () {
    var APP_ID = 'ebLXNmRgNPSVPLW5ubvFQ0xtREdhenrmpDicv6Rl',
        REST_API_ID = 'h8to8nfoqIVfMcg3wH5CCQizRXgoAMBLnHf9H3Aw',
        APP_URL = 'https://api.parse.com/1/',
        sessionId = '';

    function getSessionId (){
        return sessionStorage.getObject('user').sessionId;
    }

    function ajax(method, resource, data) {
        var contentType = 'application/json',
            url = resource || '',
            payload = data || {},
            headers = {
                'X-Parse-Application-Id': APP_ID,
                'X-Parse-REST-API-Key': REST_API_ID,
                'X-Parse-Session-Token': sessionId
            },
            methodToBeUsed = method || 'GET',
            serviceAddress = APP_URL + url || APP_URL,
            defer = Q.defer();

        $.ajax({
            method: methodToBeUsed,
            url: serviceAddress,
            headers: headers,
            contentType: contentType,
            data: payload,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error)
            }
        });

        return defer.promise;
    }

    function loginUser(data) {
        return ajax('GET', 'login', data);
    }

    function registerUser(data) {
        return ajax('POST', 'users', JSON.stringify(data));
    }

    function editUser(data) {
        return ajax('PUT', 'users', JSON.stringify(data));
    }

    function addPhone(data) {
        sessionId = getSessionId();
        return ajax('POST', 'classes/Phone', JSON.stringify(data));
    }

    function editPhone(id, data) {
        return ajax('PUT', 'classes/Phone/' + id, JSON.stringify(data));
    }

    function deletePhone(id) {
        sessionId = getSessionId();
        return ajax('DELETE', 'classes/Phone/' + id, {});
    }

    function getPhones() {
        sessionId = getSessionId();
        return ajax('GET', 'classes/Phone', {});
    }

    return {
        loginUser: loginUser,
        registerUser: registerUser,
        editUser : editUser,
        addPhone: addPhone,
        editPhone: editPhone,
        deletePhone: deletePhone,
        getPhones: getPhones
    };
}());