using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504081230)]
    public class _201504081230_AddCommentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Comment")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Body").AsString(int.MaxValue).Nullable()
                .WithColumn("PostId").AsInt32().NotNullable().ForeignKey("Post", "Id");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
