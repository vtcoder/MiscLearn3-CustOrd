/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('_output-bower-bootstrap', function () {
    console.log('*** Copying bootstrap output files from bower components...');
    var filesStream = gulp.src(
        [
            './bower_components/lib/bootstrap/dist/**/*.*',     /*Include all distribution files*/
            '!./bower_components/lib/bootstrap/dist/**/npm.js'  /*Exclude NPM script file*/
        ]);
    filesStream.pipe(gulp.dest('./wwwroot/lib/bootstrap/'));
    return filesStream;
});

gulp.task('_output-bower-jquery', function () {
    console.log('*** Copying jquery output files from bower components...');
    var filesStream = gulp.src(
        [
            './bower_components/lib/jquery/dist/**/*.*',     /*Include all distribution files*/
            '!./bower_components/lib/jquery/dist/**/npm.js'  /*Exclude NPM script file*/
        ]);
    filesStream.pipe(gulp.dest('./wwwroot/lib/jquery/'));
    return filesStream;
});

gulp.task('output-bower-distribution-content', ['_output-bower-bootstrap', '_output-bower-jquery'], function () {
});