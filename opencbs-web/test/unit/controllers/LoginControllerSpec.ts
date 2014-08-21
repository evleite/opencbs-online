///<amd-dependency path="angular"/>
///<amd-dependency path="angular-mocks"/>
///<amd-dependency path="angular-route"/>
import AuthenticationHolder = require("../../../app/ts/controllers/LoginController");

describe("LoginController Spec:", (): void => {

    //var LoginController = require("ts/controllers/LoginController");
    var rootScope: ng.IScope;
    var location: ng.ILocationService;
    //var loginController: any;
    //var httpBackend: ng.IHttpBackendService;
    var controller: ng.IControllerService;


    beforeEach((): void => angular.mock.module("openCbs"));

    beforeEach(
        inject(function ($injector: ng.auto.IInjectorService): void {
            rootScope = $injector.get("$rootScope");
            controller = $injector.get("$controller");
            location = $injector.get("$location");
            //httpBackend = $injector.get("$httpBackend");

            //loginController = controller("ts/controllers/LoginController", 
            //{ $scope: rootScope, $location: location, authService: null });

        }));

    describe("The login method:", (): void => {
        //it("should do somthing ", (): void => {

        //loginController = controller("ts/controllers/LoginController", 
        //{ $scope: rootScope, $location: location, authService: null });
        //loginController = new LoginController(rootScope, location, null);
        //expect(loginController.login(1)).toThrow();


        //});
    });


});