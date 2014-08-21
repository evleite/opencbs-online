///<amd-dependency path="angular"/>
import AuthenticationHolder = require("../../app/ts/models/AuthenticationHolder");

QUnit.module("Test Group A");

test("Qunit/RequireJS should work", (): void => {
    var a: AuthenticationHolder = new AuthenticationHolder("", null, null, "");
    var app = angular.mock.module("openCbs");
    
    equal(a.isAuthenticated(), false);
    ok(app);
});

QUnit.module("Test Group B");

test("Qunit/RequireJS should work", (): void => {
    var a: AuthenticationHolder = new AuthenticationHolder("", null, null, "");
    equal(a.isAuthenticated(), false);
});