﻿'use strict';
var React = require('react');
var Router = require('react-router');
var GroupsView = require('./components/GroupsView.jsx');
var AddGroupView = require('./components/AddGroupView.jsx');

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
        <Router.Route name='groups' path='groups' handler={GroupsView} />
        <Router.Route name='addGroup' path='groups/add' handler={AddGroupView} />
        <Router.Redirect from='/' to='/groups' />
    </Router.Route>
);

Router.run(Routes, function(Handler){
    React.render(<Handler />, document.body);
});