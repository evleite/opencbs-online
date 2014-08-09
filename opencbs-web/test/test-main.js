/// <reference path="D:\code\himm-it\opencbs-online\opencbs-web\app/vendor/js/angular-mocks/angular-mocks.js" />
/// <reference path="D:\code\himm-it\opencbs-online\opencbs-web\app/vendor/js/jquery/dist/jquery.js" />
var tests = [];
console.log('Start reading [test-main.js], reading files:');
for (var file in window.__karma__.files) {
    if (window.__karma__.files.hasOwnProperty(file)) {
        if (/Spec\.js$/.test(file)) {
            console.log('Test found: ' + file);
            tests.push(file);
        }
    }
}

requirejs.config({
    baseUrl: '/base/app',
    paths: {
        "jquery": "vendor/js/jquery/dist/jquery",
        "jquery.bootstrap": "vendor/js/bootstrap/dist/js/bootstrap.min",
        "domReady": "vendor/js/requirejs-domready/domReady",
        "angular": "vendor/js/angular/angular",
        "angular-route": "vendor/js/angular-route/angular-route.min",
        "angular-mocks": "vendor/js/angular-mocks/angular-mocks",
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
        'angular-mocks': {
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