import UrlService = require("../../../app/ts/services/UrlService");

describe("URLService, verify configured API urls", (): void => {
    var urlServiceInstance: any = new UrlService();

    it(" should return the appropriate URLS when called", (): void => {
        expect(urlServiceInstance.BASE_URL).toBe("/api");
        expect(urlServiceInstance.AUTHENTICATION_URL).toBe("/api/security/authenticate");
    });
});