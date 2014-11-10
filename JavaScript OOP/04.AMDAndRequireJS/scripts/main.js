(function () {
    requirejs.config({
        paths: {
            'extensions': 'utils/extensions',
            'domElement': 'domElement',
            'container': 'container',
            'section': 'section',
            'item': 'item',
            'factory':'factory'
        }
    });

    requirejs(['factory'], function (Factory) {
        new Factory('container', 'Sunday');
    });
})();