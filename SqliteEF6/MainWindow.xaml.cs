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

namespace SqliteEF6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<People> peoples { get; set; } = new List<People>();
        public MainWindow()
        {
            InitializeComponent();
            GetPeople();
            this.DataContext = this; 
        }
        private void GetPeople()
        {
            using (DataContext ctx = new DataContext())
            {
                try
                {
                    foreach (var peo in ctx.people)
                    {
                        //Console.WriteLine(person.Id + " " + person.Name);
                        peoples.Add(peo);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //finally
                //{
                //    ctx.Dispose();
                //}
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            People p = new People() { Name = txtName.Text };
            using (var ctx = new DataContext())
            {
                ctx.people.Add(p);
                ctx.SaveChanges();
                MessageBox.Show("add");
            }
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            var res = ((Button)sender).Tag;
            using (var ctx = new DataContext())
            {
                var person = ctx.people.Find((Int64)res);
                ctx.people.Remove(person);
                ctx.SaveChanges();
                //   ctx.Dispose();
                MessageBox.Show("Delete");
            }
        }
       
        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            var res = ((Button)sender).Tag;
            using (var ctx = new DataContext())
            {
                ctx.people.Find((Int64)res).Name = txtName.Text;
                ctx.SaveChanges();
                //ctx.Dispose();
                MessageBox.Show("Update");
            }
        }
    }
}
