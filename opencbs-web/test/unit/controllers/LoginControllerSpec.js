define(["require", "exports", "angular", "angular-mocks", "angular-route"], function(require, exports) {
    describe("LoginController Spec:", function () {
        //var LoginController = require("ts/controllers/LoginController");
        var rootScope;
        var location;

        //var loginController: any;
        //var httpBackend: ng.IHttpBackendService;
        var controller;

        beforeEach(function () {
            return angular.mock.module("openCbs");
        });

        beforeEach(inject(function ($injector) {
            rootScope = $injector.get("$rootScope");
            controller = $injector.get("$controller");
            location = $injector.get("$location");
            //httpBackend = $injector.get("$httpBackend");
            //loginController = controller("ts/controllers/LoginController",
            //{ $scope: rootScope, $location: location, authService: null });
        }));

        describe("The login method:", function () {
            //it("should do somthing ", (): void => {
            //loginController = controller("ts/controllers/LoginController",
            //{ $scope: rootScope, $location: location, authService: null });
            //loginController = new LoginController(rootScope, location, null);
            //expect(loginController.login(1)).toThrow();
            //});
        });
    });
});
//# sourceMappingURL=LoginControllerSpec.js.map
