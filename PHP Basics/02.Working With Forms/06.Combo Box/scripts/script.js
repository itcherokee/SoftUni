(function(){
    var continents = document.getElementById('continents');
    continents.addEventListener('change', function(){
        var form = document.getElementById('form-combo');
        form.submit();
    });
}());