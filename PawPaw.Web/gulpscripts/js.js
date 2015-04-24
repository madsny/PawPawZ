var gulp = require('gulp');
var _ = require('./utils');
var source = require('vinyl-source-stream');
var buffer = require('gulp-buffer');
var uglify = require('gulp-uglify');
var _if = require('gulp-if');
var notify = require('gulp-notify');
var jshint = require('gulp-jshint');
var plumber = require('gulp-plumber');

var args = require('yargs').argv;
var isProduction = !!args.production;

var browserify = require('browserify');
var reactify = require('reactify');

gulp.task('js', ['js-lint'], function () {
    var options = {
        debug: !isProduction
    };

    var b = browserify(options);
    b.transform('reactify');
    b.add(_.path.scripts);

    b.bundle()
        .on('error', _.plumb.errorHandler)
        .pipe(source('app.bundle.js'))

        .pipe(_if(isProduction, buffer()))
        .pipe(_if(isProduction, uglify()))

        .pipe(gulp.dest(_.join(_.output, 'js/')))
        .pipe(notify('Compiled javascript'));
});

gulp.task('js-lint', function () {
    return gulp.src([_.path.scriptsWatch])
        .pipe(jshint(_.path.jshintrc))
        .pipe(notify(function (file) {
            if (file.jshint.success) {
                return false;
            }
            var errors = file.jshint.results.map(function (data) {
                return data.error.reason + " [" + data.error.line + ":" + data.error.character + "]";
            }).join("\n");

            return errors + " " +file.relative;
        }));
});


gulp.task('watch-js', ['js'], function () {
    gulp.watch([_.path.scriptsWatch, _.path.templatesWatch, _.path.scriptsIgnore], ['js']);
});
