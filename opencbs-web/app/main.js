require.config({
    enforceDefine: true,
    paths: {
        "jquery.bootstrap": "vendor/js/bootstrap/dist/js/bootstrap.min",
        "jquery": "vendor/js/jquery/dist/jquery",
        "domReady": "vendor/js/requirejs-domready/domReady",
        "angular": "vendor/js/angular/angular",
        "angular-route": "vendor/js/angular-route/angular-route.min",
        "ladda": "vendor/js/ladda-bootstrap/dist/ladda.min",
        "spin": "vendor/js/ladda-bootstrap/dist/spin.min"
    },
    shim: {
        "angular": {
            exports: "angular",
            deps: ["jquery", "domReady!"]
        },
        "angular-route": {
            exports: "angular",
            deps: ["angular"]
        },
        "jquery.bootstrap": {
            exports: "$",
            deps: ["jquery"]
        },
        "ladda": {
            exports: "Ladda",
            deps: ["spin"]
        },
        "spin": {
            exports: "Spin",
            deps: ["jquery.bootstrap"]
        }
    }
});

// startup the application
define(["angular", "domReady!", "jquery", "jquery.bootstrap", "ts/app"], function (angular, document) {
    // bootstrap the document, since we are loading asynchronously
    console.debug("Bootstrap [openCbs]");
    angular.bootstrap(document, ["openCbs"]);
});
//# sourceMappingURL=main.js.map
