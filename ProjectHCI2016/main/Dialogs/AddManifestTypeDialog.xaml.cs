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

        public AddManifestTypeDialog()
        {
            InitializeComponent();

            manifestationType = new ManifestationType();

            this.DataContext = manifestationType;
        }

        private void cancel_addBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            bool fillingOK = true;
            BindingExpression manifTypeID = idTB.GetBindingExpression(TextBox.TextProperty);
            if (idTB.Text.Trim().Equals(""))
            {
                label5.Content = "ID is";
                label6.Content = "required!";
                fillingOK = false;
            }
            else
            {
                label5.Content = "";
                label6.Content = "";
                for (int i = 0; i < MainWindow.ManifestTypes.Count; i++)
                {
                    if (MainWindow.ManifestTypes.ElementAt(i).IdManifestType.Equals(idTB.Text))
                    {
                        label5.Content = "ID";
                        label6.Content = "exists!";
                        fillingOK = false;
                        break;
                    }
                }
            }
            manifTypeID.UpdateSource();
            BindingExpression manifTypeName = nameTB.GetBindingExpression(TextBox.TextProperty);
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
            manifTypeName.UpdateSource();
            BindingExpression manifTypeImage = image.GetBindingExpression(Image.SourceProperty);
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
            manifTypeImage.UpdateSource();
            BindingExpression manifTypeDescpt = descriptionTB.GetBindingExpression(TextBox.TextProperty);
            manifTypeDescpt.UpdateSource();

            if (fillingOK)
            {
                MainWindow.ManifestTypes.Add(manifestationType);
                MainWindow.ActiveTypes.Add(manifestationType.Name);
                Close();
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
    }
}
