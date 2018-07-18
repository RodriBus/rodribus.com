'use strict';

const del = require('del');
const gulp = require('gulp');
const rename = require('gulp-rename');
const pug = require('gulp-pug');
const pugI18n = require('gulp-i18n-pug');
const sass = require('gulp-sass');
const concat = require('gulp-concat');
const sourcemaps = require('gulp-sourcemaps');
const cleanCSS = require('gulp-clean-css');
const uglify = require('gulp-uglify');
const imagemin = require('gulp-imagemin');
const browserSync = require('browser-sync').create();
const yaml = require('js-yaml');
const fs = require('fs');

const cfg = yaml.safeLoad(fs.readFileSync('./config.yaml', 'utf8'));

const pugI18nOptions = {
  i18n: {
    dest: cfg.dist.root,
    locales: cfg.watch.src.locales
  },
  verbose: true,
  pretty: true
};

gulp.task('clean', () => {
  return del.sync(cfg.dist.root);
});

gulp.task('icon', () => {
  return gulp.src(`${cfg.src.root}/favicon.ico`)
    .pipe(gulp.dest(cfg.dist.root));
});

gulp.task('html', function () {
  return gulp.src(cfg.watch.src.pug)
    .pipe(pugI18n(pugI18nOptions))
    .pipe(rename(path => {
      if (path.dirname == cfg.defaultLocale) {
        path.dirname = '';
      }
    }))
    .pipe(gulp.dest(cfg.dist.root));
});

gulp.task('js', () => {
  return gulp.src(cfg.watch.src.js)
    .pipe(sourcemaps.init())
    .pipe(concat(`${cfg.bundleName}.min.js`))
    .pipe(uglify({
      mangle: {
        toplevel: true
      }
    }))
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

gulp.task('img', () => {
  return gulp.src(cfg.watch.src.img)
    .pipe(imagemin())
    .pipe(gulp.dest(cfg.dist.img))
    .pipe(browserSync.stream());
});

gulp.task('server', ['build'], () => {
  browserSync.init({
    server: {
      baseDir: cfg.dist.root
    }
  });

  gulp.watch([cfg.watch.src.pugAll, cfg.watch.src.locales], ['html']);
  gulp.watch(cfg.watch.src.scssAll, ['css']);
  gulp.watch(cfg.watch.src.js, ['js']);
  gulp.watch(cfg.watch.src.img, ['img']);

  gulp.watch([cfg.watch.dist.html, cfg.watch.dist.js]).on('change', browserSync.reload);
});

gulp.task('build', ['clean', 'icon', 'html', 'js', 'css', 'img']);
gulp.task('default', ['build']);
