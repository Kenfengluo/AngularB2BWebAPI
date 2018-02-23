(function () {
    "use strict";

    var app = angular.module("common.services")
                     .factory("productResource",
                     ["$resource", "appSettings", productResource])

    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/products/:id", null, 
            {
                'update': { method: 'PUT'} 
            });
    }
                     

}());