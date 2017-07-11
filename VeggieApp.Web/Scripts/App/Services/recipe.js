(function () {

    'use strict';

    angular.module('VeggiesApp')
        .factory('recipeService', recipeServiceFactory);

    function recipeServiceFactory() {

        var aRecipeServiceObject = veggie.services.recipe;
        return aRecipeServiceObject;
    };
})();