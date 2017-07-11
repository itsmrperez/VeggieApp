var example = {
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

example.moduleOptions = {
    APPNAME: "VeggiesApp"
        , extraModuleDependencies: defaultDependencies
        , runners: []
        , page: example.page//we need this object here for later use
};

example.layout.startUp = function () {

    console.debug("example.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (example.page.startUp) {
        console.debug("example.page.startUp");
        example.page.startUp();
    }
};

example.APPNAME = "VeggiesApp";//legacy
$(document).ready(example.layout.startUp);