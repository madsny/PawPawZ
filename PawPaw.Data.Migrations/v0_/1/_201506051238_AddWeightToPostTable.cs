using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201506051238)]
    public class _201506051238_AddWeightToPostTable : Migration
    {
        public override void Up()
        {
            Create.Table("WeightToPost")
                .WithColumn("WeightId").AsInt32().NotNullable().ForeignKey("Weight", "Id")
                .WithColumn("PostId").AsInt32().NotNullable().ForeignKey("Post", "Id");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
