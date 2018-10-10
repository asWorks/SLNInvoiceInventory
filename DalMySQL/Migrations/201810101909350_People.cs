namespace DalMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class People : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestPeople",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForeName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestPeople");
        }
    }
}
