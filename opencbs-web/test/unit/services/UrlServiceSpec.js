define(["require", "exports", "../../../app/ts/services/UrlService"], function(require, exports, UrlService) {
    describe("URLService, verify configured API urls", function () {
        var urlServiceInstance = new UrlService();

        it(" should return the appropriate URLS when called", function () {
            expect(urlServiceInstance.BASE_URL).toBe("/api");
            expect(urlServiceInstance.AUTHENTICATION_URL).toBe("/api/security/authenticate");
        });
    });
});
//# sourceMappingURL=UrlServiceSpec.js.map
