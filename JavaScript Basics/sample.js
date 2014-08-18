function test(element, index, arr) {
    arr[index] = e.split('').reverse().join('');
}

function reverseWordsInString(str) {
    var arrWords = str.split(' ');
    arrWords.forEach(function (element, index, arr) {
        arr[index] = arr[index].split('').reverse().join('');
    });
    //console.log("hello".split('').reverse().join(''));
    console.log(arrWords);

}

reverseWordsInString("Hello, how are you.");