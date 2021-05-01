'use strict';

var gulp = require('gulp');
const browserSync = require('browser-sync').create();
var sass = require('gulp-sass');
const autoPrefixer = require('gulp-autoprefixer');
sass.compiler = require('node-sass');

gulp.task('sass', function () {
  return gulp
    .src('./scss/main.scss')
    .pipe(autoPrefixer('last 2 version'))
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('./css'))
    .pipe(browserSync.stream());
});

gulp.task('sass:watch', function () {
  gulp.watch('./scss/**/*.scss', gulp.series('sass'));
});


