'use strict';
var Request = require('superagent');
var Promise = require('bluebird');
var RequestHandler = require('./RequestHandler');

var GroupClient = {
	get: function(){
		return new Promise(function(resolve, reject){
			Request
				.get('/api/groups/')
				.on('error', RequestHandler.error(reject))
				.end(function(err, res){
					RequestHandler.response(resolve, reject, err, res);
				});
		});
	}
};

module.exports = GroupClient;