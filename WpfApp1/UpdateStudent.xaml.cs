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
    /// Logika interakcji dla klasy UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window
    {
        ProjektEntities _database = new ProjektEntities();
        Students StudentToUpdate;
        public UpdateStudent(int studentId)
        {
            InitializeComponent();
            StudentToUpdate = (from s in _database.Students
                                    where s.id == studentId
                                    select s).Single();

            firstName.Text = StudentToUpdate.FirstName;
            lastName.Text = StudentToUpdate.LastName;
            cardNumber.Text = StudentToUpdate.CardNumber.ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Students updateStudent = (from s in _database.Students
                                    where s.id == StudentToUpdate.id
                                    select s).Single();
            updateStudent.FirstName = firstName.Text;
            updateStudent.LastName = lastName.Text;
            updateStudent.CardNumber = Int32.Parse(cardNumber.Text);
            _database.SaveChanges();
            MainWindow.datagrid.ItemsSource = _database.Students.ToList();
            this.Hide();
        }
    }
}
