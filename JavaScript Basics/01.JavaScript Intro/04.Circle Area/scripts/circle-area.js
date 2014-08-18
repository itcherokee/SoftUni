var button = document.getElementsByTagName('button');

button[0].onclick = function () {
    var results = document.getElementById('results');
    var radius = prompt('Enter radius');
    results.innerHTML = results.innerHTML + '<br/>r = ' + radius + '; area = ' + calcCircleArea(radius);
};

function calcCircleArea(radius) {
    return Math.PI * radius * radius;
};