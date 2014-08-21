define(["require", "exports", "../../app/ts/models/AuthenticationHolder", "angular"], function(require, exports, AuthenticationHolder) {
    QUnit.module("Test Group A");

    test("Qunit/RequireJS should work", function () {
        var a = new AuthenticationHolder("", null, null, "");
        var app = angular.mock.module("openCbs");

        equal(a.isAuthenticated(), false);
        ok(app);
    });

    QUnit.module("Test Group B");

    test("Qunit/RequireJS should work", function () {
        var a = new AuthenticationHolder("", null, null, "");
        equal(a.isAuthenticated(), false);
    });
});
//# sourceMappingURL=QUnitTest.js.map
