$(function () {
    var QUIZ = 'quiz',
        $content = $('#content'),
        $buttonSubmit = $('button'),
        localRepository = {
            answers: [],
            completed: false
        },
        timer;

    function setTimer() {
        timer = setTimeout(function () {
            alert('Time is over!');
            onSubmit();
        }, 5000);
    }

    function stopTimer() {
        clearTimeout(timer);
    }

    function markCorrectAnswers(repository){
        var radios = $(':radio');
        $(repository).each(function(_, question){
            var correct = radios.filter(function(_, radio){
                return ($(radio).attr('name') == question.questionId) &&
                    ($(radio).data('id') == question.correctAnswerId);
            });
            correct.eq(0).closest('li').addClass('correct');
        });
    }

    // Evaluates the user answers compared to correct answers from repository
    function checkAnswers(repository) {
        var $checked = $(':checked'),
            isAllAnswersAreCorrect = true;
        if ($checked.length === repository.length) {
            $(repository).each(function (_, question) {
                var userAnswer = $checked.filter(function (i, answer) {
                    return question.questionId == $(answer).attr('name');
                });
                if (userAnswer.length) {
                    if (question.correctAnswerId != userAnswer.eq(0).data('id')) {
                        isAllAnswersAreCorrect = false;

                    }
                } else {
                    isAllAnswersAreCorrect = false;
                }
            });
        } else {
            isAllAnswersAreCorrect = false;
        }

        return isAllAnswersAreCorrect;
    }

    // event handler for Submit button as well as for time out event
    function onSubmit() {
        stopTimer();
        markCorrectAnswers(app.repository);
        if (checkAnswers(app.repository)) {
            localRepository.completed = true;
            alert('You answered correct to all questions. CONGRATULATIONS!')
        } else {
            localRepository.completed = false;
            alert('Wrong answers. Correct are marked in green.');
        }

        localStorage.setObject(QUIZ, localRepository);
    }

    // Event handler for radio buttons click
    function onAnswerClick() {
        var $this = $(this),
            currentQuestion = {
                question: $this.attr('name'),
                answer: $this.data('id')
            };

        localRepository.answers = $.grep(localRepository.answers, function (item) {
            return item.question == currentQuestion.question;
        }, true);
        localRepository.answers.push(currentQuestion);
        localStorage.setObject(QUIZ, localRepository);
    }

    // Check localStorage for saved answers and apply them
    function loadAnswers() {
        if (localRepository.answers.length) {
            $.each(localRepository.answers, function (_, item) {
                var radios = $('input[name=' + item.question + ']'),
                    radiosAnswer = radios.filter(function (i, answer) {
                        return $(answer).data('id') == item.answer;
                    });
                radiosAnswer.prop("checked", "checked");
            })
        }
    }

    // Initialize questions/answers representations in DOM and
    // checks does quiz have been already won
    function initializeQuiz(selector, repository) {
        app.drawQuiz(selector, repository);
        localRepository = localStorage.getObject(QUIZ) || localRepository;
        if (localRepository.completed) {
            loadAnswers();
            markCorrectAnswers(app.repository);
            alert('You have completed the Quiz!');
        } else {
            setTimer();
            loadAnswers();
        }
    }

    // Run quiz
    if (!app) {
        throw new Error('General error raised - missing required libs to run application.')
    } else {
        $content.on('click', ':radio', onAnswerClick);
        $buttonSubmit.on('click', onSubmit);
        initializeQuiz($content, app.repository);
    }
});