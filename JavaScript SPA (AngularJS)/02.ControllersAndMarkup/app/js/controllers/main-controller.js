'use strict';

angular.module('CtrlAndMarkup').controller('MainController', ['dataService', function (dataService) {
    var self = this;
    this.videoOrder = "title";
    dataService.read()
        .then(function(data){
            self.data = data;
        }, function(error){
            alert('problem!')
        });

}]);