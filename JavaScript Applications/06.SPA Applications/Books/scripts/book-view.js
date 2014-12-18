var app = app || {};
(function (scope) {
    var view = (function () {

        function show(selector, data) {
            var headers = {
                    title: 'Title',
                    author: 'Author',
                    isbn: 'ISBN',
                    id: 'id'
                },
                table = $('<table>'),
                headerRowTemplate = '<tr><th>{{title}}</th><th>{{author}}</th><th>{{isbn}}</th></tr>',
                rowTemplate = '<tr><td>{{title}}</td><td>{{author}}</td><td>{{isbn}}</td></tr>';

            if (data && data.length > 0) {
                $(selector).empty();
                table.append(Mustache.render(headerRowTemplate, headers));

                $.each(data, function (_, value) {
                    var row = '';
                    $(value).each(function (key, item) {
                        row = $(Mustache.render(rowTemplate, item));
                        row.data('book', item);
                        row.append(
                            $('<td>').append($('<button>').data('id', item.id).addClass('edit-button').text('Edit')),
                            $('<td>').append($('<button>').data('id', item.id).addClass('delete-button').text('X')));
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