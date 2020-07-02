using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceInventory.Interfaces
{
    public interface IDBContext
    {
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
