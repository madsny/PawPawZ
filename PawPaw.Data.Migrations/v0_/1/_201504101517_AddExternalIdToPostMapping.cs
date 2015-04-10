using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504101517)]
    public class _201504101517_AddExternalIdToPostMapping : Migration
    {
        public override void Up()
        {
            Create.Table("ExternalIdToPost")
                .WithColumn("ExternalId").AsString(128).NotNullable().PrimaryKey()
                .WithColumn("PostId").AsInt32().NotNullable().ForeignKey("Post", "Id");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
