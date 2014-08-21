define(["require", "exports", "../../app/ts/models/AuthenticationHolder", "angular", "angular-mocks"], function(require, exports, AuthenticationHolder) {
    describe("Jasmine/RequireJS", function () {
        var a = new AuthenticationHolder("", null, null, "");
        var app = angular.mock.module("openCbs");

        it("should not fail on simple test", function () {
            expect(a.isAuthenticated()).toBe(false);
            expect(app).toBeDefined();
        });
    });
});
//# sourceMappingURL=JasmineTest.js.map
