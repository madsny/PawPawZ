using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504081438)]
    public class _201504081438_AddGroupToPostTable : Migration
    {
        public override void Up()
        {
            Create.Table("GroupToPost")
                .WithColumn("GroupId").AsInt32().NotNullable().ForeignKey("Group", "Id")
                .WithColumn("PostId").AsInt32().NotNullable().ForeignKey("Post", "Id");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
