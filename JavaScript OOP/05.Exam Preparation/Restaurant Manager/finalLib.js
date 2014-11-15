// Some polyfills
// Polyfill for extra trim
//String.prototype.trim = function () {
//    return this.replace(/^\s+|\s+$/g, '');
//};

// Polyfill for String.contains
String.prototype.contains = function (searchFor) {
    return String.prototype.indexOf.call(this, String(searchFor)) !== -1;
};

// Exception definitions
function throwTypeException(parameter) {
    throw new TypeError('The ' + parameter + ' is not of expected type.');
}

function throwRangeException(parameter) {
    throw new RangeError('The ' + parameter + ' is out of range.');
}

function throwException(parameter, message) {
    if (!message) {
        throw new Error('The ' + parameter + ' is invalid.');
    } else {
        throw new Error(message);
    }
}

// Object inheritance
Object.prototype.inherits = function inherits(parent) {
    if (typeof Object.create !== 'function') {
        Object.create = function (o) {
            function F() {}
            F.prototype = o;
            return new F();
        };
    }

    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

// Type validations
Object.prototype.isNumber = function (){
   return typeof this.valueOf() === 'number' ;
};

Object.prototype.isString = function () {
    return (typeof (this.valueOf()) === 'string');
};

Object.prototype.isBoolean = function () {
    return (typeof (this.valueOf()) === 'boolean')
};

Object.prototype.isDate = function () {
    return (!isNaN(new Date().parse(this.valueOf())));
};

// String validations
String.prototype.isEmptyOrWhiteSpace = function () {
    return (this.valueOf().trim().length === 0);
};

// Integer validations
Object.prototype.isInteger = function () {
//    return (this.valueOf() % 1) === 0;
    return this.valueOf().isNumber() && /^-?\d+$/.test(String(this.valueOf()));
    //return Number(this.valueOf()) === this.valueOf() && this.valueOf() % 1 === 0
};

Object.prototype.isInRange = function (minRange, maxRange, parameter) {
    if (!minRange.isNumber() || !minRange.isInteger()) {
        throwTypeException(parameter);
    }

    if (!maxRange.isNumber() || !maxRange.isInteger()) {
        throwRangeException(parameter);
    }

    if (!this.valueOf().isNumber()) {
        throwTypeException(parameter);
    }

    return (minRange < this.valueOf() && this.valueOf() < maxRange);
};

