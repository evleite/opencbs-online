// create the Express App
var express = require('express');
var app = express();

// set the static folder (Ember.js)
app.use(express.static('app'));

/* This section is not needed as we only need static html for Ember. Templating is done client-side
// set up the server routes
var routes = require('./routes');

// view engine setup (handlebars)
app.set('views', 'views');
var expressHbs = require('express3-handlebars');
app.engine('hbs', expressHbs({ extname :'hbs'}));  //, defaultLayout: 'main.hbs'
app.set('view engine', 'hbs');
app.set('view engine', 'html');

// configure routes (check meaning)
app.use('/', routes);
*/

module.exports = app