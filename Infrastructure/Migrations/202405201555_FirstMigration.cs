using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Migrations
{
    [Migration(202405201555)]
    public class FirstMigration : Migration
    {

        public override void Up()
        {
            Create.Table("Jobs")
                .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("title").AsString(255).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Jobs");
        }

    }
}
