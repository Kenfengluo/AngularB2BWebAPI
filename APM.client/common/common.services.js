(function () {
    "use strict";

    var app = angular.module("common.services",
                            ["ngResource"])
                     .constant("appSettings",
                     {
                         serverPath: 'http://localhost:60241/'
                     });

}());