using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504101707)]
    public class _201504101707_RenameCreatedByToCreatedByUserId : Migration
    {
        public override void Up()
        {
            Rename.Column("CreatedBy").OnTable("Post").To("CreatedByUserId");
            Rename.Column("CreatedBy").OnTable("Comment").To("CreatedByUserId");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
