'use strict';
var React = require('react');
var GetService = require('../services/getService');
var GroupList = require('./groupList');

module.exports = React.createClass({
	loadGroupsFromServer: function() {
		GetService('/api/groups',
			function(data){
				this.setState({data: data});
			}.bind(this),
			function(xhr, status, err){
				console.error(status, err.toString());
			}.bind(this));
	},
	getInitialState: function(){
		return {data: []};
	},
	componentDidMount: function(){
		this.loadGroupsFromServer();
		setInterval(this.loadGroupsFromServer, 60000);
	},
	render: function(){
		return(
			<div className='groupBox'>
				<h2>Grupper</h2>
				<GroupList data={this.state.data} />
			</div>
		);
	}
});