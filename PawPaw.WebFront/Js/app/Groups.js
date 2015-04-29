var Groups = React.createClass({
    getInitialState: function(){
        return {
            data:[{Name:"hei", Id: 1}, {Name:"lei", Id: 2}]
        };
    },
    render: function() {
        var groups = this.state.data.map(function(group){
            return (<li>{group.Name}</li>);
        });
        
        return (
            <ul>
                {groups}
            </ul>
        );
    }
});


React.render(
    <Groups></Groups>,
    document.getElementById("content")
    );