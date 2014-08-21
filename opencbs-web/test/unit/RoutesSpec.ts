///<amd-dependency path="angular"/>
///<amd-dependency path="angular-mocks"/>
///<amd-dependency path="angular-route"/>
import AuthenticationHolder = require("../../app/ts/models/AuthenticationHolder");

describe("Routes configuration:", (): void => {

    var rootScope: ng.IScope;
    var route: ng.route.IRouteService;
    var location: ng.ILocationService;
    var httpBackend: ng.IHttpBackendService;

    var authenticationService: any;

    var angularMocks = angular.mock;

    // mock the app
    beforeEach((): ng.IModule => angular.mock.module("openCbs"));

    beforeEach(
        angular.mock.inject(function ($injector: ng.auto.IInjectorService): void {
            rootScope = $injector.get("$rootScope");
            route = $injector.get("$route");
            location = $injector.get("$location");
            httpBackend = $injector.get("$httpBackend");
        })
        );

    describe("Index route: ", (): void => {

        beforeEach(inject(function ($injector: any): void {
            authenticationService = $injector.get("authService");
        }));

        it("The index URL WITHOUT authorization redirects to the login page", (): void => {

            httpBackend.expectGET("views/main.html").respond(200, "main HTML");
            httpBackend.expectGET("views/login.html").respond(200, "login HTML");

            location.path("/");
            rootScope.$digest();
            httpBackend.flush();
            expect(route.current.templateUrl).toBe("views/login.html");
        });

        it("The index URL WITH authorization redirects to the index page", (): void => {

            httpBackend.expectGET("views/main.html").respond(200, "main HTML");

            authenticationService.authenticationHolder = new AuthenticationHolder("dummy-token", new Date(Date.now() - 900000), new Date(Date.now() - 900000), "Test User");
            location.path("/");
            rootScope.$digest();
            httpBackend.flush();
            expect(route.current.templateUrl).toBe("views/main.html");
        });

        afterEach((): void => {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });
    });

    describe("Login route: ", (): void => {

        beforeEach((): void => {
            httpBackend.expectGET("views/login.html").respond(200, "login HTML");
        });

        it("A direct URL to login without authorization loads Login", (): void => {
            location.path("/login");
            rootScope.$digest();
            httpBackend.flush();
            expect(route.current.templateUrl).toBe("views/login.html");
        });

        it("A direct URL to login with authorization still loads Login", (): void => {
            authenticationService.authenticationHolder = new AuthenticationHolder("dummy-token", new Date(Date.now() - 900000), new Date(Date.now() - 900000), "Test User");
            location.path("/login");
            rootScope.$digest();
            httpBackend.flush();
            expect(route.current.templateUrl).toBe("views/login.html");
        });

        it("A non-existing URL without authorization redirects to Login directly", (): void => {
            location.path("/not-existing/route/this/is-yes");
            rootScope.$digest();
            httpBackend.flush();
            expect(route.current.templateUrl).toBe("views/login.html");
        });

        afterEach((): void => {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });
    });
});
//});   */