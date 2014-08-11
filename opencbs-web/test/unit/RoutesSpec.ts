declare var define: RequireDefine;

define(["angular", "angular-mocks", "angular-route"],
    (angular: ng.IAngularStatic, angularMocks: ng.IMockStatic, angularRoute: ng.route.IRouteService) => { 
    
    describe("Routes configuration Spec", () => {
        
        var rootScope: ng.IScope;
        var route: ng.route.IRouteService;
        var location: ng.ILocationService;
        var httpBackend: ng.IHttpBackendService;

        var authenticationService: any;

        // mock the app
        beforeEach(() => angularMocks.module("openCbs"));

        beforeEach(
            inject(function ($injector) {
                rootScope = $injector.get("$rootScope");
                route = $injector.get("$route");
                location = $injector.get("$location");
                httpBackend = $injector.get("$httpBackend");
            })
        );

        describe("Index route: ", () => {

            beforeEach(inject(function ($injector: any) {
                authenticationService = $injector.get("authService");
            }));

            it("The index URL WITHOUT authorization redirects to the login page", () => {

                httpBackend.expectGET("views/main.html").respond(200, "main HTML");
                httpBackend.expectGET("views/login.html").respond(200, "login HTML");

                location.path("/");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            it("The index URL WITH authorization redirects to the index page", () => {

                httpBackend.expectGET("views/main.html").respond(200, "main HTML");
                
                authenticationService.accessToken = "dummy-token";
                location.path("/");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/main.html");
            });

            afterEach(() => {
                httpBackend.verifyNoOutstandingExpectation();
                httpBackend.verifyNoOutstandingRequest();
            });
        });

        describe("Login route: ", () => {

            beforeEach(()=> {
                httpBackend.expectGET("views/login.html").respond(200, "login HTML");
            });

            it("A direct URL to login without authorization loads Login", () => {
                location.path("/login");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            it("A direct URL to login with authorization still loads Login", () => {
                authenticationService.accessToken = "dummy-token";
                location.path("/login");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            it("A non-existing URL without authorization redirects to Login directly", () => {
                location.path("/not-existing/route/this/is-yes");
                rootScope.$digest();
                httpBackend.flush();
                expect(route.current.templateUrl).toBe("views/login.html");
            });

            afterEach(() => {
                httpBackend.verifyNoOutstandingExpectation();
                httpBackend.verifyNoOutstandingRequest();
            });


        });
           
        


       
        

    });

});   