'use strict';
var PawPawDispatcher = require('../dispatcher/PawPawDispatcher');
var PawPawConstants = require('../constants/PawPawConstants');
var EventEmitter = require('events').EventEmitter;
var _ = require('lodash');
var CHANGE_EVENT = 'change-group';

var _groups = [];

function loadGroups(data){
	_groups = data;
}

function fetchFailed(error){
	_groups._hasErrors = true;
	_groups.errors = _groups.errors || [];
	_groups.errors.push(error);
}

var GroupStore = _.extend({}, EventEmitter.prototype, {
	getAllGroups: function(){
		return _groups;
	},
	emitChange: function(){
		this.emit(CHANGE_EVENT);
	},
	addChangeListener: function(callback){
		this.on(CHANGE_EVENT, callback);
	},
	removeChangeListener: function(callback){
		this.removeListener(CHANGE_EVENT, callback);
	}
});

GroupStore.dispatchToken = PawPawDispatcher.register(function(action){
	switch(action.actionType){
		case PawPawConstants.GROUP_FETCH:
			GroupStore.emitChange();
			break;
		case PawPawConstants.GROUP_FETCH_SUCCESS:
			loadGroups(action.data);
			GroupStore.emitChange();
			break;
		case PawPawConstants.GROUP_FETCH_FAIL:
			fetchFailed(action.error);
			GroupStore.emitChange();
			break;
		default:
	}
	return true;
});

module.exports = GroupStore;