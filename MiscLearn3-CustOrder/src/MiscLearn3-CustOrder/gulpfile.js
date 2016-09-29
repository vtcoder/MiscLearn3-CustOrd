/// <binding AfterBuild='main-compile' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var gulpSass = require('gulp-sass');

/*
Gulp tasks to copy bower client-side package content to wwwroot.
*/

gulp.task('_output-bower-bootstrap-sass', function () {
    console.log('*** Copying bootstrap SASS output files from bower components...');
    var filesStream = gulp.src(
        [
            './bower_components/lib/bootstrap-sass/assets/**/*.*'     /*Include all distribution files*/
        ]);
    filesStream.pipe(gulp.dest('./wwwroot/lib/bootstrap-sass/'));
    return filesStream;
});

//gulp.task('_output-bower-bootstrap', function () {
//    console.log('*** Copying bootstrap output files from bower components...');
//    var filesStream = gulp.src(
//        [
//            './bower_components/lib/bootstrap/dist/**/*.*',     /*Include all distribution files*/
//            '!./bower_components/lib/bootstrap/dist/**/npm.js'  /*Exclude NPM script file*/
//        ]);
//    filesStream.pipe(gulp.dest('./wwwroot/lib/bootstrap/'));
//    return filesStream;
//});

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

gulp.task('_output-bower-font-awesome', function () {
    console.log('*** Copying font awesome output files from bower components...');
    var filesStream = gulp.src(
        [
            './bower_components/lib/font-awesome/css/**/*.*',   /*Include all css distribution files*/
            './bower_components/lib/font-awesome/fonts/**/*.*'  /*Include all font distribution files*/
        ], { base: 'bower_components/lib/font-awesome' });      /*Make gulp copy all folders under font-awesome directory instead of just files*/
    filesStream.pipe(gulp.dest('./wwwroot/lib/font-awesome/'));
    return filesStream;
});

gulp.task('output-bower-distribution-content', ['_output-bower-bootstrap-sass', '_output-bower-jquery', '_output-bower-font-awesome'], function () {
});

/*
Gulp tasks to compile SASS.
*/

gulp.task('compile-sass', function () {
    console.log('*** Compiling SASS files to CSS...');
    var fileStream = gulp.src('./wwwroot/css/main.scss');
    fileStream = fileStream.pipe(gulpSass());
    fileStream = fileStream.pipe(gulp.dest('./wwwroot/css/'));
    return fileStream;
});

/*
Main compile tasks. These should role up individual tasks to cover what should happen when the project is compiled.
*/

gulp.task('main-compile', ['output-bower-distribution-content', 'compile-sass'], function () { });