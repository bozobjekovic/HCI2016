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

namespace main.Dialogs
{
    /// <summary>
    /// Interaction logic for AddManifestDialog.xaml
    /// </summary>
    public partial class AddManifestDialog : Window
    {
        private Manifestation manifestation;

        private List<Manifestation> manifestations;
        private ObservableCollection<ManifestationType> manifTypes;

        public AddManifestDialog(List<Manifestation> manifs, ObservableCollection<ManifestationType> types)
        {
            InitializeComponent();

            manifestation = new Manifestation();
            manifestations = manifs;
            manifTypes = types;

            this.DataContext = manifestation;
            typeCmbx.DataContext = this;
        }

        private void cancelAddManBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addManifestBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression manifID = manifestID.GetBindingExpression(TextBox.TextProperty);
            manifID.UpdateSource();
            BindingExpression manifName = name.GetBindingExpression(TextBox.TextProperty);
            manifName.UpdateSource();
            BindingExpression manifDescript = description.GetBindingExpression(TextBox.TextProperty);
            manifDescript.UpdateSource();
            BindingExpression manifAlcosol = alcosolCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifAlcosol.UpdateSource();
            BindingExpression manifHandicapYes = handipYes.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifHandicapYes.UpdateSource();
            BindingExpression manifHandicapNo = handipNo.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifHandicapNo.UpdateSource();
            BindingExpression manifSmokingYes = smokingYes.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifSmokingYes.UpdateSource();
            BindingExpression manifSmokingNo = smokingNo.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifSmokingNo.UpdateSource();
            BindingExpression manifInsade =insadeYes.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifInsade.UpdateSource();
            BindingExpression manifOutside = outsideNo.GetBindingExpression(RadioButton.IsCheckedProperty);
            manifOutside.UpdateSource();
            BindingExpression manifPrice = priceCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifPrice.UpdateSource();
            BindingExpression manifAudience = audienceCmbx.GetBindingExpression(ComboBox.SelectedValueProperty);
            manifAudience.UpdateSource();
            BindingExpression manifDate = dateManifPicker.GetBindingExpression(DatePicker.SelectedDateProperty);
            manifDate.UpdateSource();
            manifestations.Add(manifestation);
            Close();
        }

        private void addTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestTypeDialog amtd = new AddManifestTypeDialog(manifTypes);
            amtd.ShowDialog();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string url = openFileDialog.FileName;
                manifestation.Icon = new BitmapImage(new Uri(url, UriKind.Absolute));
                iconPath.Text = url;
            }
        }

        public ObservableCollection<ManifestationType> ManifTypes
        {
            get
            {
                return manifTypes;
            }

            set
            {
                manifTypes = value;
            }
        }
    }
}
