var app = app || {};
(function (scope) {
    var view = (function () {

        function show(selector, data) {
            var TITLE = 'Title',
                AUTHOR = 'Author',
                ISBN = 'ISBN',
                ID = 'id',
                table,
                row;

            if (data && data.length > 0) {
                $(selector).empty();
                table = $('<table>');
                row = $('<tr>').append(
                    $('<th>').text(TITLE),
                    $('<th>').text(AUTHOR),
                    $('<th>').text(ISBN)
                );

                table.append(row);

                $.each(data, function (_, value) {
                    row = $('<tr>');
                    $(value).each(function (key, item) {
                        row.data('book', item);
                        row.append(
                            $('<td>').text(item[TITLE.toLowerCase()]),
                            $('<td>').text(item[AUTHOR.toLowerCase()]),
                            $('<td>').text(item[ISBN.toLowerCase()]),
                            $('<td>').append($('<button>').data('id', item[ID]).addClass('edit-button').text('Edit')),
                            $('<td>').append($('<button>').data('id', item[ID]).addClass('delete-button').text('X')));
                    });

                    table.append(row);
                });

                $('<tr>').append(
                    $('<td>').append($('<input type="text" id="new-title">').attr('placeholder', 'New book title...')),
                    $('<td>').append($('<input type="text" id="new-author">').attr('placeholder', 'Author...')),
                    $('<td>').append($('<input type="text" id="new-isbn">').attr('placeholder', 'ISBN...')),
                    $('<td colspan="2">').append($('<button>').addClass('new-button').text('Add'))).appendTo(table);

                table.appendTo(selector);
            }
            else {
                throw new Error('Invalid input data has been provided.');
            }
        }

        function editRow(row) {
            var $rowData = row.data('book'),
                newRow = $('<tr>')
                    .data('book', $rowData)
                    .append(
                    $('<td>').append($('<input type="text" id="edit-title">').val($rowData.title)),
                    $('<td>').append($('<input type="text" id="edit-author">').val($rowData.author)),
                    $('<td>').append($('<input type="text" id="edit-isbn">').val($rowData.isbn)),
                    $('<td colspan="2">')
                        .append($('<button>').addClass('save-button').text('Save')));
            $('button').attr('disabled', 'disabled');
            $(row).replaceWith(newRow);
            return newRow;
        }

        return {
            show: show,
            editRow: editRow
        }
    }());

    scope.view = view;
}(app));