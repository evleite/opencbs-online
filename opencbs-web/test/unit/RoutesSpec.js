define(["require", "exports", "../../app/ts/models/AuthenticationHolder", "angular", "angular-mocks", "angular-route"], function(require, exports, AuthenticationHolder) {
    describe("Routes configuration:", function () {
        var rootScope;
        var route;
        var location;
        var httpBackend;

        var authenticationService;

        var angularMocks = angular.mock;

        // mock the app
        beforeEach(function () {
            return angular.mock.module("openCbs");
        });

        beforeEach(angular.mock.inject(function ($injector) {
            rootScope = $injector.get("$rootScope");
            route = $injector.get("$route");
            location = $injector.get("$location");
            httpBackend = $injector.get("$httpBackend");
        }));

        describe("Index route: ", function () {
            beforeEach(inject(function ($injector) {
                authenticationService = $injector.get("authService");
            }));

            it("The index URL WITHOUT authorization redirects to the login page", function () {
                httpBackend.expectGET("views/main.html").respond(200, "main HTML");
                httpBackend.expectGET("views/login.html").respond(200, "login HTML");

                location.path("/");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            it("The index URL WITH authorization redirects to the index page", function () {
                httpBackend.expectGET("views/main.html").respond(200, "main HTML");

                authenticationService.authenticationHolder = new AuthenticationHolder("dummy-token", new Date(Date.now() - 900000), new Date(Date.now() - 900000), "Test User");
                location.path("/");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/main.html");
            });

            afterEach(function () {
                httpBackend.verifyNoOutstandingExpectation();
                httpBackend.verifyNoOutstandingRequest();
            });
        });

        describe("Login route: ", function () {
            beforeEach(function () {
                httpBackend.expectGET("views/login.html").respond(200, "login HTML");
            });

            it("A direct URL to login without authorization loads Login", function () {
                location.path("/login");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            it("A direct URL to login with authorization still loads Login", function () {
                authenticationService.authenticationHolder = new AuthenticationHolder("dummy-token", new Date(Date.now() - 900000), new Date(Date.now() - 900000), "Test User");
                location.path("/login");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            it("A non-existing URL without authorization redirects to Login directly", function () {
                location.path("/not-existing/route/this/is-yes");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            afterEach(function () {
                httpBackend.verifyNoOutstandingExpectation();
                httpBackend.verifyNoOutstandingRequest();
            });
        });
    });
});
//});   */
//# sourceMappingURL=RoutesSpec.js.map
