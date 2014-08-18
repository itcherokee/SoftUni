(function () {
    "use strict";
    var time,
        hours,
        minutes;
    time = new Date();
    hours = time.getHours();
    minutes = time.getMinutes();
    minutes = minutes < 10 ? '0' + minutes : minutes;
    console.log(hours + ':' + minutes);
}());