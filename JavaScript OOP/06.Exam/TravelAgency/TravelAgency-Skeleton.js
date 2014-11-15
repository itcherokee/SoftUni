function processTravelAgencyCommands(commands) {
    'use strict';

    function throwTypeException(parameter) {
        throw new TypeError('The ' + parameter + ' is not of expected type.');
    }

    function throwException(parameter, message) {
        if (!message) {
            throw new Error('The ' + parameter + ' is invalid.');
        } else {
            throw new Error(message);
        }
    }

    Object.prototype.inherits = function inherits(parent) {
        if (typeof Object.create !== 'function') {
            Object.create = function (o) {
                function F() {
                }

                F.prototype = o;
                return new F();
            };
        }

        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    // Type validations
    Object.prototype.isNumber = function () {
        return typeof this.valueOf() === 'number';
    };

    Object.prototype.isString = function () {
        return (typeof (this.valueOf()) === 'string');
    };

    Object.prototype.isBoolean = function () {
        return (typeof (this.valueOf()) === 'boolean')
    };

    Object.prototype.isDate = function () {
        return this instanceof Date;
    };

    String.prototype.isEmptyOrWhiteSpace = function () {
        return (this.valueOf().trim().length === 0);
    };

    Number.prototype.isPositive = function () {
        return this.valueOf() >= 0;
    };

    Object.prototype.isInRange = function (minRange, maxRange, parameter) {
        if (isNaN(minRange)) {
            throwTypeException(parameter);
        }

        if (isNaN(maxRange) ) {
            throwRangeException(parameter);
        }

        if (isNaN(this.valueOf())) {
            throwTypeException(parameter);
        }

        return (minRange <= this.valueOf() && this.valueOf() <= maxRange);
    };

    var Models = (function () {


        var Destination = (function () {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function () {
                return this._location;
            };

            Destination.prototype.setLocation = function (location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            };

            Destination.prototype.getLandmark = function () {
                return this._landmark;
            };

            Destination.prototype.setLandmark = function (landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            };

            Destination.prototype.toString = function () {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            };

            return Destination;
        }());

        var Travel = (function () {
            function Travel(name, startDate, endDate, price) {
                if (this.constructor === Travel) {
                    throwException('Cannot instantiate abstract class Travel.');
                }
                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }

            Travel.prototype.getName = function () {
                return this._name
            };

            Travel.prototype.setName = function (value) {
                if (!value.isString()) {
                    throwTypeException("name");
                }
                if (value.isEmptyOrWhiteSpace()) {
                    throwException("name");
                }

                this._name = value;
            };

            Travel.prototype.getStartDate = function () {
                return this._startDate;
            };

            Travel.prototype.setStartDate = function (value) {
                if (!value.isDate()) {
                    throwTypeException('startDate');
                }

                this._startDate = value;
            };

            Travel.prototype.getEndDate = function () {
                return this._endDate;
            };

            Travel.prototype.setEndDate = function (value) {
                if (!value.isDate()) {
                    throwTypeException('endDate');
                }

                this._endDate = value;
            };

            Travel.prototype.getPrice = function () {
                return this._price;
            };

            Travel.prototype.setPrice = function (value) {
                if (!value.isNumber()) {
                    throwTypeException("price");
                }

                if (!value.isPositive()) {
                    throwException('price', 'Price cannot be negative.');
                }

                this._price = value;
            };


            Travel.prototype.toString = function () {
                return ' * ' + this.constructor.name + ': name=' + this.getName() +
                    ',start-date=' + formatDate(this.getStartDate()) +
                    ',end-date=' + formatDate(this.getEndDate()) +
                    ',price=' + this.getPrice().toFixed(2);
            };

            return Travel;
        }());

        var Excursion = (function () {
            function Excursion(name, startDate, endDate, price, transport) {
                Travel.call(this, name, startDate, endDate, price);
                this._destinations = [];
                this.setTransport(transport);
            }

            Excursion.inherits(Travel);
            Excursion.prototype.getTransport = function () {
                return this._transport;
            };

            Excursion.prototype.setTransport = function (value) {
                if (!value.isString()) {
                    throwTypeException("transport");
                }
                if (value.isEmptyOrWhiteSpace()) {
                    throwException("transport");
                }
                this._transport = value;
            };

            Excursion.prototype.getDestinations = function () {
                return this._destinations;
            };

            Excursion.prototype.addDestination = function (value) {
                if (value instanceof Destination) {
                    this._destinations.push(value);
                } else {
                    throwTypeException('destination');
                }
            };

            Excursion.prototype.removeDestination = function (value) {
                if (value instanceof Destination && this.getDestinations().length > 0) {
                    for (var i = 0; i < this._destinations.length; i++) {
                        if (value.getLandmark() === this._destinations[i].getLandmark() &&
                            value.getLocation() === this._destinations[i].getLocation()) {
                            this._destinations.splice(i, 1);
                            return;
                        }
                    }
                }

                throwException('destination', 'Invalid destination')
            };

            Excursion.prototype.toString = function () {
                var destinations = this.getDestinations().join(";");
//                for(var i = 0; i < this.getDestinations().length; i+=1){
//                    destinations+= this.getDestinations()[i].toString();
//                }
                destinations = destinations ? destinations : '-';
                return Travel.prototype.toString.call(this) +
                    ',transport=' + this.getTransport() + '\n ** Destinations: ' + destinations;
            };

            return Excursion;
        }());

        var Vacation = (function () {
            function Vacation(name, startDate, endDate, price, location, accommodation) {
                Travel.call(this, name, startDate, endDate, price);
                this.setLocation(location);
                if (accommodation) {
                    this.setAccommodation(accommodation);
                }
            }

            Vacation.inherits(Travel);

            Vacation.prototype.getLocation = function () {
                return this._location;
            };

            Vacation.prototype.setLocation = function (value) {
                if (!value.isString()) {
                    throwTypeException("location");
                }
                if (value.isEmptyOrWhiteSpace()) {
                    throwException("location");
                }

                this._location = value;
            };

            Vacation.prototype.getAccommodation = function () {
                return this._accommodation;
            };

            Vacation.prototype.setAccommodation = function (value) {
                if (!value.isString()) {
                    throwTypeException("accommodation");
                }
                if (value.isEmptyOrWhiteSpace()) {
                    throwException("accommodation");
                }

                this._accommodation = value;
            };

            Vacation.prototype.toString = function () {
                var accommodation = this._accommodation ? ',accommodation=' + this.getAccommodation() : '';
                return Travel.prototype.toString.call(this) +
                    ',location=' + this.getLocation() + accommodation;
            };

            return Vacation;
        }());

        var Cruise = (function () {
            var TRANSPORT = 'cruise liner';

            function Cruise(name, startDate, endDate, price, startDock) {
                Excursion.call(this, name, startDate, endDate, price, TRANSPORT);
                if (startDock) {
                    this.setStartDock(startDock);
                }
            }

            Cruise.inherits(Excursion);

            Cruise.prototype.getStartDock = function () {
                return this._startDock ? this._startDock : '';
            };

            Cruise.prototype.setStartDock = function (value) {
                if (!value.isString()) {
                    throwTypeException("startDock");
                }
                if (value.isEmptyOrWhiteSpace()) {
                    throwException("startDock");
                }

                this._startDock = value;
            };

            Cruise.prototype.toString = function () {
                return Excursion.prototype.toString.call(this);
            };

            return Cruise;
        }());

        return {
            Destination: Destination,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function () {
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function (t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processFilterTravelsCommand(command) {
                var selectedTravels = _travels.filter(function (travel) {
                    var innerCondition = command['type'] !== 'all' ? command['type'] === travel.constructor.name.toLowerCase() : true;
                    var otherCondition = (travel.getPrice().isInRange(command['price-min'], command['price-max'], 'price'));
                    return innerCondition && otherCondition;
                });

                selectedTravels.sort(function (a, b) {
                    var result = a.getStartDate() - b.getStartDate();
                    if (result == 0) {
                        result = a.getName().localeCompare(b.getName());
                    }
                    return result;
                });

                return formatTravelsQuery(selectedTravels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery) {
                var queryString = "";

                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processFilterTravelsCommand: processFilterTravelsCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand
            }
        }());

        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------
//
//(function () {
//    var arr = [];
//    if (typeof (require) == 'function') {
//        // We are in node.js --> read the console input and process it
//        require('readline').createInterface({
//            input: process.stdin,
//            output: process.stdout
//        }).on('line', function (line) {
//            arr.push(line);
//        }).on('close', function () {
//            console.log(processTravelAgencyCommands(arr));
//        });
//    }
//})();

//var arr = [
//    'insert(type=vacation;name=Vakanciq;price=3400.00;start-date=22-Jun-2015;end-date=4-Jul-2015;location=Caribbean Sea;accommodation=hut)',
//    'insert(type=excursion;name=US travel;price=800.80;start-date=12-Jan-2015;end-date=29-Jan-2015;transport=plane)',
//    'insert(type=excursion;name=Dunavska prikazka;price=1350.22;start-date=6-Nov-2014;end-date=24-Dec-2014;transport=motorboat)',
//    'insert(type=cruise;name=Transatlantic cruise;end-date=16-Jan-2015;start-date=2-Jan-2015;price=1778.00;start-dock=Lisbon)',
//
//    'insert(type=destination;location=Budapest;landmark=Chain Bridge)',
//    'insert(type=destination;location=New York;landmark=Statue of Liberty)',
//    'insert(type=destination;location=California;landmark=Yosemite National Park)',
//
//    'add-destination(name=US travel;location=New York;landmark=Statue of Liberty)',
//    'add-destination(name=US travel;location=California;landmark=Yosemite National Park)',
//    'add-destination(name=Dunavska prikazka;location=Budapest;landmark=Chain Bridge)',
//    'add-destination(name=Transatlantic cruise;location=New York;landmark=Statue of Liberty)',
//
//    'filter(type=excursion;price-min=200;price-max=1000.00)',
//
//    'remove-destination(name=US travel;location=California;landmark=Yosemite National Park)',
//    'delete(type=destination;location=New York;landmark=Statue of Liberty)',
//
//    'filter(type=all;price-min=200;price-max=5000.00)'
//
//
//];
//var arr = [
//'insert(type=vacation;name=nqma location;price=3400.00;start-date=22-Jun-2015;end-date=4-Jul-2015)',
//'insert(type=vacation;name=nqma cena;start-date=22-Jun-2015;end-date=4-Jul-2015;location=Sofia)',
//'insert(type=excursion;name=nqma transport;start-date=22-Jun-2015;end-date=4-Jul-2015;price=500)',
//
//'insert(type=destination;location=nqma landmark)',
//'add-destination(name=nqma takuv;location=nqma;landmark=nqma)',
//'remove-destination(name=nqma go;location=nikude;landmark=v spisuka)',
//
//'insert(type=excursion;name=Alexandrupolis;price=28.00;start-date=7-Aug-2014;end-date=7-Aug-2014;transport=bus)',
//'insert(type=destination;location=Alexandrupolis;landmark=Alexandrupolis Beach)',
//'remove-destination(name=Alexandrupolis;location=Alexandrupolis;landmark=Alexandrupolis Beach)'
//
//];

var arr = [
'insert(type=cruise;name=Kruiz;price=500;start-date=22-Sep-2014;end-date=23-Sep-2014;start-dock=Venice)',
'insert(type=cruise;name=Kraizer;price=1520;end-date=23-Oct-2014;start-dock=Venice;start-date=5-Feb-2014)',
'insert(type=excursion;name=Bahamas;price=0;start-date=3-May-2014;end-date=23-May-2014;transport=boat)',
'insert(type=excursion;name=Rodopi;price=0;start-date=3-May-2014;end-date=23-May-2014;transport=boat)',
'insert(type=vacation;name=More;price=400;start-date=10-Nov-2014;end-date=15-Nov-2014;location=Sozopol;accommodation=hotel)',

'insert(type=destination;location=Varna;landmark=Delfinarium)',
'insert(type=destination;location=Bahamas;landmark=Coral rifts)',

'add-destination(name=Bahamas;location=Bahamas;landmark=Coral rifts)',
'add-destination(name=Bahamas;location=Varna;landmark=Delfinarium)',
'add-destination(name=Kraizer;location=Bahamas;landmark=Coral rifts)',
'add-destination(name=Kruiz;location=Bahamas;landmark=Coral rifts)',

'list',

'filter(type=all;price-min=250;price-max=1000)',
'filter(type=excursion;price-min=0;price-max=2000)',
'filter(type=excursion;price-min=3000;price-max=4000)',
];
console.log(processTravelAgencyCommands(arr));