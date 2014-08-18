function solve(args) {
    var result = [],
        len = parseInt(args[1]),
        index = parseInt(args[0]),
        line,
        square,
        isFib,
        fiboNumbers;

    function generateFibonacci(n) {
        var result = [0,1,1],
            len,
            current;

        current = 1;
        while (current <= n) {
            len = result.length;
            current = result[len - 1] + result[len - 2];
            result.push(current);
        }

        return result;
    }

    fiboNumbers = generateFibonacci(1000000);
    result.push('<table>');
    result.push('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
    for (index; index <= len; index += 1) {
        // isFib = isPerfectSquare(5 * index * index + 4) || isPerfectSquare(5 * index * index - 4);
        isFib = fiboNumbers.indexOf(index) !== -1 ? "yes" : "no";
        square = Math.pow(index, 2);
        line = '<tr><td>' + index + '</td><td>' + square + '</td><td>' + isFib + '</td></tr>';
        result.push(line);
    }

    result.push('</table>');
    return result.join('\n');
}

console.log(solve(['2', '6']));
//console.log(solve(['55', '56']));
//console.log(solve(['999999', '1000000']));
//console.log(solve(['0', '0']));
