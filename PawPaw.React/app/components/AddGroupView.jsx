'use strict';
var React = require('react');
var Navigation = require('react-router').Navigation;
var Link = require('react-router').Link;
var _ = require('lodash');

var AddGroupStore = require('../stores/AddGroupStore');
var GroupActions = require('../actions/GroupActions');

function getState(){
	return {
		result: AddGroupStore.getResult()
	}
}

var AddGroupView = React.createClass({
	mixins: [Navigation],
	getInitialState: function(){
		return {
			result: ''
		};
	},
	_onChange: function(){
		this.setState(getState());
	},
	componentDidMount: function(){
		AddGroupStore.addChangeListener(this._onChange);
	},
	componentWillUnmount: function(){
		AddGroupStore.removeChangeListener(this._onChange);
	},
	render: function(){
		return (
			<div className='addGroup'>
				<h1>Legg til gruppe</h1>
				<form onSubmit={this.postGroup}>
					<input type='text' name='Name' placeholder='Navn' />
					<br/>
					<textarea name='Description' placeholder='Beskrivelse' />
					<br/>
					<input type='submit' value='Legg til' />
				</form>
				<p>{this.state.result}</p>
				<p><Link to='groups'>Tilbake</Link></p>
			</div>
		);
	},
	postGroup: function(e){
		e.preventDefault();
		GroupActions.post({
			Name: e.target.Name.value,
			Description: e.target.Description.value
		});
	}
});

module.exports = AddGroupView;