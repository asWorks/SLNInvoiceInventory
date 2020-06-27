namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noIdea : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BaseRechnung", "DisplayName");
            DropColumn("dbo.BaseRechnung", "IsActive");
            DropColumn("dbo.BaseRechnung", "IsInitialized");
            DropColumn("dbo.BaseRechnung", "IsNotifying");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BaseRechnung", "IsNotifying", c => c.Boolean(nullable: false));
            AddColumn("dbo.BaseRechnung", "IsInitialized", c => c.Boolean(nullable: false));
            AddColumn("dbo.BaseRechnung", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.BaseRechnung", "DisplayName", c => c.String(unicode: false));
        }
    }
}
