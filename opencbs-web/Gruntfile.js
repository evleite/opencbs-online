/// <reference path="" />
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
                src: ["bower_components/requirejs/require.js"],
                flatten: true,
                dest: "app/vendor"
                
            },
            jsVendor: {
                files: [{
                    expand: true,
                    cwd: "bower_components",
                    //flatten: true,
                    src: ["**/*.js", "**/*.map"],
                    dest: "app/vendor/js"
                },
                {
                    expand: true,
                    cwd: "vendor_manual",
                    //flatten: true,
                    src: "**/*.js",
                    dest: "app/vendor/js"
                }
                ]
            },
            cssVendor: {
                files: [{
                    expand: true,
                    cwd: "bower_components",
                    src: "**/*.css",
                    dest: "app/vendor/css"
                },
                {
                    expand: true,
                    cwd: "vendor_manual",
                    src: "**/*.css",
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
        "copy:requireJs"
    ]);

    grunt.registerTask("default", ["build:debug"]);

};
