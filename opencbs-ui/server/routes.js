/* This section is not needed, index.html is loaded from the static app folder and routing is done client-side in Ember

var express = require('express');
var router = express.Router();

router.get('/', function(req, res) {
  res.render('index.html');
});

module.exports = router;
*/