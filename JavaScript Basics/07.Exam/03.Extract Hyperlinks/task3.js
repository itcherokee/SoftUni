function solve(args) {
    var result = '',
        aIsFound = 0,
        hrefIsFound,
        input,
        indexOfA,
        indexOfHref,
        currentIndex,
        closingIsFound,
        indexOfClosing,
        indexOfStart,
        indexOfEnd,
        separatorChar;

    input = args.join('');
    currentIndex = 0;
    while (input.indexOf('<a', currentIndex) !== -1) {
        indexOfA = input.indexOf('<a', currentIndex);
        currentIndex += 1;
        aIsFound = indexOfA !== -1;
        // search of href + checks
        indexOfClosing = input.indexOf('>', indexOfA);
        closingIsFound = indexOfClosing !== -1;
        var isNotRealHref = true;
        var internalIndex = indexOfA;
        while (isNotRealHref) {
            indexOfHref = input.indexOf('href', internalIndex);
            hrefIsFound = indexOfHref !== -1;
            if (hrefIsFound) {
                var possibleQuotationSingle = input.lastIndexOf("'", indexOfHref);
                var possibleQuotationDouble = input.lastIndexOf('"', indexOfHref);
                if ((indexOfA < possibleQuotationSingle && possibleQuotationSingle !== -1) || (indexOfA < possibleQuotationDouble && possibleQuotationDouble !== -1)) {
                    var singleQuotation = 0, doubleQuotation = 0;
                    for (var i = indexOfA, l = indexOfHref; i < l; i += 1) {
                        if (input[i] === '"') {
                            doubleQuotation += 1
                        }
                        if (input[i] === "'") {
                            singleQuotation += 1
                        }
                    }

                    if (singleQuotation % 2 !== 0 || doubleQuotation % 2 !== 0) {
                        internalIndex = indexOfHref + 1;

                    }
                    else {
                        isNotRealHref = false;
                    }
                }
                else {
                    isNotRealHref = false;
                }
            }
        }

        if (closingIsFound && hrefIsFound && indexOfClosing > indexOfHref) {
            // extract content
            var tempStartIndexOne = input.indexOf("'", indexOfHref);
            indexOfStart = input.indexOf('"', indexOfHref);
            if (tempStartIndexOne !== -1 && tempStartIndexOne < indexOfStart || indexOfStart === -1) {
                indexOfStart = tempStartIndexOne;
                separatorChar = "'";
            } else {
                separatorChar = '"';
            }

            indexOfEnd = input.indexOf(separatorChar, indexOfStart + 1);
            result += input.substring(indexOfStart + 1, indexOfEnd) + '\n'
        }
        currentIndex = indexOfClosing;
    }


    return result;
}

//console.log(solve(['<a href="http://softuni.bg" class="new"></a>', '<a href="http://aa.bg" class="new"></a>', '<a href="http://vv.bg" class="new"></a>', '<a href="http://softuni.bg" class="new"></a>', '<a href="http://ggg.bg" class="new"></a>']));
//console.log(solve(['<p>This text has no links</p>']));
//console.log(solve(['<li><a class="href"    onclick="go()" href= "#">Forum</a></li>        <li><a id="js" href =        "javascript:alert(\'hi\')" class="new">click</a></li>']));


//</head>    <body>    <ul>        <li><a id='nakov' href =        'http://www.nakov.com' class='new'>nak</a></li></ul>    <a href="#"></a>    <a id="href">href='fake'<img src='http://abv.bg/i.gif'    alt='abv'/></a><a href="#">&lt;a href='hello'&gt;</a>    <!-- This code is commented:      <a href="#commented">commentex hyperlink</a> --></body>']));


console.log(solve(['<!DOCTYPE html>', '<html>', '<head>', '<title>Hyperlinks</title>', '<link href="theme.css" rel="stylesheet" />',
    '</head>',
    '<body>',
    '<ul><li><a   href="/"  id="home">Home</a></li><li><a',
    'class="selected" href="/courses">Courses</a>',
    '</li><li><a href =',
    '\'/forum\' >Forum</a></li><li><a class="href"',
    'onclick="go()" href= "#">Forum</a></li>',
    '<li><a id="js" href =',
    '"javascript:alert(\'hi\')" class="new">click</a></li>',
    '<li><a id=\'nakov\' href =',
    '\'http://www.nakov.com\' class=\'new\'>nak</a></li></ul>',
    '<a href="#"></a>',
    '<a id="href">href=\'fake\'<img src=\'http://abv.bg/i.gif\'',
    'alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>',
    '<!-- This code is commented:',
    '<a href="#commented">commentex hyperlink</a> -->',
    '</body>']))