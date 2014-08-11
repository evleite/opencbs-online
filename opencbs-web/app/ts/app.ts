/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
/// <reference path="../../typings/requirejs/require.d.ts" />
///<amd-dependency path="angular"/>
///<amd-dependency path="angular-route"/>

import loginController = require("ts/controllers/LoginController");
import AuthService = require("ts/services/AuthService");
import UrlService = require("ts/services/UrlService");

export class OpenCbs {

    app: ng.IModule;

    constructor(app: ng.IModule) {
        this.app = app;
    }

    addController(name: string, controllerFn: Function): void {
        this.app.controller(name, controllerFn);
    }

    addControllerInline(name: string, inlineAnnotatedConstructor: any[]): void {
        this.app.controller(name, inlineAnnotatedConstructor);
    }

    addService(name: string, serviceFn: Function): void {
        this.app.service(name, serviceFn);
    }

    startUp(): void {
        this.app.run(
            function ($rootScope: ng.IRootScopeService,
                $location: ng.ILocationService,
                $window: ng.IWindowService,
                authService: AuthService): void {

            $rootScope.$on("$routeChangeStart",
                function (evt: ng.IAngularEvent, next: ng.route.IRoute, current: ng.route.IRoute): void {
                    // If the user is NOT logged in
                    if (!authService.isAuthenticated()) {
                        if (next.templateUrl !== "views/login.html") {
                            $location.path("/login");
                        }
                    }
                });
        });
    }

    configure(): void {
        this.app.config(["$routeProvider", function ($routeProvider: ng.route.IRouteProvider): void {
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

// declare the main AngularJS module as global var
var openCbsApp: ng.IModule = angular.module("openCbs", ["ngRoute"]);
var openCbs: OpenCbs = new OpenCbs(openCbsApp);

// load the controllers
openCbs.addControllerInline("loginController", ["$scope", "$location", "authService", loginController.LoginController]);

// load the services
openCbs.addService("authService", AuthService);
openCbs.addService("urlService", UrlService);

// configure the application
openCbs.configure();

// execute initial run code
openCbs.startUp();