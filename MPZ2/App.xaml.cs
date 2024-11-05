using Microsoft.EntityFrameworkCore.Infrastructure;
using MPZ2.Contexts;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MPZ2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade DepsFacade = new DatabaseFacade(new DepartmentContext());
            DepsFacade.EnsureCreated();

            DatabaseFacade EpmlFacade = new DatabaseFacade(new EmployeeContext());
            EpmlFacade.EnsureCreated();

            DatabaseFacade PosFacade = new DatabaseFacade(new PositionsContext());
            PosFacade.EnsureCreated();

        }


    }

}
