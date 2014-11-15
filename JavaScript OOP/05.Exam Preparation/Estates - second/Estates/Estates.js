function processEstatesAgencyCommands(commands) {
    'use strict';

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    String.prototype.isEmptyString = function isEmptyString(value) {
        if (value === null || value.trim().length === 0 || typeof(value) !== 'string') {
            throw new Error("String value must be not null or empty.")
        }

        return value;
    }

    function validateRange(value, minRange, maxRange) {
        if ((typeof(minRange) !== 'number' || parseInt(minRange, 10) != minRange) || (typeof(maxRange) !== 'number' || parseInt(maxRange, 10) != maxRange)) {
            throw new Error("Invalid range has been provided.");
        }

        if (typeof(value) !== 'number' || parseInt(value, 10) != value || (value < minRange || value > maxRange)) {
            throw new Error("Value is out of allowed range.");
        }

        return value;
    }

    function validateBoolean(value) {
        if (typeof(value) !== 'boolean') {
            throw new Error("Not valid boolean value specified.");
        }

        return value;
    }

    function validatePrice(value) {
        if (isNaN(value) || value < 0 || parseInt(value, 10) != value ) {
            throw new Error("Not valid price value specified.");
        }

        return value;
    }

    var Estate = (function () {
        var AREA_MIN_RANGE = 1,
            AREA_MAX_RANGE = 10000;

        function Estate(name, area, location, isFurnitured) {
            if (this.constructor === Estate) {
                throw new Error("This is an abstract class (Estate) and cannot be instantiated.");
            }

            this.setName(name);
            this.setArea(area);
            this.setLocation(location);
            this.setIsFurnitured(isFurnitured);
        }

        Object.defineProperties(this, {
            name: {
                get: function() { return this._name; },
                set: function(value) {
                    value.checkIsPositive(); // validation
                    this._age = value;
                }
            },
            scores: {
                get: function() { return this._scores; },
                set: function(value) {
                    // validation here
                    this._scores = value;
                }
            },
            toString: {
                value: function () {
                    return "Student " + this.name + " is " + this.age + " years old.";
                }
            }
        });

        Estate.prototype.getName = function () {
            return this._name;
        };

        Estate.prototype.setName = function (value) {
            this._name = validateNonEmptyString(value);
        };

        Estate.prototype.getArea = function () {
            return this._area;
        };

        Estate.prototype.setArea = function (value) {
            this._area = validateRange(value, AREA_MIN_RANGE, AREA_MAX_RANGE);
        };

        Estate.prototype.getLocation = function () {
            return this._location;
        };

        Estate.prototype.setLocation = function (value) {
            this._location = validateNonEmptyString(value);
        };

        Estate.prototype.getIsFurnitured = function () {
            return this._isFurnitured;
        };

        Estate.prototype.setIsFurnitured = function (value) {
            this._isFurnitured = validateBoolean(value);
        };

        Estate.prototype.toString = function () {
            var furnitured = this.getIsFurnitured() ? 'Yes' : 'No';
            return this.constructor.name +
                ': Name = ' + this.getName() +
                ', Area = ' + this.getArea() +
                ', Location = ' + this.getLocation() +
                ', Furnitured = ' + furnitured;


        };

        return Estate;
    }());

    var BuildingEstate = (function () {
        var ROOMS_MIN_RANGE = 0,
            ROOMS_MAX_RANGE = 100;

        function BuildingEstate(name, area, location, isFurnitured, rooms, hasElevator) {
            if (this.constructor === BuildingEstate) {
                throw new Error("This is an abstract class (BuildingEstate) and cannot be instantiated.");
            }

            Estate.call(this, name, area, location, isFurnitured);
            this.setRooms(rooms);
            this.setHasElevator(hasElevator);
        }

        BuildingEstate.extends(Estate);
        BuildingEstate.prototype.getRooms = function () {
            return this._rooms;
        };

        BuildingEstate.prototype.setRooms = function (value) {
            this._rooms = validateRange(value, ROOMS_MIN_RANGE, ROOMS_MAX_RANGE);
        };

        BuildingEstate.prototype.getHasElevator = function () {
            return this._hasElevator;
        };

        BuildingEstate.prototype.setHasElevator = function (value) {
            this._hasElevator = validateBoolean(value);
        };

        BuildingEstate.prototype.toString = function () {
            var elevatored = this.getHasElevator() ? 'Yes' : 'No';
            return Estate.prototype.toString.call(this) +
                ', Rooms: ' + this.getRooms() +
                ', Elevator: ' + elevatored;
        };

        return BuildingEstate;
    }());

    var Apartment = (function () {
        function Apartment(name, area, location, isFurnitured, rooms, hasElevator) {
            BuildingEstate.call(this, name, area, location, isFurnitured, rooms, hasElevator);
        }

        Apartment.extends(BuildingEstate);

        return Apartment;
    }());

    var Office = (function () {
        function Office(name, area, location, isFurnitured, rooms, hasElevator) {
            BuildingEstate.call(this, name, area, location, isFurnitured, rooms, hasElevator);
        }

        Office.extends(BuildingEstate);

        return Office;
    }());

    var House = (function () {
        var FLOORS_MIN_RANGE = 0,
            FLOORS_MAX_RANGE = 10;

        function House(name, area, location, isFurnitured, floors) {
            Estate.call(this, name, area, location, isFurnitured);
            this.setFloors(floors);
        }

        House.extends(Estate);
        House.prototype.getFloors = function () {
            return this._floors;
        };

        House.prototype.setFloors = function (value) {
            this._floors = validateRange(value, FLOORS_MIN_RANGE, FLOORS_MAX_RANGE);
        };

        House.prototype.toString = function () {
            return Estate.prototype.toString.call(this) +
                ', Floors: ' + this.getFloors();
        };

        return House;
    }());

    var Garage = (function () {
        var WIDTH_AND_HEIGHT_MIN_RANGE = 1,
            WIDTH_AND_HEIGHT_MAX_RANGE = 500;

        function Garage(name, area, location, isFurnitured, width, height) {
            Estate.call(this, name, area, location, isFurnitured);
            this.setWidth(width);
            this.setHeight(height);
        }

        Garage.extends(Estate);

        Garage.prototype.getWidth = function () {
            return this._width;
        };

        Garage.prototype.setWidth = function (value) {
            this._width = validateRange(value, WIDTH_AND_HEIGHT_MIN_RANGE, WIDTH_AND_HEIGHT_MAX_RANGE);
        };

        Garage.prototype.getHeight = function () {
            return this._height;
        };

        Garage.prototype.setHeight = function (value) {
            this._height = validateRange(value, WIDTH_AND_HEIGHT_MIN_RANGE, WIDTH_AND_HEIGHT_MAX_RANGE);
        };

        Garage.prototype.toString = function () {
            return Estate.prototype.toString.call(this) +
                ', Width: ' + this.getWidth() +
                ', Height: ' + this.getHeight();
        };

        return Garage;
    }());

    var Offer = (function () {
        function Offer(estate, price) {
            if (this.constructor === Offer) {
                throw new Error("This is an abstract class (Offer) and cannot be instantiated.");
            }

            this.setEstate(estate);
            this.setPrice(price);
        }

        Offer.prototype.getEstate = function () {
            return this._estate;
        };

        Offer.prototype.setEstate = function (value) {
            if (!(value instanceof Estate)) {
                throw new Error("Invalid estate object provided.");
            }

            this._estate = value;
        };

        Offer.prototype.getPrice = function () {
            return this._price;
        };

        Offer.prototype.setPrice = function (value) {
            this._price = validatePrice(value);
        };

        Offer.prototype.toString = function () {
            return 'Estate = ' + this.getEstate().getName() +
                ', Location = ' + this.getEstate().getLocation() +
                ', Price = ' + this.getPrice();
        };

        return Offer;
    }());


    var RentOffer = (function () {
        function RentOffer(estate, price) {
            Offer.call(this, estate, price);
        }

        RentOffer.extends(Offer);

        RentOffer.prototype.toString = function () {
            return 'Rent: ' + Offer.prototype.toString.call(this);
        };

        return RentOffer;
    }());


    var SaleOffer = (function () {
        function SaleOffer(estate, price) {
            Offer.call(this, estate, price);
        }

        SaleOffer.extends(Offer);

        SaleOffer.prototype.toString = function () {
            return 'Sale: ' + Offer.prototype.toString.call(this);
        };

        return SaleOffer;
    }());


    var EstatesEngine = (function () {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
                case 'create':
                    return executeCreateCommand(cmdArgs);
                case 'status':
                    return executeStatusCommand();
                case 'find-sales-by-location':
                    return executeFindSalesByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-location':
                    return executeFindRentsByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-price':
                    return executeFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                default:
                    throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
                case 'Apartment':
                    var apartment = new Apartment(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(apartment);
                    break;
                case 'Office':
                    var office = new Office(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(office);
                    break;
                case 'House':
                    var house = new House(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                    addEstate(house);
                    break;
                case 'Garage':
                    var garage = new Garage(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                    addEstate(garage);
                    break;
                case 'RentOffer':
                    var estate = findEstateByName(cmdArgs[1]);
                    var rentOffer = new RentOffer(estate, Number(cmdArgs[2]));
                    addOffer(rentOffer);
                    break;
                case 'SaleOffer':
                    estate = findEstateByName(cmdArgs[1]);
                    var saleOffer = new SaleOffer(estate, Number(cmdArgs[2]));
                    addOffer(saleOffer);
                    break;
                default:
                    throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].getName() == estateName) {
                    return _estates[i];
                }
            }
            return undefined;
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.getName()]) {
                throw new Error('Duplicated estate name: ' + estate.getName());
            }
            _uniqueEstateNames[estate.getName()] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {
                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers\n';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function (offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof SaleOffer;
            });
            selectedOffers.sort(function (a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function (offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof RentOffer;
            });
            selectedOffers.sort(function (a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByPriceCommand(minPrice, maxPrice) {
            var lowerPrice = parseInt(validatePrice(minPrice)),
                higherPrice = parseInt(validatePrice(maxPrice));

            var selectedOffers = _offers.filter(function (offer) {
                return offer.getPrice() >= lowerPrice &&
                    offer.getPrice() <= higherPrice &&
                    offer instanceof RentOffer;
            });

            selectedOffers.sort(function (a, b) {
                var result = a.getPrice() - b.getPrice();
                if (result == 0) {
                    result = a.getEstate().getName().localeCompare(b.getEstate().getName());
                }
                return result;
            });

            return formatQueryResults(selectedOffers);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length == 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.getEstate().getName() +
                        ', Location: ' + offer.getEstate().getLocation() +
                        ', Price: ' + offer.getPrice() + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();

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
//            console.log(processEstatesAgencyCommands(arr));
//        });
//    }
//})();
