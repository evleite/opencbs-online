/*jslint browser: true*/
/*global $, angular*/

// define the root app
var app = angular.module('openCbs', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'views/main.html'
        })
        .when('/login', {
            templateUrl: 'views/login.html'
        })
        .otherwise({ redirecTo: '/' });

}]);

// application wide authentication
app.run(function ($rootScope, $location, $window, authService) {
    
    $rootScope.$on('$routeChangeStart',
        function (evt, next, current) {
            // If the user is NOT logged in
            if (!authService.isAuthenticated()) {

                if (next.templateUrl === "views/login.html") {
                
                }
                else {
                    $location.path('/login');
                }
            }
        });
});