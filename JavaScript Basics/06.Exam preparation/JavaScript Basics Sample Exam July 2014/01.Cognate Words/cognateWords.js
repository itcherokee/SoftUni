function solve(args) {
    var input,
        result = [],
        len,
        i, j , k,
        cogWord;

    input = args[0].match(/[a-zA-Z]*/g);
    input = input.filter(function (a) {
        return a !== ''
    });

    len = input.length;
    if (len < 3) {
        return 'No';
    }

    for (i = 0; i < len; i += 1) {
        for (j = 0; j < len; j += 1) {
            for (k = 0; k < len; k += 1) {
                if (i !== j && j !== k && i !== k) {
                    if (input[i] + input[j] === input[k]) {
                        cogWord = input[i] + '|' + input[j] + '=' + input[k];
                        if (result.indexOf(cogWord) === -1) {
                            result.push(cogWord);
                        }
                    }

                }
            }
        }
    }

    if (result.length < 1) {
        return 'No';
    }

    return result.join('\n');
}

console.log(solve(['java..?|basics/*-+=javabasics']));
console.log(solve(['Hi, Hi, Hihi']));
console.log(solve(['Uni(lo,.ve=I love SoftUni (Soft)']));
console.log(solve(['a a aa a']));
console.log(solve(['x a ab b aba a hello+java a b aaaaa']));
console.log(solve(['aa bb bbaa']));
console.log(solve(['ho hoho']));