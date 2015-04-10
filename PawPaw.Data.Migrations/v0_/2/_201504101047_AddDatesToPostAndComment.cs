using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._2
{
    [Migration(201504101047)]
    public class _201504101047_AddDatesToPostAndComment : Migration
    {
        public override void Up()
        {
            Execute.Sql("DELETE FROM Comment;" +
                        "DELETE FROM GroupToPost;" +
                        "DELETE FROM POST;");

            Alter.Table("Post")
                .AddColumn("Created").AsDateTime().NotNullable()
                .AddColumn("Modified").AsDateTime().Nullable();

            Alter.Table("Comment")
                .AddColumn("Created").AsDateTime().NotNullable()
                .AddColumn("Modified").AsDateTime().Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
