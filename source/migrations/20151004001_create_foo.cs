using FluentMigrator;

namespace code.migrations
{
  [Migration(20150118001)]
  public class CreateFoo : Migration
  {

    string table_name{
      get{ return "Foo"; }
    }

    public override void Up()
    {
      Create.Table(table_name)
        .WithColumn("id").AsGuid().PrimaryKey()
        .WithColumn("name").AsString(255).NotNullable();
    }

    public override void Down()
    {
      Delete.Table(table_name);
    }
  }
}
