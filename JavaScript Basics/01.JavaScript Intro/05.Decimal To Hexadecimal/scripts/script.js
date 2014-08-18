var button = document.getElementsByTagName('button');

button[0].onclick = function () {
    alert(parseInt(prompt('Enter decimal number')).toString(16).toUpperCase());
};

