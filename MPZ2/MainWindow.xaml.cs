using MPZ2.Contexts;
using MPZ2.Models;
using MPZ2.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MPZ2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeeContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new EmployeeContext();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            EmployeesDataGrid.ItemsSource = _context.Employees.ToList();
        }

    
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EmployeeDialog();
            using (var poscontext = new PositionsContext()) {
                if (dialog.ShowDialog() == true)
                {
                    var employee = new EmployeeModel
                    {
                        
                        Name = dialog.NameTextBox.Text,
                        Position = poscontext.Positions.First(x => x.PositionId == dialog.PositionComboBox.SelectedIndex+1).PositionName,
                        HireDate = dialog.HireDatePicker.SelectedDate.Value,
                        Salary = Convert.ToInt32(dialog.SalaryTextBox.Text)
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    LoadEmployees();
                } 
            }
        }


        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            using (var poscontext = new PositionsContext())
            {
                if (EmployeesDataGrid.SelectedItem is EmployeeModel selectedEmployee)
                {
                    var dialog = new EmployeeDialog();
                    dialog.NameTextBox.Text = selectedEmployee.Name;

                    dialog.HireDatePicker.SelectedDate = selectedEmployee.HireDate;
                    dialog.SalaryTextBox.Text = selectedEmployee.Salary.ToString();

                    if (dialog.ShowDialog() == true)
                    {
                        selectedEmployee.Name = dialog.NameTextBox.Text;
                        selectedEmployee.Position = poscontext.Positions.First(x => x.PositionId == dialog.PositionComboBox.SelectedIndex+1).PositionName;
                        selectedEmployee.HireDate = dialog.HireDatePicker.SelectedDate.Value;
                        selectedEmployee.Salary = Convert.ToInt32(dialog.SalaryTextBox.Text);

                        _context.SaveChanges();
                        LoadEmployees();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an employee to edit.");
                }
            }
        }


        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is EmployeeModel selectedEmployee)
            {
                if (MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.Employees.Remove(selectedEmployee);
                    _context.SaveChanges();
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }
    }
}