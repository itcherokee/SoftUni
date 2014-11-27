(function(){
    var messageBox = $('#message-box').messageBox();
    $('#lucky').on('click',function(){
        messageBox.success($(this).text());
    });
    $('#awful').on('click',function(){
        messageBox.error($(this).text());
    })
}());