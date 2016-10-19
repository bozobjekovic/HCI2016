using main.Change_Dialogs;
using main.Dialogs;
using main.Tables;
using main.Tutorial;
using model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Manifestation> manifestations = new ObservableCollection<Manifestation>();
        private static ObservableCollection<ManifestationType> manifestTypes = new ObservableCollection<ManifestationType>();
        private static ObservableCollection<Tag> tags = new ObservableCollection<Tag>();

        private static ObservableCollection<Manifestation> manifestationsOnBoard = new ObservableCollection<Manifestation>();
        private static ObservableCollection<Manifestation> manifestationsInTree = new ObservableCollection<Manifestation>();
        private static ObservableCollection<string> activeTypes = new ObservableCollection<string>();

        private Point startPoint;
        private string idManifOnCanvas = "";

        public static Canvas canvas;

        public MainWindow()
        {
            Serialize_deserialize_data.deserialize_data(manifestations, manifestTypes, tags, manifestationsOnBoard, manifestationsInTree);

            this.DataContext = this;
            InitializeComponent();

            setOnBoard();
            fillCMBX();
            canvas = imagePanel;

            treeView.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        private void setOnBoard()
        {
            Button b;
            for (int i = 0; i < manifestationsOnBoard.Count; i++)
            {
                b = return_shape(manifestationsOnBoard.ElementAt(i));
                b.Margin = new Thickness(manifestationsOnBoard.ElementAt(i).X_position, manifestationsOnBoard.ElementAt(i).Y_position, manifestationsOnBoard.ElementAt(i).MarginR, manifestationsOnBoard.ElementAt(i).MarginB);
                imagePanel.Children.Add(b);
            }
        }

        private void fillCMBX()
        {
            activeTypes.Add("All");
            foreach (ManifestationType type in manifestTypes)
            {
                activeTypes.Add(type.Name);
            }
            filterBox.SelectedIndex = 0;
        }

        private void add_manifest_btn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestDialog amd = new AddManifestDialog();
            amd.ShowDialog();
            for (int i = 0; i < manifestations.Count; i++)
            {
                Console.WriteLine(manifestations.ElementAt(i));
            }
        }

        private void add_tag_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTagDialog atd = new AddTagDialog();
            atd.ShowDialog();
            for (int i = 0; i < tags.Count; i++)
            {
                Console.WriteLine(tags.ElementAt(i));
            }
        }

        private void add_manifetsType_btn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestTypeDialog amtd = new AddManifestTypeDialog();
            amtd.ShowDialog();
            for (int i = 0; i < manifestTypes.Count; i++)
            {
                Console.WriteLine(manifestTypes.ElementAt(i).Display());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ManifestationTable mt = new ManifestationTable();
            mt.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ManifestationTypeTable mtt = new ManifestationTypeTable();
            mtt.ShowDialog();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            TagTable tt = new TagTable();
            tt.ShowDialog();
        }

        private void treeVdoubleClick(object sender, MouseButtonEventArgs e)
        {
            object obj = treeView.SelectedItem;
            if (obj is Manifestation)
            {
                int index = manifestations.IndexOf((Manifestation)obj);
                ChangeManifestDialog change_manifestation = new ChangeManifestDialog(index);
                change_manifestation.ShowDialog();
            }
            else if (obj is ManifestationType)
            {
                int index = manifestTypes.IndexOf((ManifestationType)obj);
                ChangeManifestTypeDialog change_manifType = new ChangeManifestTypeDialog(index);
                change_manifType.ShowDialog();
            }
        }

        public static void delete_manif_by_ID(string id)
        {
            for (int i = 0; i < manifestations.Count; i++)
            {
                if (manifestations.ElementAt(i).IdManifest.Equals(id))
                {
                    if (manifestations.ElementAt(i).X_position == -1 && manifestations.ElementAt(i).Y_position == -1)
                    {
                        deleteInTree(id);
                    }
                    else
                    {
                        deleteIbBoard(id);
                    }
                    manifestations.RemoveAt(i);
                }
            }
        }

        private static void deleteInTree(string id)
        {
            for (int i = 0; i < manifestationsInTree.Count; i++)
            {
                if (manifestationsInTree.ElementAt(i).IdManifest.Equals(id))
                {
                    manifestationsInTree.RemoveAt(i);
                    break;
                }
            }
        }

        private static void deleteIbBoard(string id)
        {
            for (int i = 0; i < manifestationsOnBoard.Count; i++)
            {
                if (manifestationsOnBoard.ElementAt(i).IdManifest.Equals(id))
                {
                    manifestationsOnBoard.RemoveAt(i);
                    break;
                }
            }
            Button delbtn = (Button)LogicalTreeHelper.FindLogicalNode(MainWindow.canvas, id);
            MainWindow.canvas.Children.Remove(delbtn);
        }

        private void help_pressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string fileName = "HCIDocumentation.chm";
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"HCIDoc\Main\", fileName);
                System.Diagnostics.Process.Start(path);
            }
        }

        private void window_close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialize_deserialize_data.serialize_data(manifestations, manifestTypes, tags);
        }

        public static ObservableCollection<ManifestationType> ManifestTypes
        {
            get
            {
                return manifestTypes;
            }

            set
            {
                manifestTypes = value;
            }
        }

        public static ObservableCollection<Manifestation> Manifestations
        {
            get
            {
                return manifestations;
            }

            set
            {
                manifestations = value;
            }
        }

        public static ObservableCollection<Tag> Tags
        {
            get
            {
                return tags;
            }

            set
            {
                tags = value;
            }
        }

        public static ObservableCollection<Manifestation> ManifestationsOnBoard
        {
            get
            {
                return manifestationsOnBoard;
            }

            set
            {
                manifestationsOnBoard = value;
            }
        }

        public static ObservableCollection<Manifestation> ManifestationsInTree
        {
            get
            {
                return manifestationsInTree;
            }

            set
            {
                manifestationsInTree = value;
            }
        }

        public Canvas Canvas
        {
            get
            {
                return canvas;
            }

            set
            {
                canvas = value;
            }
        }

        public static ObservableCollection<string> ActiveTypes
        {
            get
            {
                return activeTypes;
            }

            set
            {
                activeTypes = value;
            }
        }

        private void backInTree(object sender, DragEventArgs e)
        {
            for (int i = 0; i < manifestationsOnBoard.Count; i++)
            {
                if (manifestationsOnBoard.ElementAt(i).IdManifest.Equals(idManifOnCanvas))
                {
                    manifestationsOnBoard.ElementAt(i).X_position = -1;
                    manifestationsOnBoard.ElementAt(i).Y_position = -1;
                    manifestationsInTree.Add(manifestationsOnBoard.ElementAt(i));
                    Button delManif = (Button)LogicalTreeHelper.FindLogicalNode(imagePanel, idManifOnCanvas);
                    imagePanel.Children.Remove(delManif);
                    manifestationsOnBoard.RemoveAt(i);
                    break;
                }
            }
        }

        private void treeVPress(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void treeVMoveMouse(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
                return;

            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                TreeView treeView = sender as TreeView;
                TreeViewItem treeViewItem = FindAnchestor<TreeViewItem>((DependencyObject)e.OriginalSource);
                try
                {
                    Manifestation val = (Manifestation)treeView.ItemContainerGenerator.ItemFromContainer(treeViewItem);
                    DataObject dragData = new DataObject("myFormat", val);
                    DragDrop.DoDragDrop(treeViewItem, dragData, DragDropEffects.Move);
                }
                catch (Exception)
                {
                }
            }
        }

        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                    return (T)current;
                current = VisualTreeHelper.GetParent(current);
            } while (current != null);
            return null;
        }

        private void borderDrag(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
                e.Effects = DragDropEffects.None;
        }

        private void borderDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                int winH = (int)imagePanel.Height;
                int winW = (int)imagePanel.Width;

                Manifestation val = e.Data.GetData("myFormat") as Manifestation;
                
                Button b = return_shape(val);

                var relativePosition = e.GetPosition(imagePanel);
                var point = PointToScreen(relativePosition);

                int marginB = winH - ((int)point.Y + (int)SystemParameters.CaptionHeight + (int)SystemParameters.BorderWidth - 190);
                int marginR = winW - ((int)point.X + 60 + (int)SystemParameters.BorderWidth - 235);

                b.Margin = new Thickness(relativePosition.X-35, relativePosition.Y-45, marginR, marginB);

                val.X_position = relativePosition.X - 35;
                val.Y_position = relativePosition.Y - 45;
                //--
                val.MarginB = marginB;
                val.MarginR = marginR;

                manifestationsInTree.Remove(val);
                manifestationsOnBoard.Add(val);

                updateFromB_ToMain(val);

                imagePanel.Children.Add(b);
            }
        }

        private void updateFromB_ToMain(Manifestation manif)
        {
            for (int i = 0; i < manifestations.Count; i++)
            {
                if (manifestations.ElementAt(i).IdManifest.Equals(manif.IdManifest))
                {
                    manifestations.ElementAt(i).X_position = manif.X_position;
                    manifestations.ElementAt(i).Y_position = manif.Y_position;
                    manifestations.ElementAt(i).MarginB = manif.MarginB;
                    manifestations.ElementAt(i).MarginR = manif.MarginR;
                    break;
                }
            }
        }

        private void updateCanvas(object sender, MouseEventArgs e)
        {
            if (!idManifOnCanvas.Equals(""))
            {
                int winH = (int)imagePanel.Height;
                int winW = (int)imagePanel.Width;
                
                var relativePosition = e.GetPosition(imagePanel);
                var point = PointToScreen(relativePosition);

                int marginB = winH - ((int)point.Y + (int)SystemParameters.CaptionHeight + (int)SystemParameters.BorderWidth - 190);
                int marginR = winW - ((int)point.X + 60 + (int)SystemParameters.BorderWidth - 235);

                for (int i = 0; i < manifestations.Count; i++)
                {
                    if (manifestations.ElementAt(i).IdManifest.Equals(idManifOnCanvas))
                    {
                        manifestations.ElementAt(i).X_position = relativePosition.X - 35;
                        manifestations.ElementAt(i).Y_position = relativePosition.Y - 45;
                        manifestations.ElementAt(i).MarginB = marginB;
                        manifestations.ElementAt(i).MarginR = marginR;
                        break;
                    }
                }
            }
            idManifOnCanvas = "";
        }

        private void moveOnMaps(object sender, MouseEventArgs e)
        {
            doMove(sender, e);
        }

        private void manifMoveOnMaps(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            doMove(sender, e);
        }

        private void doMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (Mouse.OverrideCursor == Cursors.Hand)
                {
                    Button button = sender as Button;
                    if (button != null)
                    {
                        var relativePosition = e.GetPosition(imagePanel);
                        var point = PointToScreen(relativePosition);

                        int winH = (int)imagePanel.Height;
                        int winW = (int)imagePanel.Width;

                        int marginB = winH - ((int)point.Y + (int)SystemParameters.CaptionHeight + (int)SystemParameters.BorderWidth - 190);
                        int marginR = winW - ((int)point.X + 60 + (int)SystemParameters.BorderWidth - 235);

                        button.Margin = new Thickness(relativePosition.X - 35, relativePosition.Y - 45, marginR, marginB);
                        idManifOnCanvas = button.Name;

                        Mouse.OverrideCursor = Cursors.Hand;
                    }
                }
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private void doubleManifOnPane(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            int index = -1;
            if (button != null)
            {
                for (int i = 0; i < manifestations.Count; i++)
                {
                    if (manifestations.ElementAt(i).IdManifest.Equals(button.Name))
                    {
                        index = i;
                        break;
                    }
                }
                ChangeManifestDialog change_manifestation = new ChangeManifestDialog(index);
                change_manifestation.ShowDialog();
            }
        }

        private Button return_shape(Manifestation val)
        {
            Button b = new Button();
            b.Height = 70;
            b.Width = 70;

            b.Name = val.IdManifest;
            b.AllowDrop = false;
            b.MouseMove += manifMoveOnMaps;
            b.MouseDoubleClick += doubleManifOnPane;

            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(10);

            Image img = new Image();
            try
            {
                img.Source = new BitmapImage(new Uri(val.Icon, UriKind.Absolute));
            }
            catch (Exception)
            {

            }

            Label t = new Label();
            t.Content = val.Name;
            t.FontSize = 10;

            panel.Children.Add(img);
            panel.Children.Add(t);
            b.Content = panel;

            return b;
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            string search = searchBox.Text;
            if (search.Trim().Equals(""))
            {
                reset();
            }
            else
            {
                reset();
                foreach (Manifestation manif in treeView.Items)
                {
                    if (manif.Name.Contains(search))
                    {
                        TreeViewItem tvi = treeView.ItemContainerGenerator.ContainerFromItem(manif) as TreeViewItem;
                        tvi.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E5FFCC"));
                    }
                }
            }
        }

        private void reset()
        {
            foreach (Manifestation manif in treeView.Items)
            {
                TreeViewItem tvi = treeView.ItemContainerGenerator.ContainerFromItem(manif) as TreeViewItem;
                tvi.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF"));

            }
        }

        private void filter_btn_Click(object sender, RoutedEventArgs e)
        {
            string filter_type = filterBox.SelectedValue.ToString();
            if (filter_type.Equals("All"))
            {
                manifestationsInTree.Clear();
                for (int i = 0; i < manifestations.Count; i++)
                {
                    if (manifestations.ElementAt(i).X_position == -1 && manifestations.ElementAt(i).Y_position == -1)
                    {
                        manifestationsInTree.Add(manifestations.ElementAt(i));
                    }
                }
            }
            else
            {
                manifestationsInTree.Clear();
                for (int i = 0; i < manifestations.Count; i++)
                {
                    if (manifestations.ElementAt(i).X_position == -1 && manifestations.ElementAt(i).Y_position == -1 && manifestations.ElementAt(i).Type.Name.Equals(filter_type))
                    {
                        manifestationsInTree.Add(manifestations.ElementAt(i));
                    }
                }
            }
        }

        private void callHelp(object sender, RoutedEventArgs e)
        {
            string fileName = "HCIDocumentation.chm";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"HCIDoc\Main\", fileName);
            System.Diagnostics.Process.Start(path);
        }

        private void beginTutorial(object sender, RoutedEventArgs e)
        {
            TutorialExample te = new TutorialExample();
            Application.Current.MainWindow.Opacity = 0.5;

            te.ShowDialog();
            Application.Current.MainWindow.Opacity = 1;
        }
    }
}
