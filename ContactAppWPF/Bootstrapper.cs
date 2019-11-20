using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using ContactAppWPF.Helpers;
using ContactAppWPF.Models;
using ContactAppWPF.ViewModels;
using ModelLibrary;
using ModelLibrary.DataAccess;
using ModelLibrary.Models;

namespace ContactAppWPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
           PasswordBoxHelper.BoundPasswordProperty ,
           "Password" ,
           "PasswordChanged");

        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager , WindowManager>()
                .Singleton<IEventAggregator , EventAggregator>()
                .Singleton<UserCredentials>()
                .Singleton<SearchAggregator>()
                .Singleton<StateListHelper>()
                .Singleton<ReportModel>();

            _container.PerRequest<IAuthentication , Authentication>()
                .PerRequest<OrgTypeDataAccess>()
                .PerRequest<IndividualDataAccess>()
                .PerRequest<OrganizationDataAccess>()
                .PerRequest<UserDataAccess>()
                .PerRequest<ActionTypesDataAccess>()
                .PerRequest<DenominationTypesDataAccess>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType , viewModelType.ToString() , viewModelType));
        }

        protected override void OnStartup(object sender , StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service , string key)
        {
            return _container.GetInstance(service , key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
