var join = require("path").resolve;
var base = '';

var notify = require('gulp-notify');
var fs = require('fs');

module.exports = {
    base: base,
    output: './public/',
    path: {
        "scripts": join(base, "app/app.jsx"),
        "scriptsWatch": join(base, "app/**/*.js"),
        "jsxWatch": join(base, "app/**/*.jsx"),
        "jshintrc": join(base, ".jshintrc"),
        "less": join(base, "style/style.less"),
        "lessWatch": join(base, "style/**/*.less")
    },

    join: join,

    plumb: {
        errorHandler: notify.onError('Error: <%- error.message %>')
    }
};