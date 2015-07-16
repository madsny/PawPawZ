'use strict';
var React = require('react');
var _ = require('lodash');

var GroupStore = require('../stores/GroupStore');
var GroupActions = require('../actions/GroupActions');

function getState(){
	return {
		groups: GroupStore.getAllGroups()
	};
}

var GroupView = React.createClass({
	getInitialState: function(){
		return getState();
	},
	_onChange: function(){
		this.setState(getState());
	},
	componentDidMount: function(){
		GroupStore.addChangeListener(this._onChange);
		GroupActions.fetch();
	},
	componentWillUnmount: function(){
		GroupStore.removeChangeListener(this._onChange);
	},
	render: function(){
		return(
			<div className='groups'>
				<h1>Grupper</h1>
				<ul className='groupList'>{this.groups()}</ul>
			</div>
		);
	},
	groups: function(){
		return _.map(this.state.groups, function (group, index){
			return (
				<li className='groupLineItem' key={index}><a href='#'>{group.Name}</a></li>
			);
		})
	}
});

module.exports = GroupView;