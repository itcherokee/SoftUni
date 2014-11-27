$(function () {
        var headers = {
                "X-Parse-Application-Id": "7o3oacwrwSthfqaolXW6QkHimHUBQoL0Vlc2kiA4",
                "X-Parse-REST-API-Key": "k7HiHcAIZjtdjg2wMUPaBGKZMuymjHLi3Jqi7zDw"
            },
            contentType = 'application/json',
            applicationUrl = 'https://api.parse.com/1/classes/',
            outputCountries = $('#countries'),
            outputTowns = $('#towns-list');

        function getObjects(dataId) { // expects town/country objectId
            var isTown = dataId ? true : false,
                storage = isTown
                    ? 'Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + dataId + '"}}'
                    : 'Country';

            $.ajax({
                type: 'GET',
                headers: headers,
                url: applicationUrl + storage,
                success: function (data) {
                    notify('success');
                    if (isTown) {
                        loadTowns(data);
                    } else {
                        loadCountries(data);
                    }
                },
                error: function () {
                    notify('error');
                }
            });
        }

        function modifyObject(inputData, type) { // expects town/country object(name, objectId & country.objectId); PUT/POST
            var data = { "name": inputData.name },
                isTown = inputData.country ? true : false,
                storage = isTown ? 'Town' : 'Country';

            if (isTown) {
                data["country"] = {"__type": "Pointer", "className": "Country", "objectId": inputData.country.objectId}
            }

            $.ajax({
                type: type,
                headers: headers,
                contentType: contentType,
                data: JSON.stringify(data),
                url: applicationUrl + storage + (type === 'PUT' ? '/' + inputData.objectId : ''),
                success: function () {
                    notify('success');
                    if (isTown) {
                        getObjects(inputData.country.objectId);
                    } else {
                        getObjects();
                    }
                },
                error: function () {
                    notify('error');
                }
            });
        }

        function deleteObject() { // data are as a special data object attached to this
            var data = $(this).data('item'),
                isTown = data.country ? true : false,
                storage = isTown ? 'Town' : 'Country';

            $.ajax({
                type: 'DELETE',
                headers: headers,
                url: applicationUrl + storage + '/' + data.objectId,
                success: function () {
                    notify('success');
                    if (isTown) {
                        initializeTowns($('#towns-section > h1 a').data('item'));
                        getObjects(data.country.objectId);
                    } else {
                        $('#towns-section').children('h1').empty().end().children('ul').empty();
                        getObjects();
                    }
                },
                error: function () {
                    notify('error');
                }
            });
        }

        function loadCountries(restResponse) { // expects object with result field with Array with country objects inside
            if (restResponse.results.length) {
                outputCountries.empty();
                $(restResponse.results).each(function (_, country) {
                    var townLink = $('<span>' + country.name + '</span>&nbsp;');
                    townLink.on('click', country, function (event) {
                        initializeTowns(event.data);
                        getObjects(event.data.objectId);
                    });
                    $('<li>')
                        .append(createLink('edit', country, 'country'))
                        .append(createLink('delete', country, 'country'))
                        .append(townLink)
                        .appendTo(outputCountries);
                });
            } else {
                $('<li>').text('No countries').appendTo(outputCountries);
            }
        }

        function loadTowns(restResponse) { // expects object with result field with Array with town objects inside
            if (restResponse.results.length) {
                outputTowns.empty();
                $(restResponse.results).each(function (_, town) {
                    $('<li>')
                        .append(createLink('edit', town, 'town'))
                        .append(createLink('delete', town, 'town'))
                        .append('<span>' + town.name + '</span>')
                        .appendTo(outputTowns);
                });
            } else {
                $('<li>').text('No towns').appendTo(outputTowns);
            }
        }

        function createLink(action, item, position) {
            var link = $('<a>').attr('href', '#'),
                actionText,
                actionFunc;
            switch (action) {
                case 'add':
                    actionText = 'new';
                    actionFunc = position === 'town' ? addTown : addCountry;
                    break;
                case 'edit':
                    actionText = 'edit';
                    actionFunc = position === 'town' ? editTown : editCountry;
                    break;
                case 'delete':
                    actionText = 'delete';
                    actionFunc = deleteObject;
                    break;
            }

            return link.text(' [' + actionText + '] ').data('item', item).on('click', actionFunc);
        }

        function initializeCountries() {
            var addCountryLink = createLink('add', null, 'country');
            $('#countries-section > h1').append(addCountryLink);
        }

        function initializeTowns(countryData) { // Expects country object
            var addTownLink = createLink('add', countryData, 'town');
            outputTowns.empty();
            $('#towns-section > h1').empty().text('Towns in ' + countryData.name + ' ').append(addTownLink);
        }

        function addCountry() {
            showForm(outputCountries, 'country', 'add');
        }

        function editCountry() {
            showForm($(this), 'country', 'edit');
        }

        function addTown() {
            showForm(outputTowns, 'town', 'add');
        }

        function editTown() {
            showForm($(this), 'town', 'edit');
        }

        function showForm(selector, countryOrTown, operation) {
            var listItem,
                listItemText,
                inputField = $('<input type=text>'),
                buttonOK,
                buttonCancel;

            function createForm() {
                listItem.empty().append($('<span>').append(inputField).append(buttonOK).append(buttonCancel));
            }

            switch (countryOrTown) {
                case 'country':
                    buttonCancel = $('<button>').text('Cancel').on('click', function () {
                        getObjects();
                    });
                    switch (operation) {
                        case 'add':
                            listItem = $('<li>');
                            buttonOK = $('<button>').text('OK').on('click', function () {
                                modifyObject({name: $(listItem).find('input').val()}, 'POST');
                            });
                            selector.append(listItem);
                            break;
                        case 'edit':
                            listItem = selector.closest('li');
                            listItemText = listItem.children('span').text();
                            inputField = inputField.val(listItemText);
                            buttonOK = $('<button>').text('OK').on('click', selector.data('item'), function (event) {
                                event.data.name = $(this).closest('li').find('input').val();
                                modifyObject(event.data, 'PUT');
                            });
                            break;
                        default:
                            throw new Error('Invalid operation in showForm.');
                            break;
                    }

                    createForm();
                    break;
                case 'town':
                    var country = $('#towns-section > h1 a').data('item');
                    buttonCancel = $('<button>').text('Cancel').on('click', function () {
                        initializeTowns(country);
                        getObjects(country.objectId);
                    });
                    switch (operation) {
                        case 'add':
                            listItem = $('<li>');
                            buttonOK = $('<button>').text('OK').on('click', function () {
                                modifyObject(
                                    {
                                        name: $(listItem).find('input').val(),
                                        country: $('#towns-section > h1 a').data('item')
                                    }, 'POST');
                            });
                            selector.append(listItem);
                            break;
                        case 'edit':
                            listItem = selector.closest('li');
                            listItemText = listItem.children('span').text();
                            inputField = inputField.val(listItemText);
                            buttonOK = $('<button>').text('OK').on('click', selector.data('item'), function (event) {
                                event.data.name = $(this).closest('li').find('input').val();
                                modifyObject(event.data, 'PUT');
                            });
                            break;
                        default:
                            throw new Error('Invalid operation in showForm.');
                            break;
                    }

                    createForm();
                    break;
                default:
                    throw new Error('Invalid selector in showForm');
                    break;
            }
        }

        function notify(type) {
            var status = type && (type === 'success' || type === 'error') ? type : 'unknown';
            switch (status) {
                case 'success':
                    noty({
                            text: 'Ajax request successfully completed',
                            type: 'success',
                            layout: 'bottomLeft',
                            timeout: 5000}
                    );
                    break;
                case 'error':
                    noty({
                            text: 'Unsuccessful ajax request.',
                            type: 'error',
                            layout: 'bottomLeft',
                            timeout: 5000}
                    );
                    break;
                default:
                    noty({
                            text: 'Unknown error.',
                            type: 'alert',
                            layout: 'topCenter',
                            timeout: 5000}
                    );
            }
        }

        initializeCountries();
        getObjects();
    }
);




























