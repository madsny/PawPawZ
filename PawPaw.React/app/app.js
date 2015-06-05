'use strict';
var React = require('react');
var GroupList = require('./components/groupList');

var App = React.createClass({
    render: function() {
        return (
            <div className='app'>
                <h1>Hello PawPaw</h1>
                <GroupList />
            </div>
        );
    }
});

React.render(
    <App />,
    document.getElementById('content')
);