function solve(args) {
    var result = '',
        products = [],
        customers = [],
        orders = {},
        lenProducts,
        lenCustomers,
        lenOrders,
        indexProducts,
        indexCustomers,
        customerProduct,
        index,
        line,
        output = [];

    lenOrders = +args[0];
    for (index = 1; index <= lenOrders; index += 1) {
        line = args[index].split(' ');
        if (customers.indexOf(line[0]) === -1) {
            customers.push(line[0]);
        }

        if (products.indexOf(line[2]) === -1) {
            products.push(line[2]);
        }

        if (!orders[line[0]]) {
             orders[line[0]] = {};
        }

        if(!orders[line[0]][line[2]]){
            orders[line[0]][line[2]] = +line[1];
        } else {
            orders[line[0]][line[2]] += +line[1];
        }
    }

    customers.sort();

    // output assembling
    for (indexProducts = 0, lenProducts = products.length; indexProducts < lenProducts; indexProducts += 1) {
        result = products[indexProducts] + ': ';
        customerProduct = [];
        for (indexCustomers = 0, lenCustomers = customers.length; indexCustomers < lenCustomers; indexCustomers += 1) {

            if (orders[customers[indexCustomers]]) {
                if(orders[customers[indexCustomers]][products[indexProducts]]){
                    customerProduct.push([customers[indexCustomers]] + ' ' + orders[customers[indexCustomers]][products[indexProducts]]);
                }
            }
        }

        result += customerProduct.join(', ');

        output.push(result);
    }

    return output.join('\n');
}

//console.log(solve(['8', 'steve 8 apples', 'maria 3 bananas', 'kiro 3 bananas', 'kiro 9 apples', 'maria 2 apples', 'steve 4 apples', 'kiro 1 bananas', 'kiro 1 apples']));
console.log(solve(['7','bob 3 whiskeys','kiro 1 beers','mimi 2 beers','alex 4 beers','alex 1 beers','kiro 1 vodkas','bob 10 beers']));