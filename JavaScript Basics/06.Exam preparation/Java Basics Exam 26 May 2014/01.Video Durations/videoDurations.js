function solve(args) {
    var hours = 0,
        minutes = 0,
        index,
        row,
        len;

    for (index = 0, len = args.length - 1; index < len; index += 1) {
        row = args[index].split(':');
        hours += +row[0];
        minutes += +row[1];
    }

    hours += Math.floor(minutes / 60);
    minutes = minutes % 60;


    return hours + ':' + (minutes < 10 ? '0' + minutes : minutes);
}

console.log(solve(['1:40', '2:25', '17:35', '0:01', '2:57', 'End']));
console.log(solve(['0:02', '0:59', 'End']));
console.log(solve(['0:00', '0:59', '0:01', 'End']));
console.log(solve(['5:55', '4:44', '3:33', '1:11', 'End']));
console.log(solve(['1:03', 'End']));