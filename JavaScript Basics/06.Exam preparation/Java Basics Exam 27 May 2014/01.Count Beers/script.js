function solve(args) {
    var result,
        stacks = 0,
        beers = 0,
        index,
        row,
        len;

    for (index = 0, len = args.length - 1; index < len; index += 1) {
        row = args[index].split(' ');
        if (row[1] === 'stacks') {
            stacks += +row[0];
        } else if (row[1] === 'beers') {
            beers += +row[0];
        } else {
            break;
        }
    }

    stacks = stacks + ((beers / 20) | 0);
    beers = beers % 20;
    result = stacks + ' stacks + ' + beers + ' beers';


    return result;
}

console.log(solve(['4 stacks', '12 beers', '10 beers', '1 stacks', '1 beers', 'End']));
console.log(solve(['41 beers', '1 stacks', '19 beers', ' End']));


