function processRestaurantManagerCommands(commands) {
    'use strict';

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };


    var RestaurantEngine = (function () {
        var _restaurants, _recipes;

        function initialize() {
            _restaurants = [];
            _recipes = [];
        }

        function throwTypeException(parameter) {
            throw new TypeError('The ' + parameter + ' is required.');
        }

        function throwRangeException(parameter) {
            throw new RangeError('The ' + parameter + ' must be positive.');
        }

        function throwException(parameter, message) {
            if (!message) {
                throw new Error('The ' + parameter + ' is required.');
            } else {
                throw new Error(message);
            }
        }

        function validateNonEmptyString(value, parameter) {
            if (value === null || value.trim().length === 0 || typeof (value) !== 'string') {
                throwException(parameter);
            }

            return value;
        }

        function validateRange(value, minRange, maxRange, parameter) {
            if ((typeof (minRange) !== 'number' || parseInt(minRange, 10) != minRange) || parseInt(minRange, 10) < 0 ||
                (typeof (maxRange) !== 'number' || parseInt(maxRange, 10) != maxRange) || parseInt(maxRange, 10) < parseInt(minRange, 10)) {
                throwException(null, 'The ranges are invalid.');
            }

            if (typeof (value) !== 'number' || parseInt(value, 10) != value || (value < minRange || value > maxRange)) {
                throwRangeException(parameter);
            }

            return value;
        }

        function validateNumber(value, parameter) {
            if (isNaN(value) || value < 0) {
                throwRangeException(parameter);
            }

            return value;
        }

        function validateBoolean(value, parameter) {
            if (typeof (value) !== 'boolean') {
                throwException(parameter);
            }

            return value;
        }

        function parseBooleanToWords(value, parameter) {
            switch (value) {
                case true:
                    return "yes";
                case false:
                    return "no";
                default:
                    throwException(parameter);
            }
        }

        var Restaurant = (function () {


            function Restaurant(name, location) {
                this._recipes = [];
                this.setName(name);
                this.setLocation(location);
            }

            Restaurant.prototype.getName = function () {
                return this._name;
            };

            Restaurant.prototype.setName = function (name) {
                this._name = validateNonEmptyString(name, 'name');
            };

            Restaurant.prototype.getLocation = function () {
                return this._location;
            };

            Restaurant.prototype.setLocation = function (location) {
                this._location = validateNonEmptyString(location, 'location');
            };

            Restaurant.prototype.addRecipe = function (recipe) {
                if (recipe instanceof Recipe) {
                    this._recipes.push(recipe);
                } else {
                    throwTypeException('recipe');
                }
            };

            Restaurant.prototype.removeRecipe = function (recipe) {
                if (recipe instanceof Recipe) {
                    for (var i = 0; i < this._recipes.length; i++) {
                        if (recipe.getName() === this._recipes[i].getName()) {
                            this._recipes.splice(i, 1);
                            break;
                        }
                    }
                }
            };

            Restaurant.prototype.getRecipes = function () {
                return this._recipes;
            };

            Restaurant.prototype.prepareRecipesForOutput = function () {
                var drinks = [],
                    salads = [],
                    mainCourses = [],
                    desserts = [],
                    output = '';

                function sortRecipes(a, b) {
                    return a.getName().localeCompare(b.getName());
                }

                if (this.getRecipes().length) {
                    this.getRecipes().forEach(function (recipe) {
                        switch (recipe.constructor.name) {
                            case 'Drink':
                                drinks.push(recipe);
                                break;
                            case 'Dessert':
                                desserts.push(recipe);
                                break;
                            case 'MainCourse':
                                mainCourses.push(recipe);
                                break;
                            case 'Salad':
                                salads.push(recipe);
                                break;
                            default:
                                throwTypeException('recipe');
                        }
                    });

                    drinks.sort(sortRecipes);
                    salads.sort(sortRecipes);
                    mainCourses.sort(sortRecipes);
                    desserts.sort(sortRecipes);

                    if (drinks.length) {
                        output += '~~~~~ DRINKS ~~~~~\n';
                        drinks.forEach(function (recipe) {
                            output += recipe.toString();
                        });
                    }

                    if (salads.length) {
                        output += '~~~~~ SALADS ~~~~~\n';
                        salads.forEach(function (recipe) {
                            output += recipe.toString();
                        });
                    }

                    if (mainCourses.length) {
                        output += '~~~~~ MAIN COURSES ~~~~~\n';
                        mainCourses.forEach(function (recipe) {
                            output += recipe.toString();
                        });
                    }

                    if (desserts.length) {
                        output += '~~~~~ DESSERTS ~~~~~\n';
                        desserts.forEach(function (recipe) {
                            output += recipe.toString();
                        });
                    }
                } else {
                    output += 'No recipes... yet\n';
                }
                return output;
            };

            Restaurant.prototype.printRestaurantMenu = function () {
                return '***** ' + this.getName() + ' - ' + this.getLocation() + ' *****\n' +
                    this.prepareRecipesForOutput();
            };

            return Restaurant;
        }());


        var Recipe = (function () {
            function Recipe(name, price, calories, quantity, unitMeasure, timeToPrepare) {
                if (this.constructor === Recipe) {
                    throwException(null, 'This is an abstract class (Recipe) and cannot be instantiated.');
                }

                this.setName(name);
                this.setPrice(price);
                this.setCalories(calories);
                this.setQuantity(quantity);
                this.setUnitMeasure(unitMeasure);
                this.setTimeToPrepare(timeToPrepare);
            }

            Recipe.prototype.getName = function () {
                return this._name;
            };

            Recipe.prototype.setName = function (name) {
                this._name = validateNonEmptyString(name, 'name');
            };

            Recipe.prototype.getPrice = function () {
                return this._price.toFixed(2);
            };

            Recipe.prototype.setPrice = function (price) {
                this._price = validateNumber(price, 'price');
            };

            Recipe.prototype.getCalories = function () {
                return this._calories;
            };

            Recipe.prototype.setCalories = function (calories) {
                this._calories = validateNumber(calories, 'calories');
            };

            Recipe.prototype.getQuantity = function () {
                return this._quantity;
            };

            Recipe.prototype.setQuantity = function (quantity) {
                this._quantity = validateNumber(quantity, 'quantity');
            };

            Recipe.prototype.getUnitMeasure = function () {
                return this._unitMeasure;
            };

            Recipe.prototype.setUnitMeasure = function (unitMeasure) {
                this._unitMeasure = validateNonEmptyString(unitMeasure, 'unitMeasure');
            };

            Recipe.prototype.getTimeToPrepare = function () {
                return this._timeToPrepare;
            };

            Recipe.prototype.setTimeToPrepare = function (timeToPrepare) {
                this._timeToPrepare = validateNumber(timeToPrepare, 'timeToPrepare');
            };

            Recipe.prototype.toString = function () {
                return '==  ' + this.getName() + ' == $' + this.getPrice() +
                    '\nPer serving: ' + this.getQuantity() + ' ' + this.getUnitMeasure() +
                    ', ' + this.getCalories() + ' kcal' +
                    '\nReady in ' + this.getTimeToPrepare() + ' minutes' + '\n';
            };

            return Recipe;
        }());

        var Drink = (function () {
            var MEASURING_UNIT = 'ml',
                CALORIES_MIN = 0,
                CALORIES_MAX = 100,
                TIME_TO_PREPARE_MIN = 0,
                TIME_TO_PREPARE_MAX = 20;

            function Drink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                validateRange(calories, CALORIES_MIN, CALORIES_MAX, 'calories');
                validateRange(Number(timeToPrepare), TIME_TO_PREPARE_MIN, TIME_TO_PREPARE_MAX, 'timeToPrepare');
                Recipe.call(this, name, price, calories, quantity, MEASURING_UNIT, timeToPrepare);
                this.setIsCarbonated(isCarbonated);
            }

            Drink.extends(Recipe);

            Drink.prototype.getIsCarbonated = function () {
                return this._isCarbonated;
            };

            Drink.prototype.setIsCarbonated = function (isCarbonated) {
                this._isCarbonated = validateBoolean(isCarbonated, 'isCarbonated');
            };

            Drink.prototype.toString = function () {
                return Recipe.prototype.toString.call(this) +
                    'Carbonated: ' + parseBooleanToWords(this.getIsCarbonated(), 'isCarbonated') + '\n';
            };

            return Drink;
        }());

        var Meal = (function () {
            var MEASURING_UNIT = 'g';

            function Meal(name, price, calories, quantity, timeToPrepare, isVegan) {
                if (this.constructor === Meal) {
                    throwException(null, 'This is an abstract class (Recipe) and cannot be instantiated.');
                }

                Recipe.call(this, name, price, calories, quantity, MEASURING_UNIT, timeToPrepare);
                this.setIsVegan(isVegan);
            }

            Meal.extends(Recipe);

            Meal.prototype.getIsVegan = function () {
                return this._isVegan ? '[VEGAN] ' : '';
            };

            Meal.prototype.setIsVegan = function (isVegan) {
                this._isVegan = validateBoolean(isVegan, 'isVegan');
            };

            Meal.prototype.toggleVegan = function () {
                this._isVegan = !this._isVegan;
            };

            Meal.prototype.toString = function () {
                return this.getIsVegan() + Recipe.prototype.toString.call(this);
            };

            return Meal;
        }());

        var Dessert = (function () {
            function Dessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                this._withSugar = true;
            }

            Dessert.extends(Meal);

            Dessert.prototype.toggleSugar = function () {
                this._withSugar = !this._withSugar;
            };

            Dessert.prototype.getSugar = function () {
                return this._withSugar ? '' : '[NO SUGAR] ';
            };

            Dessert.prototype.toString = function () {
                return  this.getSugar() + this.getIsVegan() + Recipe.prototype.toString.call(this);
            };

            return Dessert;
        }());

        var MainCourse = (function () {
            function MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                this.setType(type);
            }

            MainCourse.extends(Meal);

            MainCourse.prototype.getType = function () {
                return this._type;
            };

            MainCourse.prototype.setType = function (type) {
                this._type = validateNonEmptyString(type, 'type');
            };

            MainCourse.prototype.toString = function () {
                return Meal.prototype.toString.call(this) +
                    'Type: ' + this.getType() + '\n';
            };

            return MainCourse;
        }());

        var Salad = (function () {
            var IS_ALWAYS_VEGAN = true;

            function Salad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, IS_ALWAYS_VEGAN);
                this.setContainsPasta(containsPasta);
            }

            Salad.extends(Meal);

            Salad.prototype.getContainsPasta = function () {
                return this._containsPasta;
            };

            Salad.prototype.setContainsPasta = function (containsPasta) {
                this._containsPasta = validateBoolean(containsPasta, 'containsPasta');
            };

            Salad.prototype.toString = function () {
                return Meal.prototype.toString.call(this) +
                    'Contains pasta: ' + parseBooleanToWords(this.getContainsPasta(), 'containsPasta') + '\n';
            };

            return Salad;
        }());

        var Command = (function () {

            function Command(commandLine) {
                this._params = [];
                this.translateCommand(commandLine);
            }

            Command.prototype.translateCommand = function (commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");

                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function (e) {
                        return true
                    });

                parametersKeysAndValues.forEach(function (p) {
                    var split = p
                        .split("=")
                        .filter(function (e) {
                            return true;
                        });
                    self._params[split[0]] = split[1];
                });
            };

            return Command;
        }());

        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }

        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }

        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }

        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }

        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }

        function toggleSugar(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];

            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }

        function toggleVegan(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }

            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }

        function printRestaurantMenu(name) {
            var restaurant;

            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }

            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }

        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }

        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }

        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;

            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }

            return result;
        }

        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });

    return results.trim();
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

//(function () {
//    var arr = [];
//    if (typeof (require) == 'function') {
//        // We are in node.js --> read the console input and process it
//        require('readline').createInterface({
//            input: process.stdin,
//            output: process.stdout
//        }).on('line', function (line) {
//                arr.push(line);
//            }).on('close', function () {
//                console.log(processRestaurantManagerCommands(arr));
//            });
//    }
//})();

var arr = [
    'CreateRestaurant(name=New Restaurant;location=Sofia)',
    'CreateRestaurant(location=Silicon Valley;name=SoftUni Restaurant)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'CreateMainCourse(name=Grilled Chicken;price=5.88;calories=320;quantity=370;time=15;vegan=no;type=Meat)',
    'CreateMainCourse(name=Spaghetti Carbonara;time=25;price=7.39;type=Pasta;calories=455;quantity=450;vegan=no)',
    'CreateSalad(price=7.99;name=Mexican Bean Salad;pasta=no;quantity=300;time=14;calories=150)',
    'CreateDessert(calories=450;name=Black Magic Cake;quantity=150;price=1.500001;vegan=no;time=2)',
    'CreateDrink(name=Home-made Lemonade;price=2.41;carbonated=no;calories=10;time=5;quantity=200)',
    'PrintRestaurantMenu(name=SoftUni Restaurant)',
    'AddRecipeToRestaurant(recipe=Black Magic Cake;restaurant=SoftUni Restaurant)',
    'AddRecipeToRestaurant(restaurant=SoftUni Restaurant;recipe=Grilled Chicken)',
    'AddRecipeToRestaurant(restaurant=SoftUni Restaurant;recipe=Mexican Bean Salad)',
    'AddRecipeToRestaurant(recipe=Home-made Lemonade;restaurant=SoftUni Restaurant)',
    'AddRecipeToRestaurant(restaurant=SoftUni Restaurant;recipe=Spaghetti Carbonara)',
    'PrintRestaurantMenu(name=SoftUni Restaurant)',
    'AddRecipeToRestaurant(restaurant=New Restaurant;recipe=Spaghetti Carbonara)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'RemoveRecipeFromRestaurant(restaurant=New Restaurant;recipe=Spaghetti Carbonara)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'RemoveRecipeFromRestaurant(recipe=Spaghetti Carbonara;restaurant=SoftUni Restaurant)',
    'RemoveRecipeFromRestaurant(recipe=Grilled Chicken;restaurant=SoftUni Restaurant)',
    'PrintRestaurantMenu(name=SoftUni Restaurant)',
    'CreateMainCourse(name=Vegan Red Lentil Soup;vegan=yes;price=5.99;quantity=250;time=15;calories=150;type=Soup)',
    'AddRecipeToRestaurant(recipe=Vegan Red Lentil Soup;restaurant=New Restaurant)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'ToggleVegan(name=Vegan Red Lentil Soup)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'CreateDessert(name=Black Chocolate Cake;quantity=120;price=2.32;vegan=yes;time=6;calories=300)',
    'AddRecipeToRestaurant(recipe=Black Chocolate Cake;restaurant=New Restaurant)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'ToggleSugar(name=Black Chocolate Cake)',
    'PrintRestaurantMenu(name=New Restaurant)',
    'PrintRestaurantMenu(name=No Such Restaurant)',
    'AddRecipeToRestaurant(restaurant=No Such Recipe;recipe=No Such Recipe)',
    'AddRecipeToRestaurant(restaurant=New Restaurant;recipe=No Such Recipe)',
    'ToggleSugar(name=Grilled Chicken)',
    'ToggleVegan(name=Home-made Lemonade)',
    'End'

];
console.log(processRestaurantManagerCommands(arr));