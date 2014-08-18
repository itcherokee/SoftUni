function solve(args) {
    var input = [],
        result = [],
        index,
        len,
        row,
        rowLen,
        col,
        colLen,
        output;

    len = args.length;
    for (index = 0; index < len; index += 1) {
        input[index] = args[index].split('');
    }

    for (row = 0, rowLen = input.length; row<rowLen; row +=1){
        var newRow = [];
        for(col = 0 , colLen = input[row].length; col < colLen; col += 1){
            newRow.push('');
        }

        result.push(newRow);
    }


    var char;
    rowLen = input.length;
    for (row = rowLen-1;  row > 0; row-=1) {
        for (col = 0, colLen = input[row].length; col < colLen-2; col += 1) {
            char = input[row][col];

            // check next 3 are the same
            if(input[row][col] === input[row][col+1] && input[row][col+1] === input[row][col+2] ){

                // check for above row is available
                if (row > 0){

                    // check for length of the above row
                    if (input[row].length-1 > col){

                        // check for same char at top of triangle
                        if(input[row][col] === input[row-1][col+1]){
                            result[row][col] = '*';
                            result[row][col+1] = '*';
                            result[row][col+2] = '*';
                            result[row-1][col+1] = '*';
                        }
                    }
                }
            }


        }
    }

    output = '';
    for (row = 0, rowLen = input.length; row<rowLen; row +=1){
        for(col = 0 , colLen = input[row].length; col < colLen; col += 1){
            if (result[row][col] === ''){
                result[row][col] = input[row][col];
            }
        }

        output += result[row].join('') + '\n';
    }



    return output;
}

//console.log(solve(['abcdexgh', 'bbbdxxxh', 'abcxxxxx']));
//console.log(solve(['aa','aaa','aaaa','aaaaa']));
//console.log(solve(['ax','xxx','b','bbb','bbbb']));
console.log(solve(['dffdsgyefg','ffffeyeee','jbfffays','dagfffdsss','dfdfa','dadaaadddf','sdaaaaa','daaaaaaasf']));