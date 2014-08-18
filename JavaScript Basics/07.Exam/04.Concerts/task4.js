function solve(args) {
    var result,
        towns = [],
        concerts = {},
        stadiums = [],
        len,
        index,
        line,
        output,
        indexStad,
        lenStad,
        stad;

    len = args.length;
    for (index = 0; index < len; index += 1) {
        line = args[index].split('|');
        line.forEach(function (el, indx, arr) {
            var current;
            current = el.trim();
            current = '"' + current + '"';
            arr[indx] = current;
        });

        if (towns.indexOf(line[1]) === -1) {
            towns.push(line[1]);
        }

        if (stadiums.indexOf(line[3]) === -1) {
            stadiums.push(line[3]);
        }

        if (concerts[line[1]] === undefined) {
            concerts[line[1]] = {};
        }

        if (concerts[line[1]][line[3]]) {
            if (concerts[line[1]][line[3]].indexOf(line[0]) === -1) {
                concerts[line[1]][line[3]].push(line[0]);
            }
        } else {
            concerts[line[1]][line[3]] = [];
            concerts[line[1]][line[3]].push(line[0]);
        }

        concerts[line[1]][line[3]].sort();
    }

    towns.sort();
    stadiums.sort();
    result = '';
    output = [];
    for (index = 0, len = towns.length; index < len; index += 1) {
        stad = [];
        result = towns[index] + ':{';
        for (indexStad = 0, lenStad = stadiums.length; indexStad < lenStad; indexStad += 1) {
            if (concerts[towns[index]][stadiums[indexStad]]) {
                stad.push(stadiums[indexStad] + ':[' + concerts[towns[index]][stadiums[indexStad]].join(',') + ']');
            }
        }

        result += stad.join(',') + '}';
        output.push(result);
    }

    return '{' + output.join(',') + '}';
}

console.log(solve(['ZZ Top | London | 2-Aug-2014 | Wembley Stadium', 'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium', 'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium', 'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium', 'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium', 'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium', 'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium', 'Helloween | London | 28-Jul-2014 | Wembley Stadium', 'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium', 'Metallica | London | 03-Oct-2014 | Olympic Stadium', 'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium', 'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium']));