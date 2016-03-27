using Microsoft.Win32;
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

namespace main.Dialogs
{
    /// <summary>
    /// Interaction logic for AddManifestTypeDialog.xaml
    /// </summary>
    public partial class AddManifestTypeDialog : Window
    {
        private ManifestationType manifestationType;

        private ObservableCollection<ManifestationType> manifTypes;

        public AddManifestTypeDialog(ObservableCollection<ManifestationType> manifTypes)
        {
            InitializeComponent();

            manifestationType = new ManifestationType();
            this.manifTypes = manifTypes;

            this.DataContext = manifestationType;
        }

        private void cancel_addBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression manifTypeID = idTB.GetBindingExpression(TextBox.TextProperty);
            manifTypeID.UpdateSource();
            BindingExpression manifTypeName = nameTB.GetBindingExpression(TextBox.TextProperty);
            manifTypeName.UpdateSource();
            BindingExpression manifTypeDescpt = descriptionTB.GetBindingExpression(TextBox.TextProperty);
            manifTypeDescpt.UpdateSource();

            manifTypes.Add(manifestationType);
            Close();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string url = openFileDialog.FileName;
                manifestationType.Icon = new BitmapImage(new Uri(url, UriKind.Absolute));
                iconTB.Text = url;
            }
        }
    }
}
