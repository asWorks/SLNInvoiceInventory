using Caliburn.Micro;
using DalMySQL;
using Domain.Models.Test;
using InvoiceInventory.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace InvoiceInventory.ViewModels
{
    [Export(typeof(ITestPeopleViewModel))]
    public class TestPeopleViewModel : Screen, ITestPeopleViewModel
    {
        private InvoiceModel db = null;


        public TestPeopleViewModel()
        {

            db = new InvoiceModel();
            //var p = new TestPeople { ForeName = "Arpad", LastName = "Stöver" };
            //var p1 = new TestPeople { ForeName = "Ronald", LastName = "Hildebrandt" };

            //db.People.Add(p);
            //db.People.Add(p1);
            //db.SaveChanges();

            
            People = new ObservableCollection<TestPeople>(db.People);




            People.CollectionChanged += People_CollectionChanged;








        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var x = e.NewItems;

        }

        private ObservableCollection<TestPeople> _People;
        public ObservableCollection<TestPeople> People
        {
            get { return _People; }
            set
            {
                if (value != _People)
                {
                    _People = value;
                    NotifyOfPropertyChange(() => People);
                    //  isDirty = true;
                }
            }
        }

        public void Save()
        {
            var p = new TestPeople { ForeName = "Stefan", LastName = "Stöver" };
            People.Add(p);
            var n =  db.SaveChanges();
        }
    }
}
