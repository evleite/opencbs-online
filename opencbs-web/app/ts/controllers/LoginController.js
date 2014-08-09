define(["require", "exports", "jquery", "jquery.bootstrap", "spin", "ladda"], function(require, exports) {
    var LoginController = (function () {
        function LoginController($scope, $location, authService) {
            this.$scope = $scope;
            this.$location = $location;
            this.authService = authService;
            $scope.vm = this;
        }
        LoginController.prototype.login = function (username, password) {
            var _this = this;
            var Ladda = require("ladda");

            // reset the submitted flag
            this.$scope.loginForm.submitted = false;

            // check whether the form is valid
            if (!this.$scope.loginForm.$valid) {
                this.$scope.loginForm.submitted = true;
                return;
            }

            // if the for is valid continue
            var btnLoginSubmit = document.getElementById("btnLoginSubmit");
            var l = Ladda.create(btnLoginSubmit);
            l.start();

            // authenticate using promise
            this.authService.authenticate(username, password).then(function (result) {
                // successful authentication process, check the result
                if (result) {
                    // login valid
                    _this.$scope.authenticationResult = null;
                    _this.$location.path("/").replace();
                } else {
                    // login failed
                    _this.$scope.authenticationResult = "Login failed";
                }
                l.stop();
            }, function (err) {
                // authentication process threw an error
                _this.$scope.authenticationResult = err;
                l.stop();
            });
        };
        LoginController.$inject = ["$scope", "$location", "authService"];
        return LoginController;
    })();
    exports.LoginController = LoginController;
});
//# sourceMappingURL=LoginController.js.map
