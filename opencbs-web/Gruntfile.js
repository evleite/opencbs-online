module.exports = function (grunt) {

    grunt.initConfig({
        clean: {
            vendor: ["app/vendor"]
        },

        concat: {
            cssVendor: {
                src: ["bower_components/bootstrap/dist/css/bootstrap.min.css",
                    "vendor_manual/sb-admin-2/css/plugins/metisMenu/metisMenu.css",
                    "vendor_manual/sb-admin-2/css/plugins/timeline.css",
                    "vendor_manual/sb-admin-2/css/sb-admin-2.css",
                    "vendor_manual/sb-admin-2/css/plugins/morris.css",
                    "vendor_manual/sb-admin-2/font-awesome-4.1.0/css/font-awesome.min.css",
                    "bower_components/ladda-bootstrap/dist/ladda-themeless.min.css"],
                dest: "app/vendor/lib.css"
            }
        },

        copy: {
            requireJs: {
                expand: true,
                src: ["bower_components/requirejs/require.js", "bower_components/requirejs-domready/domReady.js"],
                flatten: true,
                dest: "app/vendor/js"

            },
            qUnit: {
                files: [
                {
                    expand: true,
                    src: ["bower_components/qunit/qunit/qunit.css"],
                    flatten: true,
                    dest: "app/vendor/css"
                },
                {
                    expand: true,
                    src: ["bower_components/qunit/qunit/qunit.js"],
                    flatten: true,
                    dest: "app/vendor/js"
                }
                ]},
            jsVendor: {
                files: [{
                    expand: true,
                    cwd: "bower_components",
                    flatten: true,
                    src: ["**/*.min.js", "**/*.min.js.map"],
                    dest: "app/vendor/js"
                },
                {
                    expand: true,
                    cwd: "bower_components",
                    flatten: true,
                    src: ["jasmine/lib/jasmine-core/jasmine-html.js",
                        "jasmine/lib/jasmine-core/jasmine.js",
                        "angular-mocks/angular-mocks.js"],
                    dest: "app/vendor/js"
                },
                {
                    expand: true,
                    cwd: "vendor_manual/sb-admin-2",
                    flatten: true,
                    src: "**/*.js",
                    dest: "app/vendor/js/sb-admin-2"
                }
                ]
            },
            cssJasmine: {
                files: [{
                    expand: true,
                    cwd: "bower_components",
                    src: "jasmine/lib/jasmine-core/jasmine.css",
                    flatten: true,
                    dest: "app/vendor/css"
                }]
            },
            cssVendor: {
                files: [{
                    expand: true,
                    cwd: "bower_components",
                    src: "**/*.css",
                    flatten: true,
                    dest: "app/vendor/css"
                },
                {
                    expand: true,
                    cwd: "vendor_manual",
                    src: "**/*.css",
                    flatten: true,
                    dest: "app/vendor/css"
                }]
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-contrib-concat");

    grunt.registerTask("build:debug", "Building in debug mode", [
        "clean:vendor",
        "concat:cssVendor",
        "copy:jsVendor",
        "copy:requireJs",
        "copy:cssJasmine",
        "copy:qUnit"
    ]);

    grunt.registerTask("default", ["build:debug"]);

};
