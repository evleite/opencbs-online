// define the Express App
var app = require('./server/app')
require('./server/routes')

app.set('port', process.env.PORT || 3000);

var server = app.listen(app.get('port'), function(){ console.log('Listening on port %d', server.address().port) });