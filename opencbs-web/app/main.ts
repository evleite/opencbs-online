require.config({
    enforceDefine: true,
    paths: {
        "jquery.bootstrap": "vendor/js/bootstrap.min",
        "jquery": "vendor/js/jquery.min",
        "domReady": "vendor/js/domReady",
        "angular": "vendor/js/angular.min",
        "angular-route": "vendor/js/angular-route.min",
        "ladda": "vendor/js/ladda.min",
        "spin": "vendor/js/spin.min"
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
define(["angular", "domReady!", "ts/app"], // "jquery", "jquery.bootstrap", 
    function (angular: ng.IAngularStatic, document: HTMLDocument): void {
        // bootstrap the document, since we are loading asynchronously
        angular.bootstrap(document, ["openCbs"]);
    }
    );