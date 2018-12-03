using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProjektEntities _database = new ProjektEntities();
        public static DataGrid datagrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myGrid.ItemsSource = _database.Students.ToList();
            datagrid = myGrid;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertStudent IStudent = new InsertStudent();
            IStudent.ShowDialog();

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int id = (myGrid.SelectedItem as Students).id;
            UpdateStudent update = new UpdateStudent(id);
            update.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myGrid.SelectedItem as Students).id;
            Students deleteStudent = _database.Students.Where(s => s.id == Id).Single();
            _database.Students.Remove(deleteStudent);
            _database.SaveChanges();
            myGrid.ItemsSource = _database.Students.ToList();
        }
    }
}
