var app = angular.module("myApp", []);

app.controller("homeController", function ($scope, $http) {

    $scope.message = "Hello from AngularJS!";

    $scope.getData = function () {
        $http.get("/Home/GetMessage")
            .then(function (response) {
                $scope.serverMessage = response.data;
            });
    };
});