(function () {
    "use strict";

    var button = document.getElementsByTagName('button')[0],
        alert = document.getElementById('alert'),
        divs = document.getElementsByClassName('cell'),
        cells,
        turn,
        MAX_TURNS = 9;

    function isThereAWinner() {
        var winPos = [
            [0, 1, 2],
            [3, 4, 5],
            [6, 7, 8],
            [0, 3, 6],
            [1, 4, 7],
            [2, 5, 8],
            [0, 4, 8],
            [2, 4, 6]],
            player,
            source,
            i,
            j,
            k,
            players = ['o', 'x'];

        for (j = 0; j < 2; j += 1) {
            player = players[j];
            for (i = 0; i < 8; i += 1) {
                if (cells[winPos[i][0]] === player && cells[winPos[i][1]] === player && cells[winPos[i][2]] === player) {
                    for (k = 0; k < 3; k += 1) {
                        source = divs[winPos[i][k]].getElementsByTagName('img');
                        source[0].src = 'images/' + player + 'w.png';
                    }

                    return true;
                }
            }
        }

        return false;
    }

    function clearCellEvents() {
        var i;
        for (i = 0; i < 9; i += 1) {
            divs[i].removeEventListener('click', onCellClick, false);
        }
    }

    function onCellClick() {
        var currentDiv = this,
            winnerFound = false,
            currentCellIndex,
            currentPlayer;
        if (currentDiv.className === 'cell') {
            currentCellIndex = parseInt(currentDiv.id, 10) - 1;
            if (cells[currentCellIndex] === undefined) {
                currentPlayer = turn % 2 === 0 ? 'o' : 'x';
                cells[currentCellIndex] = currentPlayer;
                currentDiv.innerHTML = '<img src="images/' + currentPlayer + '.png"/>';
                turn += 1;
                winnerFound = isThereAWinner();
                if (winnerFound) {
                    alert.innerText = 'Winner is "' + currentPlayer.toUpperCase() + '"';
                    button.innerText = 'START';
                    clearCellEvents();
                }
            }
        }

        if (!winnerFound && turn >= MAX_TURNS) {
            alert.innerText = 'Nobody wins!';
            button.innerText = 'START';
            clearCellEvents();
        }
    }

    function onButtonClick() {
        var child,
            i;

        if (button.innerText === 'START') {
            button.innerText = 'STOP';
            for (i = 0; i < MAX_TURNS; i += 1) {
                divs[i].addEventListener('click', onCellClick, false);
            }
            alert.innerText = 'Playing...';
        } else if (button.innerText === 'STOP') {
            button.innerText = 'START';
            alert.innerText = 'Press "START"';
            clearCellEvents();
        }

        for (i = 0; i < 9; i += 1) {
            child = divs[i].getElementsByTagName('img');
            if (child.length > 0 && child[0] !== undefined) {
                child[0].parentNode.removeChild(child[0]);
            }
        }

        turn = 0;
        cells = [];
    }

    button.addEventListener('click', onButtonClick, false);
}());