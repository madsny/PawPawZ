'use strict';
var React = require('react');
var GroupBox = require('./components/groupBox');

var App = React.createClass({
    render: function() {
        return (
            <div className='app'>
                <h1>Hello PawPaw</h1>
                <GroupBox />
            </div>
        );
    }
});

React.render(
    <App />,
    document.getElementById('content')
);