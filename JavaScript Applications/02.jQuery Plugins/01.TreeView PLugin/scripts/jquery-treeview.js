// Task 1:  Create a jQuery plugin for creating a TreeView:
//          • A TreeView contains several items
//          • Each item may contain items of its own
//          • Clicking on an item shows/hides its direct children

(function ($) {
    $.fn.treeView = function () {
        var $this = $(this),
            noBulletStyle = {'list-style': 'none'},
            childLists = $this.find('ul', 'ol'),
            allParentListItem = $this.find('ul').closest('li'),
            allListItems = $this.find('li').not(allParentListItem),
            bullet = 'content: ""; border-color: transparent #111; border-style: solid;' +
                'border-width: 0.35em 0 0.35em 0.45em; display: block; height: 0; width: 0; left: -1em;' +
                'top: 0.9em; position: relative;',
            circle = "content: ''; border-color: #111; border-style: solid;" +
                "border-width: 0.25em; display: block; height: 0; width: 0;" +
                "left: -1em; top: 0.9em; position: relative;" +
                "border-radius: 0.35em";

        $("<style>.subMenu:before{" + circle + "}</style>").appendTo("head");
        $("<style>.noSubMenu:before{" + bullet + "}</style>").appendTo("head");

        allListItems.addClass('subMenu');
        allParentListItem = $this.find('ul').closest('li');
        allParentListItem.addClass('noSubMenu');
        $this.css(noBulletStyle);
        childLists.css(noBulletStyle);
        childLists.hide();

        allParentListItem.on('click', function (event) {
            event.stopPropagation();
            $(event.target).children().toggle();
        });

        return $this;
    }
}(jQuery));