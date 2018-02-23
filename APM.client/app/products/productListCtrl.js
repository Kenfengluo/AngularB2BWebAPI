(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("productListCtrl",
                     ["productResource",ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;
        vm.searchCriteria = "GDN"
        productResource.query({
            $filter: "substringof('GDN', ProductCode)",
            $orderby: "Price desc"
        }, function (data) {
        vm.products = data;
        });
    }
}());
