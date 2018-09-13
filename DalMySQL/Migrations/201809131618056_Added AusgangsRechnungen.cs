namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAusgangsRechnungen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseRechnung", "Umsatzsteuer", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BaseRechnung", "Netto", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BaseRechnung", "Zuzahlung", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseRechnung", "Zuzahlung");
            DropColumn("dbo.BaseRechnung", "Netto");
            DropColumn("dbo.BaseRechnung", "Umsatzsteuer");
        }
    }
}
