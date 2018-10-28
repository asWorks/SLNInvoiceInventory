namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateTimeinInvoicestonotnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BaseRechnung", "Datum", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaseRechnung", "Datum", c => c.DateTime(precision: 0));
        }
    }
}
