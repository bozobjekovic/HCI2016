using Microsoft.Win32;
using model;
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

namespace main.Change_Dialogs
{
    /// <summary>
    /// Interaction logic for ChangeManifestTypeDialog.xaml
    /// </summary>
    public partial class ChangeManifestTypeDialog : Window
    {
        private ManifestationType selectedManifestationType;

        private int pos;

        public ChangeManifestTypeDialog(int index)
        {
            InitializeComponent();

            pos = index;
            selectedManifestationType = MainWindow.ManifestTypes.ElementAt(index);

            this.DataContext = this;
        }

        public ManifestationType SelectedManifestationType
        {
            get
            {
                return selectedManifestationType;
            }

            set
            {
                selectedManifestationType = value;
            }
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string url = openFileDialog.FileName;
                image.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
            }
        }

        private void saveTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            bool fillingOK = true;
            if (nameTB.Text.Trim().Equals(""))
            {
                label7.Content = "Name is";
                label8.Content = "required!";
                fillingOK = false;
            }
            else
            {
                label7.Content = "";
                label8.Content = "";
            }

            if (image.Source == null)
            {
                label9.Content = "Image is";
                label10.Content = "required!";
                fillingOK = false;
            }
            else
            {
                label9.Content = "";
                label10.Content = "";
            }

            if (fillingOK)
            {
                BindingExpression manifTypeID = idTB.GetBindingExpression(TextBox.TextProperty);
                manifTypeID.UpdateSource();
                BindingExpression manifTypeName = nameTB.GetBindingExpression(TextBox.TextProperty);
                manifTypeName.UpdateSource();
                BindingExpression manifTypeImage = image.GetBindingExpression(Image.SourceProperty);
                manifTypeImage.UpdateSource();
                BindingExpression manifTypeDescpt = descriptionTB.GetBindingExpression(TextBox.TextProperty);
                manifTypeDescpt.UpdateSource();
                updateCMX();
                Close();
            }
        }

        private void updateCMX()
        {
            MainWindow.ActiveTypes[pos+1] = selectedManifestationType.Name;
        }

        private void cancel_addBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
