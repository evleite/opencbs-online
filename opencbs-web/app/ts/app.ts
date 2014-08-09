/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../../typings/requirejs/require.d.ts" />
///<amd-dependency path="angular"/>
///<amd-dependency path="angular-route"/>

import loginController = require("ts/controllers/LoginController");
import AuthService = require("ts/services/AuthService");
import UrlService = require("ts/services/UrlService");

export class OpenCbs {
    angular: ng.IAngularStatic = require("angular");
    app: ng.IModule;

    constructor(name: string, modules: Array<string>) {
        this.app = angular.module(name, modules);
        // this.app = angular.module("openCbs", ["ngRoute"]);
    }

    addController(name: string, controllerFn: Function) {
        this.app.controller(name, controllerFn);
    }

    addControllerInline(name: string, inlineAnnotatedConstructor: any[]) {
        this.app.controller(name, inlineAnnotatedConstructor);
    }

    addService(name: string, serviceFn: Function): void {
        this.app.service(name, serviceFn);
    }

    startUp(): void {
        this.app.run(function ($rootScope, $location, $window, authService) {

            $rootScope.$on("$routeChangeStart",
                function (evt, next, current) {
                    // If the user is NOT logged in
                    if (!authService.isAuthenticated()) {

                        if (next.templateUrl === "views/login.html") {

                        }
                        else {
                            $location.path("/login");
                        }
                    }
                });
        });
    }


    configure(): void {
        this.app.config(["$routeProvider", function ($routeProvider) {

            $routeProvider
                .when("/", {
                    templateUrl: "views/main.html"
                })
                .when("/login", {
                    templateUrl: "views/login.html"
                })
                .otherwise({ redirecTo: "/" });

        }]);
    }
}

export module OpenCbsBootstrap {

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
}