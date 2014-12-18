// Task 2:  You are given an array of books. Using Underscore.js, perform the following operations:
//          • Group all books by language and sort them by author (if two books have the same author, sort by price)
//          • Get the average book price for each author
//          • Get all books in English or German, with price below 30.00, and group them by author

$(function () {
    var books = [
            {"book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "34,24", "language": "French"},
            {"book": "The Great Gatsby", "author": "F. Scott Fitzgerald", "price": "39,26", "language": "English"},
            {"book": "Nineteen Eighty-Four", "author": "George Orwell", "price": "15,39", "language": "English"},
            {"book": "Ulysses", "author": "James Joyce", "price": "23,26", "language": "German"},
            {"book": "Lolita", "author": "Vladimir Nabokov", "price": "14,19", "language": "German"},
            {"book": "Catch-22", "author": "Joseph Heller", "price": "47,89", "language": "German"},
            {"book": "The Catcher in the Rye", "author": "J. D. Salinger", "price": "25,16", "language": "English"},
            {"book": "Beloved", "author": "Toni Morrison", "price": "48,61", "language": "French"},
            {"book": "Of Mice and Men", "author": "John Steinbeck", "price": "29,81", "language": "Bulgarian"},
            {"book": "Animal Farm", "author": "George Orwell", "price": "38,42", "language": "English"},
            {"book": "Finnegans Wake", "author": "James Joyce", "price": "29,59", "language": "English"},
            {"book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "42,94", "language": "English"}
        ],
        templateLanguage = '<dd><strong>Author:</strong> {{author}}, <strong>Title:</strong> {{book}}</dd>',
        templateAuthors = '<dd> <strong>Title:</strong> {{book}}, <strong>Language:</strong> {{language}}, <strong>Price:</strong> ${{price}}</dd>',
        authors,
        selector;

    // Group all books by language and sort them by author (if two books have the same author, sort by price)
    authors = _.groupBy(books, 'language');
    selector = $('#group-by-language-and-sort-by-author');
    _.each(authors, function (language, index) {
        language.sort(function (x, y) {
            var firstAuthor = x.author;
            var secondAuthor = y.author;
            if (firstAuthor !== secondAuthor) {
                return compare(firstAuthor, secondAuthor);
            }
            return compare(x.price, y.price);
        });

        var list = $('<dl>');
        $('<dt>').html('<strong>' + index.toUpperCase() + ':</strong>').appendTo(list);
        _.each(language, function (book) {
            $(Mustache.render(templateLanguage, book)).appendTo(list);
        });
        selector.append(list);

    });

    function compare(x, y) {
        if (x === y) {
            return 0;
        }
        return x > y ? 1 : -1;
    }

    // Get the average book price for each author
    authors = _.groupBy(books, 'author');
    _.each(authors, function (books, author) {
        var bookPrices = _.reduce(books, function (total, book) {
            return total + parseFloat(book.price);
        }, 0);

        $('#average-book-price')
            .append($('<li>')
                .html('<strong>Author:</strong> ' + author +
                    ', <strong>Average price:</strong> $' + (bookPrices / books.length).toFixed(2)));

    });

    // Get all books in English or German, with price below 30.00, and group them by author
    authors = _.groupBy(_.filter(books, function (book) {
        return (book.language === 'German' || book.language === 'English') && parseFloat(book.price) < 30.00;
    }), 'author');

    selector = $('#all-books-price-below');
    _.each(authors, function (books, index) {
        var list = $('<dl>');
        $('<dt>').html('<strong>' + index.toUpperCase() + ':</strong>').appendTo(list);
        _.each(books, function (book) {
            $(Mustache.render(templateAuthors, book)).appendTo(list);
        });
        selector.append(list);

    });


});