using FluentMigrator;

namespace PawPaw.Data.Migrations.v0_._1
{
    [Migration(201504241456)]
    public class _201504241456_AddWeightTable : Migration
    {
        public override void Up()
        {
            Create.Table("Weight")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Amount").AsInt32().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Modified").AsDateTime().Nullable()
                .WithColumn("CreatedByUserId").AsInt32().NotNullable().ForeignKey("User", "Id");
        }

        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
