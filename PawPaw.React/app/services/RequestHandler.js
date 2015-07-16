'use strict';
var _ = require('lodash');

var RequestHandler = {
	error: _.curry(function(reject, error) {
		reject({
			msg: 'Unknown error',
			devMsg: error.message
		});
	}),
	response: _.curry(function(resolve, reject, err, res){
		if(res.ok){
			resolve(res.body);
		}
		else{
			if(res.body){
				reject(res.body);
			}
			else{
				reject({
					userMessage: res.error.message,
					statusCode: res.status,
					developerMessage: 'Error not well handled from backend.'
				});
			}
		}
	})
};

module.exports = RequestHandler;