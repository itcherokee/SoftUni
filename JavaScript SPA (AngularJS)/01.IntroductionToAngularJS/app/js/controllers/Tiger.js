'use strict';

angular.module('introToAngular')
    .controller('Tiger', [function () {
        this.data = {
            'Name': 'Pesho',
            'Born': 'Asia',
            'BirthDate': 2006,
            'Live': 'Sofia Zoo',
            'Picture': 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg'
        };

        this.styleHeading = {
            fontWeight: 'bold',
            'text-align' : 'center'
        };

        this.styleBox = {
            'background-color': '#CACACA',
            display: 'inline-block',
            float: 'left',
            padding: '10px',
            fontFamily : 'Helvetica, Arial, Tahoma, sans-serif'
        };

        this.styleStrong = {
            fontWeight: 'bold',
            'line-height' : '160%'
        };

        this.styleImg = {
            width: '200px',
            margin: '10px',
            float: 'left'
        }
    }]);