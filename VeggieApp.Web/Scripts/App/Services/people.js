﻿(function () {

    'use strict';

    angular.module('VeggiesApp')
        .factory('peopleService', peopleServiceFactory);

    function peopleServiceFactory() {

        var aPeopleServiceObject = example.services.people;
        console.log('People Service created successfully');
        return aPeopleServiceObject;
    };
})();