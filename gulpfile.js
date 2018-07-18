'use strict';

const del = require('del');
const gulp = require('gulp');
const pug = require('gulp-pug');
const sass = require('gulp-sass');
const concat = require('gulp-concat');
const sourcemaps = require('gulp-sourcemaps');
const cleanCSS = require('gulp-clean-css');
const uglify = require('gulp-uglify');
const browserSync = require('browser-sync').create();
const yaml = require('js-yaml');
const fs = require('fs');

const cfg = yaml.safeLoad(fs.readFileSync('./config.yaml', 'utf8'));

gulp.task('clean', () => {
  return del.sync(cfg.dist.root);
});

gulp.task('html', () => {
  return gulp.src(cfg.watch.src.pug)
    .pipe(pug({
      verbose: true,
      pretty: true
    }))
    .pipe(gulp.dest(cfg.dist.root));
});

gulp.task('js', () => {
  return gulp.src(cfg.watch.src.js)
    .pipe(sourcemaps.init())
    .pipe(concat(`${cfg.bundleName}.min.js`))
    .pipe(uglify())
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest(cfg.dist.js));
});

gulp.task('css', () => {
  return gulp.src(cfg.watch.src.scss)
    .pipe(sourcemaps.init())
    .pipe(sass().on('error', sass.logError))
    .pipe(concat(`${cfg.bundleName}.min.css`))
    .pipe(cleanCSS())
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest(cfg.dist.css))
    .pipe(browserSync.stream());
});

gulp.task('server', ['build'], () => {
  browserSync.init({
    server: {
      baseDir: cfg.dist.root
    }
  });

  gulp.watch(cfg.watch.src.pugAll, ['html']);
  gulp.watch(cfg.watch.src.scssAll, ['css']);
  gulp.watch(cfg.watch.src.js, ['js']);

  gulp.watch([cfg.watch.dist.html, cfg.watch.dist.js]).on('change', browserSync.reload);
});

gulp.task('build', ['clean', 'html', 'js', 'css']);
gulp.task('default', ['build']);
