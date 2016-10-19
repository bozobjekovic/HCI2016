using main.Dialogs;
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
    /// Interaction logic for ChangeManifestDialog.xaml
    /// </summary>
    public partial class ChangeManifestDialog : Window
    {
        private Manifestation selectedManifestation;

        public ChangeManifestDialog(int index)
        {
            InitializeComponent();

            selectedManifestation = MainWindow.Manifestations.ElementAt(index);

            this.DataContext = this;
        }

        public Manifestation SelectedManifestation
        {
            get
            {
                return selectedManifestation;
            }

            set
            {
                selectedManifestation = value;
            }
        }

        private void cancelAddManBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void saveManifestBtn_Click(object sender, RoutedEventArgs e)
        {
            bool fillingOK = true;

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

            if (fillingOK)
            {
                BindingExpression manifID = manifestID.GetBindingExpression(TextBox.TextProperty);
                manifID.UpdateSource();
                BindingExpression manifName = name.GetBindingExpression(TextBox.TextProperty);
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
                updateManifestInTree();
                Close();
            }
        }

        private void updateManifestInTree()
        {
            for (int i = 0; i < MainWindow.ManifestationsInTree.Count; i++)
            {
                if (MainWindow.ManifestationsInTree.ElementAt(i).IdManifest.Equals(selectedManifestation.IdManifest))
                {
                    MainWindow.ManifestationsInTree.ElementAt(i).Name = selectedManifestation.Name;
                    MainWindow.ManifestationsInTree.ElementAt(i).Description = selectedManifestation.Description;
                    MainWindow.ManifestationsInTree.ElementAt(i).Type = selectedManifestation.Type;
                    MainWindow.ManifestationsInTree.ElementAt(i).ServeAlcosol = selectedManifestation.ServeAlcosol;
                    MainWindow.ManifestationsInTree.ElementAt(i).Icon = selectedManifestation.Icon;
                    MainWindow.ManifestationsInTree.ElementAt(i).ForHandicap = selectedManifestation.ForHandicap;
                    MainWindow.ManifestationsInTree.ElementAt(i).SmokingAllowed = selectedManifestation.SmokingAllowed;
                    MainWindow.ManifestationsInTree.ElementAt(i).IsOutside = selectedManifestation.IsOutside;
                    MainWindow.ManifestationsInTree.ElementAt(i).PriceCategory = selectedManifestation.PriceCategory;
                    MainWindow.ManifestationsInTree.ElementAt(i).ExpectedAudience = selectedManifestation.ExpectedAudience;
                    MainWindow.ManifestationsInTree.ElementAt(i).Date = selectedManifestation.Date;
                    break;
                }
            }
            for (int i = 0; i < MainWindow.ManifestationsOnBoard.Count; i++)
            {
                if (MainWindow.ManifestationsOnBoard.ElementAt(i).IdManifest.Equals(selectedManifestation.IdManifest))
                {
                    MainWindow.ManifestationsOnBoard.ElementAt(i).Name = selectedManifestation.Name;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).Description = selectedManifestation.Description;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).Type = selectedManifestation.Type;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).ServeAlcosol = selectedManifestation.ServeAlcosol;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).Icon = selectedManifestation.Icon;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).ForHandicap = selectedManifestation.ForHandicap;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).SmokingAllowed = selectedManifestation.SmokingAllowed;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).IsOutside = selectedManifestation.IsOutside;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).PriceCategory = selectedManifestation.PriceCategory;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).ExpectedAudience = selectedManifestation.ExpectedAudience;
                    MainWindow.ManifestationsOnBoard.ElementAt(i).Date = selectedManifestation.Date;
                    updateBtn();
                    break;
                }
            }
        }

        private void updateBtn()
        {
            Button updBtn = (Button)LogicalTreeHelper.FindLogicalNode(MainWindow.canvas, selectedManifestation.IdManifest);

            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(10);

            Image img = new Image();
            try
            {
                img.Source = new BitmapImage(new Uri(selectedManifestation.Icon, UriKind.Absolute));
            }
            catch (Exception)
            {

            }

            Label t = new Label();
            t.Content = selectedManifestation.Name;
            t.FontSize = 10;

            panel.Children.Add(img);
            panel.Children.Add(t);
            updBtn.Content = panel;
        }

        private void addTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddManifestTypeDialog amtd = new AddManifestTypeDialog();
            amtd.ShowDialog();
        }
    }
}
