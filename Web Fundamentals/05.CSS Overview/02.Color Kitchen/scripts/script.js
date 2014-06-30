(function () {
    var anchors = document.getElementsByTagName('a');
    for (var i = 0, len = anchors.length; i < len; i += 1) {
        var indexA = anchors[i].href.indexOf('HSLHSV');
        var indexB = anchors[i].href.indexOf('lorem');
        if (indexA > -1) {
            anchors[i].href = anchors[i].href.slice(0,indexA) + '#' + anchors[i].href.slice(indexA);
        }

        if (indexB > -1) {
            anchors[i].href = anchors[i].href.slice(0,indexB) + '#' + anchors[i].href.slice(indexB);
        }
    }
}());
