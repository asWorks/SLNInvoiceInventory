namespace InvoiceInventory
{
    using System;
    using System.Collections.Generic;
    using  Contracts.Domain.Interfaces;
    using InvoiceInventory.ViewModels;
    using InvoiceInventory;
    using Caliburn.Micro;
    using InvoiceInventory.Interfaces;
    using System.Data.Entity;

    public class Bootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShellViewModel, ShellViewModel>();
            container.PerRequest<ITestViewModel, TestViewModel>();
            container.PerRequest<IAddAusgangsrechnungViewModel, AddAusgangsrechnungViewModel>();
            container.PerRequest<IAddEingangsrechnungViewModel, AddEingangsrechnungViewModel>();
            container.PerRequest<ITestDatumViewModel, TestDatumViewModel>();



            container.PerRequest<IBaseAddRechnungViewModel, BaseAddRechnungViewModel>();
            container.PerRequest<ITestPeopleViewModel, TestPeopleViewModel> ();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShellViewModel>();
        }
    }
}

