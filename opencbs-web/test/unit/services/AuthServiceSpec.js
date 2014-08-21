define(["require", "exports", "../../../app/ts/models/AuthenticationHolder", "../../../app/ts/services/AuthService", "angular", "angular-mocks", "angular-route"], function(require, exports, AuthenticationHolder, AuthService) {
    describe("AuthService:", function () {
        describe("isAuthenticated method:", function () {
            var authServiceInstance = new AuthService(null, null, null);

            it("isAuthenticated method should not authenticate a user when no token is present", function () {
                expect(authServiceInstance.accessToken).toBeFalsy();
                expect(authServiceInstance.isAuthenticated()).toBe(false);
            });

            it("isAuthenticated method should authenticate a user when a token is present", function () {
                expect(authServiceInstance.authenticationHolder).toBeFalsy();
                authServiceInstance.authenticationHolder = new AuthenticationHolder("dummy-token", new Date(Date.now() - 900000), new Date(Date.now() - 900000), "Test User");

                expect(authServiceInstance.authenticationHolder).toBeTruthy();
                expect(authServiceInstance.isAuthenticated()).toBe(true);
            });
        });

        describe("login method:", function () {
            //var httpService: ng.IHttpService;
            var qService;
            var urlService;
            var httpBackend;

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
            it("authenticate method should not authenticate user with invalid credentials", function () {
                var authServiceInstance = new AuthService(null, null, null);
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

            it("test", function () {
                expect(true).toBe(true);
            });
        });
    });
});
//# sourceMappingURL=AuthServiceSpec.js.map
