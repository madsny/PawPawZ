'use strict';
var PawPawDispatcher = require('../dispatcher/PawPawDispatcher');
var PawPawConstants = require('../constants/PawPawConstants');
var EventEmitter = require('events').EventEmitter;
var _ = require('lodash');
var CHANGE_EVENT = 'change-add-group';

var _result = '';

function setResult(data){
	_result = 'Gruppe #' + data + ' opprettet';
}

function postFailed(error){
	_result = 'Det skjedde en feil ved opprettelsen av ny gruppe. Se konsollen for mer info.';
	console.error(error);
}

var AddGroupStore = _.extend({}, EventEmitter.prototype, {
	getResult: function(){
		return _result;
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

AddGroupStore.dispatchToken = PawPawDispatcher.register(function(action){
	switch(action.actionType){
		case PawPawConstants.GROUP_POST:
			AddGroupStore.emitChange();
			break;
		case PawPawConstants.GROUP_POST_SUCCESS:
			setResult(action.data);
			AddGroupStore.emitChange();
			break;
		case PawPawConstants.GROUP_POST_FAIL:
			postFailed(action.error);
			AddGroupStore.emitChange();
			break;
		default:
	}
	return true;
});

module.exports = AddGroupStore;