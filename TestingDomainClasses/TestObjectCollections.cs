using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoiceInventory.ObjectCollections;
using DalMySQL;
using Domain.Models.Test;

namespace TestingDomainClasses
{
    [TestClass]
    public class TestObjectCollections
    {
        [TestMethod]
        public void TestInsertItemIntoPeople()
        {
            using (var db = new InvoiceModel())
            {
                var col = new ContextAwareObservableCollection<TestPeople>(db.People, db);
                Assert.AreEqual(col.Count, 2);

                col.Add(new TestPeople { ForeName = "Michael", LastName = "Stoever" });
                Assert.AreEqual(col.Count, 3);

                var colNeu = new ContextAwareObservableCollection<TestPeople>(db.People, db);
                Assert.AreEqual(colNeu.Count, 3);




            }
        }
    }
}
