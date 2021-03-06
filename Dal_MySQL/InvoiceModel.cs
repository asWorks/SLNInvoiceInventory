namespace Dal_MySQL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class InvoiceModel : DbContext
    {
        // Your context has been configured to use a 'InvoiceModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Dal_MySQL.InvoiceModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InvoiceModel' 
        // connection string in the application configuration file.
        public InvoiceModel()
            : base("name=InvoiceModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}