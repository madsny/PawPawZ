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
	_groups.hasErrors = true;
	_groups.errors = _groups.errors || [];
	_groups.errors.push(error);
}

var GroupsStore = _.extend({}, EventEmitter.prototype, {
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

GroupsStore.dispatchToken = PawPawDispatcher.register(function(action){
	switch(action.actionType){
		case PawPawConstants.GROUPS_FETCH:
			GroupsStore.emitChange();
			break;
		case PawPawConstants.GROUPS_FETCH_SUCCESS:
			loadGroups(action.data);
			GroupsStore.emitChange();
			break;
		case PawPawConstants.GROUPS_FETCH_FAIL:
			fetchFailed(action.error);
			GroupsStore.emitChange();
			break;
		default:
	}
	return true;
});

module.exports = GroupsStore;