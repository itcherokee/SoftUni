var Shapes = (function () {

    function validateColor(color) {
        var isValidColor = /(^#[0-9A-F]{6}$)|(^#[0-9A-F]{3}$)/i.test(color);
        if (isValidColor) {
            return color;
        } else {
            throw 'Not a valid color (hex value example: "#FFF" or "#FFFFFF").';
        }
    }

    function validateNumber(number) {
        var isValidColor = /^-?\d+\.?\d*$/.test(number);
        if (isValidColor) {
            return number;
        } else {
            throw 'Not a valid number provided.';
        }
    }

    var canvas = document.getElementById("context").getContext("2d");

    var Shape = (function () {

        function Shape(x, y, color) {
            this._x = validateNumber(x);
            this._y = validateNumber(y);
            this._color = validateColor(color);
            this.context = canvas;
        }

        Shape.prototype.toString = function () {
            return this._name + ' - X: ' + this._x + ', Y: ' + this._y + ', Color: #' + this._color;
        };

        return Shape;
    }());

    var Circle = (function () {
        function Circle(x, y, radius, color) {
            Shape.call(this, x, y, color);
            this._radius = validateNumber(radius);
            this._name = 'Circle';
        }

        Circle.prototype = Object.create(Shape.prototype);
        Circle.prototype.constructor = Circle;

        Circle.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', Radius: ' + this._radius;
        };

        Circle.prototype.draw = function () {
            this.context.fillStyle = this._color;
            this.context.beginPath();
            this.context.arc(this._x, this._y, this._radius, 0, 2 * Math.PI);
            this.context.closePath();
            this.context.fill();
        };

        return Circle;
    }());

    var Point = (function () {
        function Point(x, y, color) {
            Shape.call(this, x, y, color);
            this._name = 'Point';
        }

        Point.prototype = Object.create(Shape.prototype);
        Point.prototype.constructor = Point;

        Point.prototype.draw = function () {
            this.context.fillStyle = this._color;
            this.context.fillRect(this._x, this._y, 1, 1);
        };

        return Point;
    }());

    var Rectangle = (function () {
        function Rectangle(x, y, width, height, color) {
            Shape.call(this, x, y, color);
            this._width = validateNumber(width);
            this._height = validateNumber(height);
            this._name = 'Rectangle';
        }

        Rectangle.prototype = Object.create(Shape.prototype);
        Rectangle.prototype.constructor = Rectangle;
        Rectangle.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', Width: ' + this._width + ', Height: ' + this._height;
        };

        Rectangle.prototype.draw = function () {
            this.context.fillStyle = this._color;
            this.context.fillRect(this._x, this._y, this._width, this._height);
        };

        return Rectangle;
    }());

    var Segment = (function () {
        function Segment(x1, y1, x2, y2, color) {
            Shape.call(this, x1, y1, color);
            this._x2 = validateNumber(x2);
            this._y2 = validateNumber(y2);
            this._name = 'Segment';
        }

        Segment.prototype = Object.create(Shape.prototype);
        Segment.prototype.constructor = Segment;

        Segment.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', X2: ' + this._x2 + ', Y2: ' + this._y2;
        };

        Segment.prototype.draw = function () {
            this.context.strokeStyle = this._color;
            this.context.beginPath();
            this.context.moveTo(this._x, this._y);
            this.context.lineTo(this._x2, this._y2);
            this.context.closePath();
            this.context.stroke();
        };

        return Segment;
    }());

    var Triangle = (function () {
        function Triangle(x1, y1, x2, y2, x3, y3, color) {
            Segment.call(this, x1, y1, x2, y2, color);
            this._x3 = validateNumber(x3);
            this._y3 = validateNumber(y3);
            this._name = 'Triangle';
        }

        Triangle.prototype = Object.create(Segment.prototype);
        Triangle.prototype.constructor = Triangle;

        Triangle.prototype.toString = function () {
            return Segment.prototype.toString.call(this) + ', X3: ' + this._x3 + ', Y3: ' + this._y3;
        };

        Triangle.prototype.draw = function () {
            this.context.fillStyle = this._color;
            this.context.beginPath();
            this.context.moveTo(this._x, this._y);
            this.context.lineTo(this._x2, this._y2);
            this.context.lineTo(this._x3, this._y3);
            this.context.closePath();
            this.context.fill();
        };

        return Triangle;
    }());

    return {
        Point: Point,
        Segment: Segment,
        Triangle: Triangle,
        Rectangle: Rectangle,
        Circle: Circle
    }
})();

// This is only for console tests:
//var circle = new Shapes.Circle(2, 3, 100, '#FAAAFF');
//console.log(circle.toString());
//var triangle = new Shapes.Triangle(1, 2, 3, 4, 5, 6, '#FAAAFF');
//console.log(triangle.toString());
//var rectangle = new Shapes.Rectangle(1, 2, 3, 4, '#FAAAFF');
//console.log(rectangle.toString());
//var segment = new Shapes.Segment(1, 2, 3, 4, '#FAAAFF');
//console.log(segment.toString());
//var point = new Shapes.Point(1, -3.2, '#FAAAFF');
//console.log(point.toString());

// This is for browser tests:
var point = new Shapes.Point(111, 30.2, '#FF0000');
point.draw();
var circle = new Shapes.Circle(122, 300, 50, '#00FF00');
circle.draw();
var rectangle = new Shapes.Rectangle(1, 2, 30, 400, '#0000FF');
rectangle.draw();
var segment = new Shapes.Segment(400, 300, 450, 104, '#666677');
segment.draw();
var triangle = new Shapes.Triangle(100, 20, 23, 44, 55, 6, '#aaffdd');
triangle.draw();
