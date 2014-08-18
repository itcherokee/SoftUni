function solve(args) {
    var input,
        word = [],

        result = '',
        index,
        len,
        words = [],
        totalLetters = 0,
        count = 0,
        letterIndex,
        newPosition;

    input = args[0].split(' ');
    len = input.length;
    for (index = 0; index < len; index += 1) {
        words.push(input[index].split(''));
        totalLetters += input[index].length;
    }

    // create word for encryption
    count = totalLetters;
    while (count > 0) {
        for (index = 0; index < len; index += 1) {
            if (words[index].length > 0) {
                word.push(words[index].splice(-1, 1)[0]);
                count -= 1;
            }
        }
    }

//    var before,afterRemove, afterInsert;
    for (index = 0; index < totalLetters; index += 1) {
        // find current index letter number
        letterIndex = word[index][0].toUpperCase().charCodeAt(0) - 64;

        // count new position
        // nmtuahFxgeir     n=14 t=20  14 % 12 = 2; ->  mtnuahFxgeir     20 % 12 = 8  -> mnuahFxgetir;  21%11=10 -> mnahFxgetiru

        newPosition = letterIndex % totalLetters;
//         before = word.join();
        if (index + newPosition  >= totalLetters) {
            newPosition = index + newPosition - totalLetters ;
        } else {
            newPosition = index + newPosition;
        }
        var temp = word.splice(index, 1);
//         afterRemove = word.join();
        word.splice(newPosition, 0, temp[0]);
//        afterInsert = word.join();
    }

    for (index = 0; index < totalLetters; index += 1) {
        result += word[index][0];
    }

    return result;
}

console.log(solve(['Fun exam right']));
console.log(solve(['Hi exam']));