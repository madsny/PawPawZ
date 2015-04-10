using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504101330)]
    public class _201504101330_AddUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("Username").AsString(128).NotNullable().Unique()
                .WithColumn("FullName").AsString(256).Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
