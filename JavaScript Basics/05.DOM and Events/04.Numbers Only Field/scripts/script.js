// Task 4:  Write a HTML page holding a form and a text field. Using JavaScript make the text field
//          to accept numbers only. When a non-number character is entered through the keyboard
//          (or by any other way), make the field red for a while and do not accept the change
//          (preserve the previous value of the field).

(function(){
    "use strict";
    var field = document.getElementById('numbers');
    field.addEventListener("keypress", checkInput);
    field.addEventListener("paste", checkInput);

    function wrongInput(owner){
        // handles coloring the input box in red and fade out
        var self = owner;
        self.style.backgroundColor = '#f00';
        setTimeout(function () {
            self.style.backgroundColor = '#fff';
        }, 2000);
    }

    function checkInput (e) {
        var currentValue,
            pastedValue,
            self = this;
        if (e.type === 'keypress') {
            // code handling typing on keyboard
            if (e.charCode < 48 || e.charCode > 57) {
                e.preventDefault();
                wrongInput(self);
            }
        } else {
            // code handling Ctrl+V or Paste from menus
            currentValue = this.value;
            setTimeout(function(){
                pastedValue = self.value;
                if(isNaN(pastedValue) || pastedValue % 1 !== 0){
                    wrongInput(self);
                    self.value = currentValue;
                }
            }, 0);
        }
    }
}());
