'use strict';
var PawPawDispatcher = require('../dispatcher/PawPawDispatcher');
var PawPawConstants = require('../constants/PawPawConstants');
var GroupClient = require('../services/GroupClient');

var GroupActions = {
	fetchAll: function(){
		PawPawDispatcher.dispatch({
			actionType: PawPawConstants.GROUPS_FETCH
		});
		GroupClient.get()
			.then(function(data){
				PawPawDispatcher.dispatch({
					actionType: PawPawConstants.GROUPS_FETCH_SUCCESS,
					data: data
				});
			},
			function(error){
				PawPawDispatcher.dispatch({
					actionType: PawPawConstants.GROUPS_FETCH_FAIL,
					error: error
				});
			});
	},
	post: function(group){
		PawPawDispatcher.dispatch({
			actionType: PawPawConstants.GROUP_POST
		});
		GroupClient.post(group)
			.then(function(data){
				PawPawDispatcher.dispatch({
					actionType: PawPawConstants.GROUP_POST_SUCCESS,
					data: data
				});
			}, function(error){
				PawPawDispatcher.dispatch({
					actionType: PawPawConstants.GROUP_POST_FAIL,
					error: error
				});
			});
	}
};

module.exports = GroupActions;