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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    
    public partial class MainWindow : Window
    {
        TrainingEntities dbTrainingEntities;
        public MainWindow()
        {
            InitializeComponent();
            dbTrainingEntities = new TrainingEntities();
            // dtgGrid.ItemsSource= dbTrainingEntities.StudentsTables.ToList();
            //dtgGrid.ItemsSource = dbTrainingEntities.Students.Where(c => c.Marks > 80).ToList();
            // dtgGrid.ItemsSource = dbTrainingEntities.StudentsTables.Select(c => new { StudentName=c.Name, c.Marks }).ToList();
            dtgGrid.ItemsSource = dbTrainingEntities.StudentsTables.Select(c => new 
            {
                StudentName = c.Name,
                StudentMarks = c.Marks
            }).ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StudentsTable student=new StudentsTable();
            student.Id = Convert.ToInt32(txtId.Text);
            student.Name = txtName.Text;
            student.Marks = txtMarks.Text;
            dbTrainingEntities.StudentsTables.Add(student);
            dbTrainingEntities.SaveChanges();
            dtgGrid.ItemsSource = dbTrainingEntities.StudentsTables.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var row = dbTrainingEntities.StudentsTables.Where(c => c.Id == id).FirstOrDefault();
            dbTrainingEntities.StudentsTables.Remove(row);
            dbTrainingEntities.SaveChanges();
            dtgGrid.ItemsSource = dbTrainingEntities.StudentsTables.ToList();
        }

        private void btnUPdate_Click(object sender, RoutedEventArgs e)
        {
            int Id =Convert.ToInt32(txtId.Text);
            var row = dbTrainingEntities.StudentsTables.Where(c => c.Id == Id).FirstOrDefault();
            row.Marks = txtMarks.Text;
            row.Name = txtName.Text;
            dbTrainingEntities.SaveChanges();
            dtgGrid.ItemsSource=dbTrainingEntities.StudentsTables.ToList();
        }
    }
}
