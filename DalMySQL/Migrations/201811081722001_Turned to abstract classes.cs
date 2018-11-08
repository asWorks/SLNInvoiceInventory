namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Turnedtoabstractclasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseRechnung", "IstStorniert1", c => c.Boolean());
            AddColumn("dbo.BaseRechnung", "IstAusgebucht1", c => c.Boolean());
            AlterColumn("dbo.BaseRechnung", "IstStorniert", c => c.Boolean());
            AlterColumn("dbo.BaseRechnung", "IstAusgebucht", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaseRechnung", "IstAusgebucht", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BaseRechnung", "IstStorniert", c => c.Boolean(nullable: false));
            DropColumn("dbo.BaseRechnung", "IstAusgebucht1");
            DropColumn("dbo.BaseRechnung", "IstStorniert1");
        }
    }
}
