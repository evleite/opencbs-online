/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../../typings/requirejs/require.d.ts" />
///<amd-dependency path="angular"/>
///<amd-dependency path="angular-route"/>
define(["require", "exports", "ts/controllers/LoginController", "ts/services/AuthService", "ts/services/UrlService", "angular", "angular-route"], function(require, exports, loginController, AuthService, UrlService) {
    var OpenCbs = (function () {
        function OpenCbs(name, modules) {
            this.angular = require("angular");
            this.app = angular.module(name, modules);
            // this.app = angular.module("openCbs", ["ngRoute"]);
        }
        OpenCbs.prototype.addController = function (name, controllerFn) {
            this.app.controller(name, controllerFn);
        };

        OpenCbs.prototype.addControllerInline = function (name, inlineAnnotatedConstructor) {
            this.app.controller(name, inlineAnnotatedConstructor);
        };

        OpenCbs.prototype.addService = function (name, serviceFn) {
            this.app.service(name, serviceFn);
        };

        OpenCbs.prototype.startUp = function () {
            this.app.run(function ($rootScope, $location, $window, authService) {
                $rootScope.$on("$routeChangeStart", function (evt, next, current) {
                    // If the user is NOT logged in
                    if (!authService.isAuthenticated()) {
                        if (next.templateUrl === "views/login.html") {
                        } else {
                            $location.path("/login");
                        }
                    }
                });
            });
        };

        OpenCbs.prototype.configure = function () {
            this.app.config([
                "$routeProvider", function ($routeProvider) {
                    $routeProvider.when("/", {
                        templateUrl: "views/main.html"
                    }).when("/login", {
                        templateUrl: "views/login.html"
                    }).otherwise({ redirecTo: "/" });
                }]);
        };
        return OpenCbs;
    })();
    exports.OpenCbs = OpenCbs;

    (function (OpenCbsBootstrap) {
        // load the main app
        var openCbs = new OpenCbs("openCbs", ["ngRoute"]);

        // load the controllers
        openCbs.addControllerInline("loginController", ["$scope", "$location", "authService", loginController.LoginController]);

        // load the services
        openCbs.addService("authService", AuthService);
        openCbs.addService("urlService", UrlService);

        // configure the application
        openCbs.configure();

        // execute initial run code
        openCbs.startUp();
    })(exports.OpenCbsBootstrap || (exports.OpenCbsBootstrap = {}));
    var OpenCbsBootstrap = exports.OpenCbsBootstrap;
});
//# sourceMappingURL=app.js.map
