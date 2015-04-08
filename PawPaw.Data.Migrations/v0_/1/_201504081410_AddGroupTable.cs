using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504081410)]
    public class _201504081410_AddGroupTable : Migration
    {
        public override void Up()
        {
            Create.Table("Group")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(512).NotNullable()
                .WithColumn("Description").AsString(2048).Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
