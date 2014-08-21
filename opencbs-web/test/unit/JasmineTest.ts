///<amd-dependency path="angular"/>
///<amd-dependency path="angular-mocks"/>
import AuthenticationHolder = require("../../app/ts/models/AuthenticationHolder");

describe("Jasmine/RequireJS", (): void => {
    var a: AuthenticationHolder = new AuthenticationHolder("", null, null, "");
    var app = angular.mock.module("openCbs");

    it("should not fail on simple test", (): void => {
        expect(a.isAuthenticated()).toBe(false);
        expect(app).toBeDefined();
    });

});