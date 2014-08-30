(function () {
    var anchorTags = document.querySelectorAll('a'),
        index,
        len;

    function detectElement(event) {
        var selectedId = event.target.id,
        divId = selectedId.slice(selectedId.indexOf('-') + 1);
        return document.getElementById('details-' + divId);
    }

    for (index = 0, len = anchorTags.length; index < len; index += 1) {
        anchorTags[index].addEventListener('mouseenter', function (event) {
            var divToShow = detectElement(event);
            divToShow.style.display = 'block';
            divToShow.style.top = event.clientY + 15 + 'px';
            divToShow.style.left = event.clientX + 15 + 'px';
        });
        anchorTags[index].addEventListener('mouseleave', function (event) {
            var divToShow = detectElement(event);
            divToShow.style.display = 'none';
        });
        anchorTags[index].addEventListener('mousemove', function (event) {
            var divToShow = detectElement(event);
            divToShow.style.top = event.clientY + 15 + 'px';
            divToShow.style.left = event.clientX + 15 + 'px';
        });
    }
}());