function solve(args) {
    var input,
        maxOddEven = 0,
        len,
        index,
        count,
        expected;


    input = args[0].split(/[\(\)\s]+/g).filter(function (a) {
        return !(a == "")
    });

    len = input.length;
    if (len === 1) {
        return '1';
    }

    input.forEach(function (el, indx, arr) {
        if (+el !== 0) {
            arr[indx] = (+el % 2 !== 0);
        }
    });

    count = 1;
    expected = input[0] !== '0' ? !input[0] : '0';

    for (index = 1; index < len; index += 1) {
        if (expected === '0' && input[index] !== '0') {
            expected = input[index];
        }


        if (input[index] === expected || input[index] === '0') {
            count += 1;
            if (expected !== '0') {
                expected = !expected;
            }
        } else {
            if (count > maxOddEven) {
                maxOddEven = count;

            }

            // hack to solve problem when last number in a sequence is '0'
            // it is hack as we modify the index of for-loop, which is not good
            if(index > 0 && input[index-1] === '0'){
                expected = '0';
                index -= 1;
            } else {
                expected = !input[index];
            }

            count = 1;
        }
    }

    if (count > maxOddEven) {
        maxOddEven = count;
    }

    return maxOddEven + "";
}
//
console.log(solve(['(3) (22) (-18) (55) (44) (3) (21)']));
console.log(solve(['(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)']));
console.log(solve(['  ( 2 )  ( 33 ) (1) (4)   (  -1  ) ']));
console.log(solve(['(102)(103)(0)(105)  (107)(1)']));
console.log(solve(['(2) (2) (2) (2) (2)']));
console.log(solve(['(0) (0) (0) (0) (0)']));
console.log(solve(['(0) (0) (5) (0) (0) (5)']));

// problem with the last number in a sequence to be '0'
console.log(solve(['(102)(103)(0)(106)  (107)(108)(109)']));