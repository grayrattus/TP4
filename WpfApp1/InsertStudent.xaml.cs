using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy InsertStudent.xaml
    /// </summary>
    public partial class InsertStudent : Window
    {
        ProjektEntities _database = new ProjektEntities();

        public InsertStudent()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            Students newStudent = new Students()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                CardNumber = Int32.Parse(cardNumber.Text)
            };

            _database.Students.Add(newStudent);
            _database.SaveChanges();
            MainWindow.datagrid.ItemsSource = _database.Students.ToList();
            this.Hide();
        }
    }
}
