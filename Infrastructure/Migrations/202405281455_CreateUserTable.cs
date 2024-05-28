using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Migrations
{
    [Migration(202405281455)]
    public class CreateUserTable : Migration
    {

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("email").AsString(255).NotNullable().Unique()
                .WithColumn("name").AsString(255).NotNullable()
                .WithColumn("password").AsString(255).NotNullable()
                .WithColumn("created_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("updated_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);
        }

        public override void Down()
        {
            Delete.Table("Users");
        }

    }
}
