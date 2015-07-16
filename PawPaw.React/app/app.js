'use strict';
var React = require('react');
var Router = require('react-router');
var GroupView = require('./components/GroupView');

var App = React.createClass({
    render: function() {
        return (
            <div className='app'>
                <Router.RouteHandler />
            </div>
        );
    }
});

var Routes = (
    <Router.Route handler={App}>
        <Router.DefaultRoute handler={GroupView} />
    </Router.Route>
);

Router.run(Routes, function(Handler){
    React.render(<Handler />, document.body);
});