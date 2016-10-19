using main.Change_Dialogs;
using main.Dialogs;
using model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManifestationTable.xaml
    /// </summary>
    public partial class ManifestationTable : Window
    {
        public Style rowStyle = new Style(typeof(DataGridRow));

        public ManifestationTable()
        {
            InitializeComponent();

            this.DataContext = this;

            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(double_Click_Row)));
            manifestationsTable.RowStyle = rowStyle;
        }

        private void add_new_from_table_Click(object sender, RoutedEventArgs e)
        {
            AddManifestDialog amd = new AddManifestDialog();
            amd.ShowDialog();
        }

        private void double_Click_Row(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            int index = manifestationsTable.SelectedIndex;
            ChangeManifestDialog cmd = new ChangeManifestDialog(index);
            cmd.ShowDialog();
        }

        private void view_item_Click(object sender, RoutedEventArgs e)
        {
            int index = manifestationsTable.SelectedIndex;

            if (index != -1)
            {
                ChangeManifestDialog cmd = new ChangeManifestDialog(index);
                cmd.ShowDialog();
            }
        }

        private void delete_item_Click(object sender, RoutedEventArgs e)
        {
            int index = manifestationsTable.SelectedIndex;

            if (index != -1)
            {
                Manifestation manif = MainWindow.Manifestations.ElementAt(index);

                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete " + manif.Name + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MainWindow.Manifestations.RemoveAt(index);
                    if (manif.X_position == -1 && manif.Y_position == -1)
                    {
                        for (int i = 0; i < MainWindow.ManifestationsInTree.Count; i++)
                        {
                            if (MainWindow.ManifestationsInTree.ElementAt(i).IdManifest.Equals(manif.IdManifest))
                            {
                                MainWindow.ManifestationsInTree.RemoveAt(i); break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < MainWindow.ManifestationsOnBoard.Count; i++)
                        {
                            if (MainWindow.ManifestationsOnBoard.ElementAt(i).IdManifest.Equals(manif.IdManifest))
                            {
                                MainWindow.ManifestationsOnBoard.RemoveAt(i); break;
                            }
                        }
                        Button delbtn = (Button)LogicalTreeHelper.FindLogicalNode(MainWindow.canvas, manif.IdManifest);
                        MainWindow.canvas.Children.Remove(delbtn);
                    }
                }
            }
        }

        private void help_pressed_manifs(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string fileName = "ManifHelp.chm";
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"HCIDoc\Manif\", fileName);
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
