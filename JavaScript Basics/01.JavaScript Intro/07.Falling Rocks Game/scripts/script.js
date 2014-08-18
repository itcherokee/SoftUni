(function () {
    'use strict';
    var board = document.getElementById('board'),
        scoreElement = document.getElementById('score'),
        PLAYER_SIZE = 50,
        ENEMY_SIZE = 15,
        MAX_ENEMIES_IN_A_ROW = 3,
        left = -1,
        right = 1,
        down = 1,
        stop = 0,
        objects = [],
        width = board.clientWidth,
        height = board.clientHeight,
        type = {rock: 'rock', player: 'player'},
        score = 0,
        timePassed = 0,
        timer;

    function generateNumberInRange(min, max) {
        return (Math.random() * (max - min) + min) | 0;
    }

    function initBoard() {
        var i, len;
        for (i = 0, len = objects.length; i < len; i += 1) {
            objects[i].object.parentNode.removeChild(objects[i].object);
        }

        objects = [];
        score = 0;
    }

    function checkForCollision() {
        var i, len, result = false;
        for (i = 1, len = objects.length; i < len; i += 1) {
            if (objects[i].y + objects[i].size[1] >= height - objects[0].size[1] + 5) {
                if (objects[i].x + objects[i].size[0] > objects[0].x + 10 && objects[i].x < objects[0].x + objects[0].size[0] - 10) {
                    result = true;
                    break;
                }
            }
        }

        return result;
    }

    function GameItem(type, x, y, image, size, speed, step) {
        var moveDirection = {left: left, stop: stop, right: right, down: down};
        this.object = null;
        this.x = x;
        this.y = y;
        this.speed = speed;
        this.step = moveDirection[step];
        this.size = [size, size];
        this.image = image;
        this.type = type;
        this.createItem = function () {
            var item = document.createElement('img');
            item.style.top = this.y + 'px';
            item.style.left = this.x + 'px';
            item.width = this.size[0];
            item.src = this.image;
            this.object = item;
        };
        this.update = function () {
            switch (this.type) {
                case 'player':
                    if (this.step === left || this.step === right) {
                        if ((this.step === left && this.x > 5) || (this.step === right && this.x + this.size[0] + 5 < width)) {
                            this.x += this.step * this.speed;
                            this.object.style.left = this.x + 'px';
                        }
                    }

                    break;
                case 'rock':
                    this.y = this.y + speed;
                    this.object.style.top = this.y + 'px';
                    break;
            }
        };

        this.createItem();
    }

    function enrollEnemies(numberOfEnemies) {
        var i, j, len, x, isColliding, enemySize, jellyImage;
        for (i = 0; i < numberOfEnemies; i += 1) {
            while (true) {
                enemySize = generateNumberInRange(ENEMY_SIZE, ENEMY_SIZE * 2);
                x = generateNumberInRange(2, width - enemySize - 2);
                isColliding = false;
                for (j = 1, len = objects.length; j < len; j += 1) {
                    if (x + enemySize > objects[j].x && x < objects[j].x + objects[j].size[0] && objects[j].y === 5) {
                        isColliding = true;
                        x = 0;
                        break;
                    }
                }

                if (!isColliding) {
                    break;
                }
            }

            jellyImage = generateNumberInRange(0, 2) > 0 ? 'j1.gif' : 'j2.gif';
            objects.push(new GameItem(type['rock'], x, 5, 'images/' + jellyImage, enemySize, 5, down));
            board.appendChild(objects[objects.length - 1].object);
        }
    }

    function enrollPlayer() {
        objects.push(new GameItem(type['player'], width / 2 - PLAYER_SIZE / 2, height - PLAYER_SIZE - 5,
            'images/spongebob.gif', PLAYER_SIZE, 13, stop));
        board.appendChild(objects[0].object);
        var game = document.getElementsByTagName('body')[0];
        game.onkeydown = function (e) {
            e = e || window.event;
            if (e.keyCode == '37') {
                objects[0].step = left;
            } else if (e.keyCode == '39') {
                objects[0].step = right;
            }
        };

        game.onkeyup = function (e) {
            e = e || window.event;
            if (e.keyCode == '37' || e.keyCode == '39') {
                objects[0].step = stop;
            }
        };
    }

    function run() {
        var i, len, objectsInGame;
        timePassed += 1;
        objectsInGame = [];
        for (i = 0, len = objects.length; i < len; i += 1) {
            objects[i].update();
            if (objects[i].y > height) {
                objects[i].object.parentNode.removeChild(objects[i].object);
                score += 1;
            } else {
                objectsInGame.push(objects[i]);
            }
        }

        objects = objectsInGame;

        // check for collision
        if (checkForCollision()) {
            objects[0].object.src = 'images/rip.png';
            clearInterval(timer);
        }

        // update score
        scoreElement.innerText = score;

        // enroll new line of jellyfish
        if (timePassed % 10 === 0) {
            enrollEnemies(generateNumberInRange(0, MAX_ENEMIES_IN_A_ROW));
        }
    }

    function initGame() {
//        initVariables();
        initBoard();
        enrollPlayer();
        enrollEnemies(generateNumberInRange(0, MAX_ENEMIES_IN_A_ROW) || 1);
        timer = setInterval(run, 70);
        run();
    }

    initGame();
}());