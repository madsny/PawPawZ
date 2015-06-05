using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504101440)]
    public class _201504101440_AddUserIdToCommentAndPost : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                DELETE FROM Comment;
                DELETE FROM GroupToPost;
                DELETE FROM Post;
                ");

            Alter.Table("Post")
                .AddColumn("CreatedBy").AsInt32().NotNullable().ForeignKey("User", "Id");
            Alter.Table("Comment")
                .AddColumn("CreatedBy").AsInt32().NotNullable().ForeignKey("User", "Id");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
