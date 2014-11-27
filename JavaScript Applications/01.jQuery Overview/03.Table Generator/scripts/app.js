// Task 3:  Write a script using jQuery that reads a JSON string which contains
// //       information about cars and generates an HTML table.

(function () {
    'use strict';

    function generateTable(data) {
        var MANUFACTURER = 'Manufacturer',
            MODEL = 'Model',
            YEAR = 'Year',
            PRICE = 'Price',
            CLASS = 'Class',
            table,
            row;

        if (data && data.length > 0) {
            table = $('<table>');
            row = $('<tr>').append(
                $('<th>').text(MANUFACTURER),
                $('<th>').text(MODEL),
                $('<th>').text(YEAR),
                $('<th>').text(PRICE),
                $('<th>').text(CLASS)
            );

            table.append(row);

            $.each(data, function (_, value) {
                row = $('<tr>');
                $(value).each(function (key, item) {
                    row.append($('<td>').addClass('wide').text(item[MANUFACTURER.toLowerCase()]),
                        $('<td>').addClass('wide').text(item[MODEL.toLowerCase()]),
                        $('<td>').addClass('narrow').text(item[YEAR.toLowerCase()]),
                        $('<td>').addClass('narrow').text(item[PRICE.toLowerCase()]),
                        $('<td>').addClass('wide').text(item[CLASS.toLowerCase()]));

                });

                table.append(row);
            });

            return table;
        }
        else {
            throw new Error ('Invalid input data has been provided.');
        }
    }

    $(function () {
        var jsonInput = $('#json-input');

        jsonInput.val('[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},' +
            '{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
            '{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]');

        $('button').on('click',function(){
            var json = $('#json-input').val();
            if (json){
                var source = JSON.parse(json);
                var generatedTable = generateTable(source);
                $('#result').append(generatedTable);
            } else {
                $('#result').text('');
                $('#error').text('Error: Invalid json string provided.')
            }

        });
    })
}());