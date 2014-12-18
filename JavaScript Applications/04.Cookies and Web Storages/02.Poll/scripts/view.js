var app = app || {};
(function (scope) {
    function buildQuestion(data) {
        var $question;
        var $answers;

        if (data){
            $question = $('<div>').addClass('question').text(data.question);
            $answers = $('<ul>');
            $.each(data.answers, function(id, answer){
                var $radio = $('<input type="radio" />').attr('name', data.questionId).attr('data-id',++id).val(answer.text);
                $('<li>').text(answer.text).prepend($radio).appendTo($answers);
            });

            $answers.appendTo($question);
            return $question;
        } else {
            throw new Error ('No data provided.');
        }
    }

    scope.drawQuiz = function drawQuiz(selector, repository) {
        var $questions = $('<div>');
        if (repository.length){
            $(repository).each(function(i,question){
                $questions.append(buildQuestion(question));
            });

            $questions.appendTo(selector);
        } else {
            throw new Error('NO content provided.');
        }
    }
}(app));
