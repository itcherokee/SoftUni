(function () {
    'use strict';
    var board = document.getElementById('board'),
        scoreElement = document.getElementById('score'),
        score,
        matrix;

    function generateNumberInRange(min, max) {
        return (Math.random() * (max - min) + min) | 0;
    }

    var element = function (){

    }

    function initBoard() {
        var i, len;
//        for (i = 0, len = objects.length; i < len; i += 1) {
//            objects[i].object.parentNode.removeChild(objects[i].object);
//        }

//        objects = [];
        matrix = [];
        score = 0;
    }




    function run() {

    }

    function initGame() {
        initBoard();

       //timer = setInterval(run, 70);
        //run();
    }

    initGame();
}());