/*global requirejs*/

var tests = [];

for (var file in window.__karma__.files) {
    if (window.__karma__.files.hasOwnProperty(file)) {
        if (/Spec\.js$/.test(file)) {
            tests.push(file);
        }
    }
}

requirejs.config({
    baseUrl: '/base/app',
    paths: {
        "jquery.bootstrap": "vendor/js/bootstrap.min",
        "jquery": "vendor/js/jquery.min",
        "domReady": "vendor/js/domReady",
        "angular": "vendor/js/angular.min",
        "angular-route": "vendor/js/angular-route.min",
        "angular-mocks": "vendor/js/angular-mocks",
        "ladda": "vendor/js/ladda.min",
        "spin": "vendor/js/spin.min"
    },

    shim: {
        "angular": {
            exports: "angular",
            deps: ["jquery", "domReady"]
        },
        "angular-route": {
            exports: "angular",
            deps: ["angular"]
        },
        "angular-mocks": {
            deps: ["angular"],
            exports: "angular.mock"
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
    },

    // ask Require.js to load these files (all our tests)
    deps: tests,

    // start test run, once Require.js is done
    callback: window.__karma__.start
});