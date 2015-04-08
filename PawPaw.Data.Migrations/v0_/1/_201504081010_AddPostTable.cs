using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504081010)]
    public class _201504081010_AddPostTable : Migration
    {
        public override void Up()
        {
            Create.Table("Post")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Body").AsString(int.MaxValue).Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
