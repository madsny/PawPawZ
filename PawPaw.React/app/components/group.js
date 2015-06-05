'use strict';
var React = require('react');

module.exports = React.createClass({
	render: function(){
		return(
			<a className='group' href='#'>{this.props.name}</a>
		);
	}
});