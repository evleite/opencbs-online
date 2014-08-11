define(["angular", "angular-mocks", "angular-route"], function (angular, angularMocks, angularRoute) {
    describe("Routes configuration Spec", function () {
        var rootScope;
        var route;
        var location;
        var httpBackend;

        var authenticationService;

        // mock the app
        beforeEach(function () {
            return angularMocks.module("openCbs");
        });

        beforeEach(inject(function ($injector) {
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

                authenticationService.accessToken = "dummy-token";
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
                authenticationService.accessToken = "dummy-token";
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
//# sourceMappingURL=RoutesSpec.js.map
