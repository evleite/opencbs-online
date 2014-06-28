module.exports = function(grunt) {

    // Project configuration.
    /*
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        uglify: {
            options: {
                banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd") %> * /\n'
            },
            build: {
                src: 'src/<%= pkg.name %>.js',
                dest: 'build/<%= pkg.name %>.min.js'
            }
        }
    });
*/

    grunt.initConfig({

        clean: {
            debug: ['app/lib']
        },

        copy: {
            debug: {
                files: [
                    { src: 'lib/angular/angular.js', dest: 'app/lib/js/angular.js' },
                    { src: 'lib/jquery/dist/jquery.js', dest: 'app/lib/js/jquery.js' },
                    { src: 'lib/bootstrap/dist/js/bootstrap.js', dest: 'app/lib/js/bootstrap.js' },
                    { src: 'lib/bootstrap/dist/css/bootstrap-theme.css', dest: 'app/lib/css/bootstrap-theme.css' },
                    { src: 'lib/bootstrap/dist/css/bootstrap.css', dest: 'app/lib/css/bootstrap.css' },
                    { expand: true, cwd: 'lib/bootstrap/dist/fonts/', src: '**', dest: 'app/lib/fonts/', flatten: true }

                ]

            }
        }
    });


    // Load the plugins
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    // Default task(s).

    grunt.registerTask('build:debug', "Building in debug mode", [
        'clean:debug',
        'copy:debug'
    ]);

    grunt.registerTask('default', ['build:debug']);

};