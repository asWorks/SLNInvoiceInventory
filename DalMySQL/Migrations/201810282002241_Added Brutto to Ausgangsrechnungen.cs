namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBruttotoAusgangsrechnungen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseRechnung", "Brutto", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseRechnung", "Brutto");
        }
    }
}
