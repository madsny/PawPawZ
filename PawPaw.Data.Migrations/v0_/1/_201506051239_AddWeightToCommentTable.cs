using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201506051239)]
    public class _201506051239_AddWeightToCommentTable : Migration
    {
        public override void Up()
        {
            Create.Table("WeightToComment")
                .WithColumn("WeightId").AsInt32().NotNullable().ForeignKey("Weight", "Id")
                .WithColumn("CommentId").AsInt32().NotNullable().ForeignKey("Comment", "Id");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
