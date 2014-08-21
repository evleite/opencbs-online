require.config({
    enforceDefine: true,
    baseUrl: "../app",
    paths: {
        "angular-mocks": "vendor/js/angular-mocks"
    },
    shim: {
        "angular-mocks": {
            deps: ["angular"],
            exports: "angular.mock"
        }
    }
});

// Define all of your specs here. These are RequireJS modules.
var specs = [
    "../test/unit/RoutesSpec",
    "../test/unit/services/UrlServiceSpec",
    "../test/unit/services/AuthServiceSpec",
    "../test/unit/controllers/LoginControllerSpec"
];

define(["main"], function () {
    // Load the specs
    require(specs, function () {
        jasmine.getEnv().execute();
    });
});
//# sourceMappingURL=specRunner.js.map
