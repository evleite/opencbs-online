/*jslint browser: true*/
/*global $, angular*/
/*global $, app*/

app.controller('LoginController', function ($scope, $location, authService) {
    "use strict";

    $scope.authenticationResult = null;
        
    $scope.credentials = {
        username: '',
        password: ''
    };


    $scope.login = function (credentials) {
        // authenticate using promise
        authService.authenticate(credentials)
            .then(function (result) {
                // successful authentication process, check the result
                if (result) {
                    // login valid
                    $scope.authenticationResult = null;
                    $location.path('/').replace();
                }
                else {
                    // login failed
                    $scope.authenticationResult = 'Login failed';
                }
                
            }, function (err) {
                // authentication process threw an error
                $scope.authenticationResult = err;
            });
    };

    /*
    $scope.login = function (credentials) {

        AuthService.login(credentials).then(function (user) {
            $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
            $scope.setCurrentUser(user);
        }, function () {
            $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
        });

    };*/
});