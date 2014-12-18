$(function () {

    var sessionCounter = parseInt(sessionStorage.getItem('sessionCounter')) || 0;
    var totalVisits = parseInt(localStorage.getItem('total')) || 0;

    var board = $('#info-field');
    var $nameWrapper = $('div').attr('id','name');
    var name = localStorage.getItem('name');
    sessionCounter += 1;
    totalVisits += 1;
    if (name) {
        $nameWrapper.text('Greeting ' + localStorage.getItem('name'));
    } else {

        $('<input>').attr('type', 'text').attr('id', 'name').appendTo($nameWrapper);
        $('<button>').text('Welcome').attr('id','name-button').appendTo($nameWrapper);
        $nameWrapper.on('click', $('#name-button'), function(){
            localStorage.setItem('name', $nameWrapper.find('#name').val());
        });
    }
    $('<div>').text('Session counter:' + sessionCounter).appendTo($nameWrapper);
    $('<div>').text('Total  visits count:' + totalVisits).appendTo($nameWrapper);
    $nameWrapper.appendTo(board);
    sessionStorage.setItem('sessionCounter', sessionCounter);
    localStorage.setItem('total', totalVisits);
});