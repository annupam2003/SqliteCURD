using SqliteAdoDotNet.BLL;
using SqliteAdoDotNet.Models;
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

namespace SqliteAdoDotNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleBll bll = new PeopleBll();
        public List<People> peoples { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            peoples = bll.getData();
            this.DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                if(bll.Insert(txtName.Text)>0)
                {
                    MessageBox.Show("Add");
                }
            }
        }
        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            var res = ((Button)sender).Tag;
            if (bll.Delete((Int64)res) > 0)
            {
                MessageBox.Show("Delete");
            }
        }
        
    }
}
