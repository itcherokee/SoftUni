function solve(args) {
    var result,
        users = [],
        transmision = {},
        len = +args[0],
        index,
        line = [],
        user,
        ip;

    for (index = 1; index <= len; index += 1) {
        line = args[index].split(' ');
        user = args[index].match(/([A-Za-z]+)/g).join(' ');
        ip = args[index].match(/\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b/g)[0];
        if (users.indexOf(user) === -1) {
            users.push(user);
        }

        if (transmision[user]) {
            transmision[user]['total'] += parseInt(line[line.length-1]);
            if (transmision[user].ip.indexOf(ip) === -1) {
                transmision[user].ip.push(ip);
            }
        } else {
            transmision[user] = {};
            transmision[user]['total'] = parseInt(line[line.length-1]);
            transmision[user].ip = [];
            transmision[user].ip.push(ip);
        }
    }

    users.sort();
    for (user in transmision) {
        transmision[user].ip.sort(function (a, b) {
            a = +(a.split('.').join(''));
            b = +(b.split('.').join(''));
            return a - b;
        });
    }

    result = [];
    for (index = 0, len = users.length; index < len; index += 1) {
        result.push(users[index] + ': ' + transmision[users[index]].total +
            ' [' + transmision[users[index]].ip.join(', ') + ']');
    }

    return result.join('\n');
}


console.log(solve(['7','192.168.0.11 peter 33','10.10.17.33 alex 12','10.10.17.35 peter 30','10.10.17.34 peter 120','10.10.17.34 peter 120','212.50.118.81 alex 46','212.50.118.81 alex 4']));
console.log(solve(['2','84.238.140.178 nakov 25','84.238.140.178 nakov 35']));
//console.log(solve(['3', '0.238.0.178 nakov hakov takkov 25', '0.0.0.178 nakov 35', '10.10.10.178 nakov 35']));

