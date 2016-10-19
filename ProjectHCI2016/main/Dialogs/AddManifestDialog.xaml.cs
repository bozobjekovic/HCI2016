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
using model;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using Xceed.Wpf.Toolkit;
using main;

namespace main.Dialogs
{
    /// <summary>
    /// Interaction logic for AddManifestDialog.xaml
    /// </summary>
    public partial class AddManifestDialog : Window
    {
        private Manifestation manifestation;

        public AddManifestDialog()
        {
            InitializeComponent();
            dateManifPicker.SelectedDate = DateTime.Now.Date;
            dateManifPicker.DisplayDateStart = DateTime.Now.Date;

            setDefault();

            manifestation = new Manifestation();

            this.DataContext = manifestation;
        }

        private void cancelAddManBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void setDefault()
        {
            typeCmbx.SelectedIndex = 0;
            alcosolCmbx.SelectedIndex = 0;
            priceCmbx.SelectedIndex = 0;
            audienceCmbx.SelectedIndex = 0;
        }

        private void addManifestBtn_Click(object sender, RoutedEventArgs e)
        {
            bool fillingOK = true;
            BindingExpression manifID = manifestID.GetBindingExpression(TextBox.TextProperty);
            if (manifestID.Text.Trim().Equals(""))
            {
                IDflabel14.Content = "ID is";
                IDslabel15.Content = "required!";
                fillingOK = false;
            }
            else
            {
                IDflabel14.Content = "";
                IDslabel15.Content = "";
                for (int i = 0; i < MainWindow.Manifestations.Count; i++)
                {
                    if (MainWindow.Manifestations.ElementAt(i).IdManifest.Equals(manifestID.Text))
                    {
                        IDflabel14.Content = "ID";
                        IDslabel15.Content = "exists!";
                        fillingOK = false;
                        break;
                    }
                }
            }
            manifID.UpdateSource();
            BindingExpression manifName = name.GetBindingExpression(TextBox.TextProperty);
            if (name.Text.Trim().Equals(""))
            {
                Nlabel16f.Content = "Name is";
                Nlabel17s.Content = "required!";
                fillingOK = false;
            }
            else
            {
                Nlabel16f.Content = "";
                Nlabel17s.Content = "";
            }
            manifName.UpdateSource();
            BindingExpression manifDescript = description.GetBindingExpression(TextBox.TextProperty);
            manifDescript.UpdateSource();
            BindingExpression manifType = typeCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifType.UpdateSource();
            BindingExpression manifAlcosol = alcosolCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifAlcosol.UpdateSource();
            BindingExpression manifImage = image.GetBindingExpression(Image.SourceProperty);
            manifImage.UpdateSource();
            BindingExpression manifHandicapYes = handipYes.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifHandicapYes.UpdateSource();
            BindingExpression manifHandicapNo = handipNo.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifHandicapNo.UpdateSource();
            BindingExpression manifSmokingYes = smokingYes.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifSmokingYes.UpdateSource();
            BindingExpression manifSmokingNo = smokingNo.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifSmokingNo.UpdateSource();
            BindingExpression manifInsade = insadeYes.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifInsade.UpdateSource();
            BindingExpression manifOutside = outsideNo.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifOutside.UpdateSource();
            BindingExpression manifPrice = priceCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifPrice.UpdateSource();
            BindingExpression manifAudience = audienceCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifAudience.UpdateSource();
            BindingExpression manifDate = dateManifPicker.GetBindingExpression(DatePicker.SelectedDateProperty);
            manifDate.UpdateSource();

            if (image.Source == null)
            {
                if (manifestation.Type != null)
                {
                    manifestation.Icon = manifestation.Type.Icon;
                }
            }

            if (fillingOK)
            {
                MainWindow.Manifestations.Add(manifestation);
                MainWindow.ManifestationsInTree.Add(manifestation);
                Close();
            }
        }

        private void addTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestTypeDialog amtd = new AddManifestTypeDialog();
            amtd.ShowDialog();
            for (int i = 0; i < MainWindow.ManifestTypes.Count; i++)
            {
                Console.WriteLine(MainWindow.ManifestTypes.ElementAt(i));
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

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            throw new NotImplementedException();
        }
    }
}
