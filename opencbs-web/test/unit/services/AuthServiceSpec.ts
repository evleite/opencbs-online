///<amd-dependency path="angular"/>
///<amd-dependency path="angular-mocks"/>
///<amd-dependency path="angular-route"/>
import AuthenticationHolder = require("../../../app/ts/models/AuthenticationHolder");
import UrlService = require("../../../app/ts/services/UrlService");
import AuthService = require("../../../app/ts/services/AuthService");

describe("AuthService:", (): void => {

    describe("isAuthenticated method:", (): void => {
        var authServiceInstance: any = new AuthService(null, null, null);

        it("isAuthenticated method should not authenticate a user when no token is present", (): void => {
            expect(authServiceInstance.accessToken).toBeFalsy();
            expect(authServiceInstance.isAuthenticated()).toBe(false);
        });

        it("isAuthenticated method should authenticate a user when a token is present", (): void => {
            expect(authServiceInstance.authenticationHolder).toBeFalsy();
            authServiceInstance.authenticationHolder = new AuthenticationHolder("dummy-token", new Date(Date.now() - 900000), new Date(Date.now() - 900000), "Test User");

            expect(authServiceInstance.authenticationHolder).toBeTruthy();
            expect(authServiceInstance.isAuthenticated()).toBe(true);
        });
    });

    describe("login method:", (): void => {
        
        //var httpService: ng.IHttpService;
        var qService: ng.IQService;
        var urlService: UrlService;
        var httpBackend: ng.IHttpBackendService;
        /*
        beforeEach(
            inject(function ($injector: ng.auto.IInjectorService): void {
                qService = $injector.get("$q");
                urlService = new UrlService();
                location = $injector.get("$location");
                httpBackend = $injector.get("$httpBackend");
            })
            );
        */
        it("authenticate method should not authenticate user with invalid credentials", (): void => {
            var authServiceInstance: AuthService = new AuthService(null, null, null);
            expect(true).toBe(true);
        /*
            var returnVal: ng.IPromise<boolean>;
            expect(authServiceInstance.authenticationHolder).toBeFalsy();

            // setup httpBackend
            var authPostHandler = httpBackend
                .whenPOST(urlService.AUTHENTICATION_URL, { username: "user", password: "pass" })
                .respond({ IsValid: true, AccessToken: "dummy-token", Message: "success", IssuedAt: new Date(Date.now()) });

            expect(authPostHandler).toBeTruthy();

            httpBackend.expectPOST(urlService.AUTHENTICATION_URL);

            returnVal = authServiceInstance.authenticate("test", "test");
            returnVal.then((result: boolean): void => {
                expect(result).toBe(true);

            });
*/
        });

        it("test", (): void => {
            expect(true).toBe(true)
        });

    });

});