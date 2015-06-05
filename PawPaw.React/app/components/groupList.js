'use strict';
var React = require('react');
var Group = require('./group');

module.exports = React.createClass({
	render: function(){
		var groupNodes = this.props.data.map(function(group){
			return(
				<li>
					<Group name={group.Name} />
				</li>
			);
		});
		return(
			<ul className='groupList'>
				{groupNodes}
			</ul>
		);
	}
});