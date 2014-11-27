// Task 4:  Create a slideshow using jQuery:
//              •   The slider should have several slides
//              •   Only one slide is visible at a time
//              •   Each slide can contain HTML code
//                  o   It can contain images, forms, divs, headers, links, etc.
//              •   Implement functionality for the visible slide to automatically change to the next one after 5 seconds
//              •   Create buttons for next and previous slide

(function () {
    $(function () {
        var WIDTH = 250,
            content = $('#slider');

        function slide(source, direction, duration){
            var directionTranslation,
                slider = $('#slider').children();

            switch(direction){
                case 'left':
                    directionTranslation = '+';
                    var last = slider.last();
                    source.stop(true,true).animate({
                        "margin-left": directionTranslation + "=250"
                    }, duration, function(){
                        source.prepend(last);
                        source.css({
                            'margin-left': '-=250'
                        });
                    });

                    break;
                case 'right':
                    directionTranslation = '-';
                    var first = slider.first();
                    source.stop(true,true).animate({
                        "margin-left": directionTranslation + "=250"
                    }, duration, function(){
                        source.append(first);
                        source.css({
                            'margin-left': '+=250'
                        });
                    });

                    break;
            }
        }

        content.children().each(function(_,child){
            $(child).addClass('content');
        });

        content.css({
            'margin-left': -(Math.round(content.children().length / 2) * WIDTH)
        });

        setInterval(function(){slide(content, 'right', 500)}, 3000);

        $('button.controls').on('click', function (event) {
            slide(content, event.target.id, 500);
        })
    })
}());