// Karma configuration
// Generated on Sat Aug 09 2014 10:28:17 GMT+0200 (W. Europe Summer Time)
/*global module:false */

console.log('Start Karma configuration');

module.exports = function (config) {
    config.set({

        // base path that will be used to resolve all patterns (eg. files, exclude)
        basePath: '',

        // list of files / patterns to load in the browser
        files: [
            'test/test-main.js',
            { pattern: 'app/vendor/js/jquery/dist/jquery.js', included: false },
            { pattern: 'app/vendor/js/bootstrap/dist/js/bootstrap.min.js', included: false },
            { pattern: 'app/vendor/js/requirejs-domready/domReady.js', included: false },
            { pattern: 'app/vendor/js/angular/angular.js', included: false },
            { pattern: 'app/vendor/js/angular-route/angular-route.min.js', included: false },
            { pattern: 'app/vendor/js/ladda-bootstrap/dist/ladda.min.js', included: false },
            { pattern: 'app/vendor/js/ladda-bootstrap/dist/spin.min.js', included: false },
            { pattern: 'app/vendor/js/angular-mocks/angular-mocks.js', included: false },
            { pattern: 'app/ts/**/*.js', included: false },
            { pattern: 'test/**/*Spec.js', included: false }
        ],

        exclude: [
            'app/main.js'
        ],

        autoWatch: true,

        // frameworks to use
        // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
        frameworks: ['jasmine', 'requirejs'],

        // start these browsers
        // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
        browsers: ['Chrome'],

        plugins: [
                'karma-chrome-launcher',
                'karma-jasmine',
                'karma-requirejs'
        ],

        // web server port
        port: 9876,

        // enable / disable colors in the output (reporters and logs)
        colors: true,

        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_DEBUG,

        reporters: ['progress']
    });
};
