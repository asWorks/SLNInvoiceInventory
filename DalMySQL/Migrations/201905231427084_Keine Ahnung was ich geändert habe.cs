namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeineAhnungwasichgeänderthabe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseRechnung", "DisplayName", c => c.String(unicode: false));
            AddColumn("dbo.BaseRechnung", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.BaseRechnung", "IsInitialized", c => c.Boolean(nullable: false));
            AddColumn("dbo.BaseRechnung", "IsNotifying", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseRechnung", "IsNotifying");
            DropColumn("dbo.BaseRechnung", "IsInitialized");
            DropColumn("dbo.BaseRechnung", "IsActive");
            DropColumn("dbo.BaseRechnung", "DisplayName");
        }
    }
}
