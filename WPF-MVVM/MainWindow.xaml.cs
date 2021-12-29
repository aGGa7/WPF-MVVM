using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EFLib;
using EFLib.Models;
using EFLib.CRUD;

namespace WPF_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MainCRUD<Project> CRUD = new MainCRUD<Project>(connectionString);
            DataContext = new ApplicationViewModel(CRUD);
            // MainRepository Repo = new MainRepository(connectionString);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
