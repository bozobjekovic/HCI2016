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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Manifestation> manifestations = new List<Manifestation>();
        private ObservableCollection<ManifestationType> manifestTypes = new ObservableCollection<ManifestationType>();
        private List<Tag> tags = new List<Tag>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_manifest_btn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestDialog amd = new AddManifestDialog(manifestations, manifestTypes);
            amd.ShowDialog();
            for (int i = 0; i < manifestations.Count; i++)
            {
                Console.WriteLine(manifestations.ElementAt(i));
            }
        }

        private void add_tag_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTagDialog atd = new AddTagDialog(tags);
            atd.ShowDialog();
            for (int i = 0; i < tags.Count; i++)
            {
                Console.WriteLine(tags.ElementAt(i));
            }
        }

        private void add_manifetsType_btn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestTypeDialog amtd = new AddManifestTypeDialog(manifestTypes);
            amtd.ShowDialog();
            for (int i = 0; i < manifestTypes.Count; i++)
            {
                Console.WriteLine(manifestTypes.ElementAt(i));
            }
        }

        public ObservableCollection<ManifestationType> ManifestTypes
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
    }
}
