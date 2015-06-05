'use strict';
var $ = require('jquery');

module.exports = function(url, success, error){
	$.ajax({
			url: url,
			dataType: 'json',
			cache: false,
			success: success,
			error: error
		});
}