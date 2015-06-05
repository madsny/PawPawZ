using System;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201506050948)]
    public class _201506050948_AddDeletedColumnToAllTables : Migration
    {
        public override void Up()
        {
            var tables = new[] {"Post", "Comment", "Group", "User", "Weight"};

            Array.ForEach(tables, tableName =>
            {
                Alter.Table(tableName)
                .AddColumn("Deleted")
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);
            });
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
