namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1309 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuchungsReference",
                c => new
                    {
                        BuchungsReferenceId = c.Int(nullable: false, identity: true),
                        Bemerkung = c.String(unicode: false),
                        Datum = c.DateTime(precision: 0),
                        RechnungsRefId = c.Int(nullable: false),
                        User = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuchungsReferenceId)
                .ForeignKey("dbo.BaseRechnung", t => t.RechnungsRefId, cascadeDelete: true)
                .Index(t => t.RechnungsRefId);
            
            CreateTable(
                "dbo.BaseRechnung",
                c => new
                    {
                        RechnungsId = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(precision: 0),
                        RechnungsNummer = c.String(unicode: false),
                        istStorniert = c.Boolean(nullable: false),
                        IstAusgebucht = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RechnungsId);
            
            CreateTable(
                "dbo.StornoReference",
                c => new
                    {
                        StornoReferenceId = c.Int(nullable: false, identity: true),
                        StornoGrund = c.String(unicode: false),
                        Datum = c.DateTime(nullable: false, precision: 0),
                        RechnungsId = c.Int(nullable: false),
                        User = c.Int(nullable: false),
                        result = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StornoReferenceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuchungsReference", "RechnungsRefId", "dbo.BaseRechnung");
            DropIndex("dbo.BuchungsReference", new[] { "RechnungsRefId" });
            DropTable("dbo.StornoReference");
            DropTable("dbo.BaseRechnung");
            DropTable("dbo.BuchungsReference");
        }
    }
}
