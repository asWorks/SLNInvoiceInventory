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

                var ar = new AusgangsRechnung(DateTime.Now, "Ar_qwertz111");
                ar.Netto = 667.17M;
                ar.Zuzahlung = 99.12M;

                db.AusgangsRechnungen.Add(ar);



                var er = new EingangsRechnung(DateTime.Now, "New_qwertz111");
                db.EingangsRechnungen.Add(er);
               var r= db.SaveChanges();

                //var query = db.EingangsRechnungen.Where(id => id.RechnungsId == 1).SingleOrDefault();
                var br = new BuchungsReference(er, DateTime.Now, "Alles gut");
                var res = er.Ausbuchen(br);
                var br1 = new BuchungsReference(ar, DateTime.Now, "Hat geklappt");
                var arRes = ar.Ausbuchen(br1);

                db.BuchungsReferenzen.Add(br);
                db.BuchungsReferenzen.Add(br1);
                db.SaveChanges();
                Console.WriteLine(er.RechnungsNummer);

            }

        }
    }
}
