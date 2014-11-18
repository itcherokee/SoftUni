function processTrainingCenterCommands(commands) {

    'use strict';

    Object.prototype.inherits = function (parent) {
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


    Object.prototype.isDate = function () {
        return this instanceof Date;
    };

    String.prototype.isEmptyOrWhiteSpace = function () {
        return (this.valueOf().trim().length === 0);
    };

    Number.prototype.isPositive = function () {
        return this.valueOf() >= 0;
    };

    Object.prototype.isInteger = function () {
//    return (this.valueOf() % 1) === 0;
        var onlyDigits = /^-?\d+$/.test(String(this.valueOf()));
        if (onlyDigits && typeof (this.valueOf()) === 'number') {
            var number = parseFloat(this.valueOf());
            return number.isNumber();
        }

        return false;
        //return Number(this.valueOf()) === this.valueOf() && this.valueOf() % 1 === 0
    };

    Object.prototype.isInRange = function (minRange, maxRange, parameter) {
        if (isNaN(minRange)) {
            throwTypeException(parameter);
        }

        if (isNaN(maxRange)) {
            throwRangeException(parameter);
        }

        if (isNaN(this.valueOf())) {
            throwTypeException(parameter);
        }

        return (minRange <= this.valueOf() && this.valueOf() <= maxRange);
    };

    var trainingcenter = (function () {

        var TrainingCenterEngine = (function () {

            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;

            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }

            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }

            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName,
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description,
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }

            function findTrainerByUsername(username) {
                if (!username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUsername() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }

            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUsername());
                }
                _uniqueTrainerUsernames[trainer.getUsername()] = true;
                _trainers.push(trainer);
            }

            function addTraining(training) {
                _trainings.push(training);
            }

            function executeListCommand() {
                var result = '', i;
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }

                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }

                return result.trim();
            }

            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        var trainer = findTrainerByUsername(deleteArgs);
                        if (trainer) {
                            _trainers.splice(_trainers.indexOf(trainer), 1);
                            delete _uniqueTrainerUsernames[trainer.getUsername()];
                            _trainings.forEach(function (training) {
                                var trainerExists = training.getTrainer();
                                if (trainerExists) {
                                    if (trainerExists.getUsername() === trainer.getUsername()) {
                                        training.setTrainer(undefined);
                                    }
                                }
                            });
                        } else {
                            new Error('Command "delete Trainer" not implemented.');
                        }

                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }

            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };
            return trainingCenterEngine;
        }());


        var Trainer = (function () {
            function Trainer(username, firstName, lastName, email) {
                this.setUsername(username);
                this.setFirstName(firstName);
                this.setLastName(lastName);
                this.setEmail(email);
            }

            Trainer.prototype.getEmail = function () {
                if (this._email) {
                    return this._email;
                }
            };

            Trainer.prototype.setEmail = function (value) {
                if (value !== undefined) {
                    if (value.indexOf('@') !== -1) {
                        this._email = value;
                    } else {
                        throw new Error("invalid e-mail");
                    }
                }
            };

            Trainer.prototype.getFirstName = function () {
                if (this._firstName) {
                    return this._firstName;
                }
            };

            Trainer.prototype.setFirstName = function (value) {
                if (value != undefined) {
                    if (value.isString() && !value.isEmptyOrWhiteSpace()) {
                        this._firstName = value;
                    } else {
                        throw new Error("invalid First Name.");
                    }
                }
            };

            Trainer.prototype.getLastName = function () {
                return this._lastName;
            };

            Trainer.prototype.setLastName = function (value) {
                if (value.isString() && !value.isEmptyOrWhiteSpace()) {
                    this._lastName = value;
                } else {
                    throw new Error("invalid parameter");
                }
            };

            Trainer.prototype.getUsername = function () {
                return this._username;
            };

            Trainer.prototype.setUsername = function (value) {
                if (value.isString() && !value.isEmptyOrWhiteSpace()) {
                    this._username = value;
                } else {
                    throw new Error("invalid parameter");
                }
            };

            Trainer.prototype.toString = function () {
                var firstName = this.getFirstName() ? ';first-name=' + this.getFirstName() : '';
                var email = this.getEmail() ? ';email=' + this.getEmail() : '';
                return 'Trainer[username=' + this.getUsername() +
                    firstName + ';last-name=' + this.getLastName() + email + ']';
            };

            return Trainer;
        }());

        var Training = (function () {
            function Training(name, description, trainer, startDate, duration) {
                if (this.constructor === Training) {
                    throw new Error("Opala, cannot instantiate an abstract object.");
                }

                this.setName(name);
                this.setDescription(description);
                this.setTrainer(trainer);
                this.setStartDate(startDate);
                this.setDuration(duration);
            }

            Training.prototype.getName = function () {
                return this._name;
            };

            Training.prototype.setName = function (value) {

                if (value.isString() && !value.isEmptyOrWhiteSpace()) {
                    this._name = value;
                } else {
                    throw new Error("invalid Training name.");
                }
            };

            Training.prototype.getDescription = function () {
                if (this._description) {
                    return this._description;
                }
            };

            Training.prototype.setDescription = function (value) {
                if (value !== undefined) {
                    if (value.isString() && !value.isEmptyOrWhiteSpace()) {
                        this._description = value;
                    } else {
                        throw new Error("invalid Training description.");
                    }
                }
            };

            Training.prototype.getTrainer = function () {
                if (this._trainer) {
                    return this._trainer;
                }
            };

            Training.prototype.setTrainer = function (value) {
                if (value !== undefined) {
                    if (value instanceof Trainer || value === null) {
                        this._trainer = value;
                    } else {
                        throw new Error("invalid Training trainer.");
                    }
                }
                else{
                    this._trainer = undefined;
                }
            };

            Training.prototype.getStartDate = function () {
                return this._startDate;
            };

            Training.prototype.setStartDate = function (value) {
                if (value && value instanceof Date && value >= parseDate('1-Jan-2000') && value <= parseDate('31-Dec-2020')) {
                    this._startDate = value;
                } else {
                    throw new Error('Invalid start date.');
                }
            };

            Training.prototype.getDuration = function () {
                if (this._duration) {
                    return this._duration;
                }
            };

            Training.prototype.setDuration = function (value) {
                if (value !== undefined) {
                    if (value.isInteger() && value.isInRange(1, 99)) {
                        this._duration = value;
                    } else {
                        throw new Error("invalid Training duration.");
                    }
                }
            };

            Training.prototype.toString = function () {
                var description = this.getDescription() ? ';description=' + this.getDescription() : '';
                var trainer = this.getTrainer() ? ';trainer=' + this.getTrainer().toString() : '';

                return 'name=' + this.getName() + description +
                    trainer;
            };

            return Training;
        }());

        var Course = (function () {
            function Course(name, description, trainer, startDate, duration) {
                Training.call(this, name, description, trainer, startDate, duration);
            }

            Course.inherits(Training);

            Course.prototype.toString = function () {
                var duration = this.getDuration() ? ';duration=' + this.getDuration() : '';

                return this.constructor.name + '[' + Training.prototype.toString.call(this) +
                    ';start-date=' + formatDate(this.getStartDate()) + duration + ']';
            };

            return Course;
        }());

        var Seminar = (function () {
            var DURATION = 1;

            function Seminar(name, description, trainer, startDate) {
                Training.call(this, name, description, trainer, startDate, DURATION);
            }

            Seminar.inherits(Training);

            Seminar.prototype.toString = function () {
                return this.constructor.name + '[' + Training.prototype.toString.call(this) +
                    ';date=' + formatDate(this.getStartDate()) + ']';
            };

            return Seminar;
        }());

        var RemoteCourse = (function () {
            function RemoteCourse(name, description, trainer, startDate, duration, location) {
                Course.call(this, name, description, trainer, startDate, duration);
                this.setLocation(location);
            }

            RemoteCourse.inherits(Course);

            RemoteCourse.prototype.getLocation = function () {
                return this._location;
            };

            RemoteCourse.prototype.setLocation = function (value) {

                if (value.isString() && !value.isEmptyOrWhiteSpace()) {
                    this._location = value;
                } else {
                    throw new Error("invalid RemoteCourse location.");
                }
            };

            RemoteCourse.prototype.toString = function () {
                var duration = this.getDuration() ? ';duration=' + this.getDuration() : '';

                return this.constructor.name + '[' + Training.prototype.toString.call(this) +
                    ';start-date=' + formatDate(this.getStartDate()) + duration + ';location=' + this.getLocation() + ']';
            };

            return RemoteCourse;
        }());

        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };

        return trainingcenter;
    })
    ();


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


// Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err.stack);
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
//            console.log(processTrainingCenterCommands(arr));
//        });
//    }
//})();
var arr = [
    'create Trainer {"username":"nakov", "lastName":"Nakov"}',
    'create Trainer {"username":"maria", "firstName":"Maria", "lastName":"Green", "email":"maria@mail.ru"}',

    'create Course {"name":"C# Basics", "startDate":"15-Nov-2014"}',
    'create Course {"name":"JavaScript Apps", "trainer":"nakov", "startDate":"30-Nov-2014", "duration":8}',
    'create Course {"name":"JavaScript Basics", "description":"JS course for beginners", "trainer":"maria", "startDate":"20-Jan-2015", "duration":5}',

    'create Seminar {"name":"Python for Newbies", "date":"10-Jan-2015"}',
    'create Seminar {"name":"MySQL for Dummies", "description":"MySQL overview for beginners", "trainer":"nakov","date":"20-Jan-2015"}',

    'create RemoteCourse {"name":"C# Basics", "startDate":"31-Jan-2015", "location":"Varna"}',
    'create RemoteCourse {"name":"C# Basics", "description":"Programming course for absolute beginners", "trainer":"maria", "startDate":"31-Jan-2015", "duration":9, "location":"Bourgas"}',

    'list'];

var arr = [
    'create Trainer {"username":"nakov", "lastName":"Nakov"}',
    'create Course {"name":"C# Basics", "startDate":"15-Nov-2014", "trainer":"nakov"}',
    'list',

    'delete Trainer nakov',
    'list'

];
////
//var arr = [
//    'create Trainer {"lastName":"Missing username"}',
//    'create Trainer {"username":"nakov", "firstName":"", "lastName":"Empty firstName"}',
//    'create Course {"name":"Invalid startDate", "startDate":"31-Nov-2014"}',
//    'create Seminar {"name":"Missing date"}',
//    'create Seminar {"name":"", "date":"12-Nov-2014", "description":"Empty name"}',
//    'create Course {"name":"C# Basics", "startDate":"15-Nov-2014", "trainer":"invalid_username"}',
//    'create RemoteCourse {"name":"C# Basics", "startDate":"12-Mar-2015", "description":"Missing location"}',
//    'invalid command',
//];
//
//var arr = [
////    'create Trainer {"username":"nakov", "lastName":"Nakov"}',
////    'create Course {"name":"C# Basics", "startDate":"11-Jan-2020"}',
////    'create Trainer {"username":"maria", "firstName":"Maria", "lastName":"Green", "email":""}',
////    'delete Trainer nakov',
//    'create Course {"name":"Invalid startDate", "startDate":"30-Nov-2014", "duration":""}',
////    'list',
////
////    'delete Trainer nakov',
//    'list'
//
//];

var arr = [
//    'create Course {"name":"PHP Web Apps", "startDate":"3-May-2015", "trainer":"nakov"}',
//
    'create Trainer {"username":"nakov", "firstName":"Svetlin", "lastName":"Nakov"}',
//    'create Seminar {"name":"JS for C# devs", "date":"15-Nov-2014", "trainer":"nakov", "description":"JS vs. C#"}',
//    'list',
//
    'delete Trainer nakov',
//    'delete Trainer nakov',
//    'list',
//
//    'create RemoteCourse {"name":"Java Basics", "startDate":"22-Nov-2014", "trainer":"nakov", "location":"Varna"}',

    'create Trainer {"username":"nakov", "lastName":"NAKOV"}',
//    'create RemoteCourse {"name":"Java Basics", "startDate":"22-Nov-2014", "trainer":"nakov", "location":"Varna"}',
    'list'


];

var arr = [
//    'create Course {"startDate":"12-Dec-2014", "description":"Missing name"}',
//    'create Course {"name":"", "startDate":"12-Dec-2014", "description":"Empty name"}',
//    'create Course {"name":3.14159, "startDate":"12-Dec-2014", "description":"name is not string"}',
//
//    'create Course {"name":"Empty description", "startDate":"1-Jan-2015", "description":""}',
//
//    'create Course {"name":"Course", "startDate":"31-Dec-2014", "trainer":"pesho", "description":"Non-existing trainer"}',
//    'create Course {"name":"Course", "startDate":"31-Dec-2014", "trainer":3.14159, "description":"Non-existing trainer"}',
//
//    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":"", "description":"Empty duration"}',
//    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":2.5, "description":"Duration should be integer"}',
    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":"20", "description":"Duration should be integer (not string)"}',
    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":500, "description":"Duration should be integer in range [1..99]"}',
    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":0, "description":"Duration should be integer in range [1..99]"}',
    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":100, "description":"Duration should be integer in range [1..99]"}',

    'create Course {"name":"Course", "startDate":"31-Dec-2014", "duration":1, "description":"Valid duration"}',
    'create Course {"name":"Course", "startDate":"2-Jul-2016", "duration":99, "description":"Valid duration"}',

    'list'
];

console.log(processTrainingCenterCommands(arr));
