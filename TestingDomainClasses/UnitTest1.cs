using System;
using DalMySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models.Rechnungen;
using System.Data.Entity;
using System.Linq;

namespace TestingDomainClasses
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            using (var db = new InvoiceModel())
            {


                var er = new EingangsRechnung(DateTime.Now, "qwertz111");
                db.EingangsRechnungen.Add(er);
                db.SaveChanges();

                //var query = db.EingangsRechnungen.Where(id => id.RechnungsId == 1).SingleOrDefault();
                var br = new BuchungsReference(er, DateTime.Now, "Alles gut");
                var res = er.Ausbuchen(br);
                db.BuchungsReferenzen.Add(br);
                db.SaveChanges();
                Console.WriteLine(er.RechnungsNummer);

            }

        }
    }
}
