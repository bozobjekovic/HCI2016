using main.Change_Dialogs;
using main.Dialogs;
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

namespace main.Tables
{
    /// <summary>
    /// Interaction logic for TagTable.xaml
    /// </summary>
    public partial class TagTable : Window
    {
        public Style rowStyle = new Style(typeof(DataGridRow));

        public TagTable()
        {
            InitializeComponent();

            this.DataContext = this;

            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(double_Click_Row)));
            tagsTable.RowStyle = rowStyle;
        }

        private void add_new_from_table_Click(object sender, RoutedEventArgs e)
        {
            AddTagDialog atd = new AddTagDialog();
            atd.ShowDialog();
        }

        private void double_Click_Row(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            int index = tagsTable.SelectedIndex;
            ChangeTagDialog cmd = new ChangeTagDialog(index);
            cmd.ShowDialog();
        }

        private void view_item_Click(object sender, RoutedEventArgs e)
        {
            int index = tagsTable.SelectedIndex;

            if (index != -1)
            {
                ChangeTagDialog cmd = new ChangeTagDialog(index);
                cmd.ShowDialog();
            }
        }

        private void delete_item_Click(object sender, RoutedEventArgs e)
        {
            int index = tagsTable.SelectedIndex;

            if (index != -1)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete Tag?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MainWindow.Tags.RemoveAt(index);
                }
            }
        }

        private void help_pressed_tags(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string fileName = "TagHelp.chm";
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"HCIDoc\Tag\", fileName);
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
