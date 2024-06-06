using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202406061727)]
    public class AddColumnsJobTable : Migration
    {

        public override void Up()
        {
            Alter.Table("Jobs")
                .AddColumn("description").AsString().NotNullable()
                .AddColumn("created").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
                .AddColumn("location").AsString().NotNullable()
                .AddColumn("requirements").AsString().NotNullable()
                .AddColumn("benefits").AsString().Nullable()
                .AddColumn("workingModel").AsInt32().NotNullable()
                .AddColumn("level").AsInt32().NotNullable();
        }

        public override void Down()
        {
        }

    }
}
