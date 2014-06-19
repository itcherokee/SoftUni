(function () {
    "use strict";
    var display = document.getElementsByName('display'),
        buttons = document.getElementsByTagName('button'),
        expression = '',
        zeroAllowed = false,
        operatorAllowed = false;

    function calculate() {
        var result = eval(expression)
        display[0].value = result;
        expression = result;
    }

    function pressedButton() {
        switch (this.value) {
            case "0":
                if (expression[expression.length - 1] !== '' && zeroAllowed === true) {
                    expression += this.value;
                    display[0].value = expression;
                }

                operatorAllowed = false;
                break;
            case "C":
                expression = '';
                display[0].value = '0';
                zeroAllowed = false;
                operatorAllowed = false;
                break;
            case "=":
                if (expression !== '') {
                    calculate();
                    zeroAllowed = true;
                    operatorAllowed = true;
                }

                break;
            case "+":
            case "-":
            case "*":
            case "/":
                if (operatorAllowed) {
                    expression += this.value;
                    display[0].value = expression;
                    zeroAllowed = false;
                    operatorAllowed = false;
                }

                break;
            default:
                zeroAllowed = true;
                operatorAllowed = true;
                expression += this.value;
                display[0].value = expression;
                break;
        }
    }

    var btn;
    for (btn in buttons) {
        buttons[btn].onclick = pressedButton;
    }
}());
