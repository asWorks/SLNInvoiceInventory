using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace InvoiceInventory.ObjectCollections
{
    public class ContextAwareObservableCollection<TEntity> : ObservableCollection<TEntity> where TEntity : class
    {
        private DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public ContextAwareObservableCollection(IEnumerable<TEntity> dbSet, DbContext context) : base(dbSet)
        {
            try
            {
                _context = context;
                _dbSet = context.Set<TEntity>();
            }
            catch (Exception ex)
            {

                //LoggingTool.LogExeption(ex, "AggregateCollection", "Constructor");
                //System.Windows.MessageBox.Show("Beim Initialisieren von vwBrunvollAuftragsbestand ist ein Fehler aufgetreten.");
            }

        }

        protected override void InsertItem(int index, TEntity item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();

                base.InsertItem(index, item);
            }
            catch (Exception ex)
            {
                Services.MessageToUIService.Message(new Services.Implementations.MessageBoxMessage(ex.Message, "Fehler in ObjectCollection bei InsertItem"));

            }

        }

        protected override void RemoveItem(int index)
        {
            try
            {
                base.RemoveItem(index);
                var obj = (TEntity)this[index];
                _dbSet.Remove(obj);

                base.RemoveItem(index);
            }
            catch (Exception ex)
            {

                Services.MessageToUIService.Message(new Services.Implementations.MessageBoxMessage(ex.Message, "Fehler in ObjectCollection bei RemoveItem"));


            }

        }
    }
}
