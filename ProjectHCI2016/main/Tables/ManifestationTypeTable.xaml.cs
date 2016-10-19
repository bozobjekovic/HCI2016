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
    /// Interaction logic for ManifestationTypeTable.xaml
    /// </summary>
    public partial class ManifestationTypeTable : Window
    {
        public Style rowStyle = new Style(typeof(DataGridRow));

        public ManifestationTypeTable()
        {
            InitializeComponent();

            this.DataContext = this;

            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(double_Click_Row)));
            manifestationTypesTable.RowStyle = rowStyle;
        }

        private void add_new_from_table_Click(object sender, RoutedEventArgs e)
        {
            AddManifestTypeDialog amtd = new AddManifestTypeDialog();
            amtd.ShowDialog();
        }

        private void double_Click_Row(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            int index = manifestationTypesTable.SelectedIndex;
            ChangeManifestTypeDialog cmd = new ChangeManifestTypeDialog(index);
            cmd.ShowDialog();
        }

        private void view_item_Click(object sender, RoutedEventArgs e)
        {
            int index = manifestationTypesTable.SelectedIndex;

            if (index != -1)
            {
                ChangeManifestTypeDialog cmd = new ChangeManifestTypeDialog(index);
                cmd.ShowDialog();
            }
        }

        private void delete_item_Click(object sender, RoutedEventArgs e)
        {
            int index = manifestationTypesTable.SelectedIndex;
            int br = 0;

            StringBuilder sb = new StringBuilder();
            List<string> ids = new List<string>();

            if (index != -1)
            {
                for (int i = 0; i < MainWindow.Manifestations.Count; i++)
                {
                    if (MainWindow.Manifestations.ElementAt(i).Type.IdManifestType.Equals(MainWindow.ManifestTypes.ElementAt(index).IdManifestType))
                    {
                        br++;
                        sb.Append("  - " + MainWindow.Manifestations.ElementAt(i).Name + "\n");
                        ids.Add(MainWindow.Manifestations.ElementAt(i).IdManifest);
                    }
                }
                if (br != 0)
                {
                    MessageBoxResult result = MessageBox.Show("Manifestations:\n" + sb.ToString() + "uses this Type. Do you want to delete it also?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            MainWindow.delete_manif_by_ID(ids.ElementAt(i));
                        }
                        MainWindow.ManifestTypes.RemoveAt(index);
                        MainWindow.ActiveTypes.RemoveAt(index + 1);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete Type?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        MainWindow.ManifestTypes.RemoveAt(index);
                        MainWindow.ActiveTypes.RemoveAt(index + 1);
                    }
                }
            }
        }

        private void help_pressed_types(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string fileName = "TypeHelp.chm";
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"HCIDoc\Type\", fileName);
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
