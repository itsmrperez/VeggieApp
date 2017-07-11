var veggie = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
};

var defaultDependencies = [
        'ui.bootstrap'
];

veggie.moduleOptions = {
    APPNAME: "VeggiesApp"
        , extraModuleDependencies: defaultDependencies
        , runners: []
        , page: veggie.page//we need this object here for later use
};

veggie.layout.startUp = function () {

    console.debug("example.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (veggie.page.startUp) {
        console.debug("example.page.startUp");
        veggie.page.startUp();
    }
};

veggie.APPNAME = "VeggiesApp";//legacy
$(document).ready(veggie.layout.startUp);