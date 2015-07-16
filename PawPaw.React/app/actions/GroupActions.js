'use strict';
var PawPawDispatcher = require('../dispatcher/PawPawDispatcher');
var PawPawConstants = require('../constants/PawPawConstants');
var GroupClient = require('../services/GroupClient');

var GroupActions = {
	fetch: function(){
		PawPawDispatcher.dispatch({
			actionType: PawPawConstants.GROUP_FETCH
		});
		GroupClient.get()
			.then(function(data){
				PawPawDispatcher.dispatch({
					actionType: PawPawConstants.GROUP_FETCH_SUCCESS,
					data: data
				});
			},
			function(error){
				PawPawDispatcher.dispatch({
					actionType: PawPawConstants.GROUP_FETCH_FAIL,
					error: error
				});
			});
	}
};

module.exports = GroupActions;