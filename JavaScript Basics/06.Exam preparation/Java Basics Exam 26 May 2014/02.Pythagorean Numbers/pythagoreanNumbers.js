function solve(args) {
    var result = [],
        index,
        len = args[0],
        i,
        j,
        k,
        numbers = [],
        input = [],
        all = [];

    if (len < 3) {
        return 'No';
    }

    // input
    for (index = 1; index <= len; index += 1) {
        input.push(+args[index]);
    }

    len = input.length;
    for (i = 0; i < len; i += 1) {
        for (j = 0; j < len; j += 1) {
            for (k = 0; k < len; k += 1) {
//                if (i !== j && i !== k && j !== k) {
                    all.push([input[i], input[j], input[k]]);
//                }
            }
        }
    }

    for (index = 0, len = all.length; index < len; index += 1) {
        if (all[index][0] <= all[index][1]) {
            if (all[index][0] * all[index][0] + all[index][1] * all[index][1] === all[index][2] * all[index][2]) {
                numbers.push([all[index][0], all[index][1], all[index][2]]);
            }
        }
    }

    if (numbers.length < 1) {
        return 'No';
    }

    for (index = 0, len = numbers.length; index < len; index += 1) {
        result.push(numbers[index][0] + '*' + numbers[index][0] + ' + ' +
            numbers[index][1] + '*' + numbers[index][1] + ' = ' +
            numbers[index][2] + '*' + numbers[index][2]);
    }


    return result.join('\n');
}

console.log(solve(['8','41','5','9','12','4','13','40','3']));
//console.log(solve(['5','3','12','5','0','4']));
//console.log(solve(['3','10','20','30']))