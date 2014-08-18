(function () {
	"use strict";
	var index,
        len,
        tasks = document.getElementsByName('tasks'),
        buttons = document.getElementsByTagName('button'),
        spans = document.getElementsByTagName('span');

	// Hides all tasks summaries
	function hideSummary() {
		var index,
            last;
		for (index = 0, last = spans.length; index < last; index++) {
			spans[index].style.display = "none";
		}
	}
	
	// Event handler for Radio buttons - shows currently selected task summary
	function attachRadioHandler(i) {
		var currentSpan = spans[i];
		function handler() {
			hideSummary();
			jsConsole.clean();
			selectedTask =
			currentSpan.style.display = "inline";
		}

		return handler;
	}

	var selectedTask = "";

	// Identify currently selected task
	function currentTask() {
		var index,
            last,
            currentTaskIndex = -1;
		for (index = 0, last = tasks.length; index < last; index++) {
			if (tasks[index].checked) {
				currentTaskIndex = index;
				break;
			}
		}

		return currentTaskIndex;
	}

	// Event handler for Show JavaScript button - select currently selected task and opens new window with code
	function attachViewButtonHandler() {
		var taskFile = "tasks/task" + (currentTask() + 1) + ".js";
		window.open(taskFile, "", 'left=100, top=100, width=700, height=600, menubar=no, status=no, channelmode=no');
	}

	// Run button handler - used to output to jsConsole the result
	function attachRunButtonHandler() {
		switch (currentTask()) {
			case 0:
				jsConsole.writeLine(taskOne());
				break;
			case 1:
				jsConsole.writeLine(taskTwo());
				break;
			case 2:
				jsConsole.writeLine(taskThree());
				break;
			case 3:
				jsConsole.writeLine(taskFour());
				break;
            case 4:
                jsConsole.writeLine(taskFive());
                break;
            case 5:
                jsConsole.writeLine(taskSix());
                break;
            case 6:
                jsConsole.writeLine(taskSeven());
                break;
            case 7:
                jsConsole.writeLine(taskEight());
                break;
            case 8:
                jsConsole.writeLine(taskNine());
                break;
            case 9:
                jsConsole.writeLine(taskTen());
                break;
            case 10:
                jsConsole.writeLine(taskEleven());
                break;
            case 11:
                jsConsole.writeLine(taskTwelve());
                break;
            case 12:
                jsConsole.writeLine(taskThirteen());
                break;
            case 13:
                jsConsole.writeLine(taskFourteen());
                break;
            case 14:
                jsConsole.writeLine(taskFifteen());
                break;
            case 15:
                jsConsole.writeLine(taskSixteen());
                break;
            case 16:
                jsConsole.writeLine(taskSeventeen());
                break;
            case 17:
                jsConsole.writeLine(taskEighteen());
                break;
            case 18:
                jsConsole.writeLine(taskNineteen());
                break;
			default:
		}
	}

	// Attach events to each radio button and two normal buttons
	for (index = 0, len = tasks.length; index < len; index+=1) {
		tasks[index].addEventListener("click", attachRadioHandler(index), false);
	}

	buttons[0].addEventListener("click", attachRunButtonHandler, false);
	buttons[1].addEventListener("click", attachViewButtonHandler, false);
}());