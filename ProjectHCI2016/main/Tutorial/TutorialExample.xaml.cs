using Microsoft.Win32;
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

namespace main.Tutorial
{
    /// <summary>
    /// Interaction logic for TutorialExample.xaml
    /// </summary>
    public partial class TutorialExample : Window
    {
        public TutorialExample()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string url = openFileDialog.FileName;
                image.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

                imageBorder.Opacity = 0;
                descriptBorder.Opacity = 1;
                browseBtn.IsEnabled = false;
                descriptionTB.IsEnabled = true;
                label2.FontWeight = FontWeights.Normal;
                label3.FontWeight = FontWeights.Bold;
                label7.Content = "";
                label8.Content = "Type this and press enter";
            }
        }

        private void addTypeBtn_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }

        private void cancel_addBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void finish1Step(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                firstBorder.Opacity = 0;
                nameBorder.Opacity = 1;
                idTB.IsEnabled = false;
                nameTB.IsEnabled = true;
                label.FontWeight = FontWeights.Normal;
                label1.FontWeight = FontWeights.Bold;
                label5.Content = "";
                label6.Content = "Type NAME and press enter";
            }
        }

        private void secondStep(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                nameBorder.Opacity = 0;
                imageBorder.Opacity = 1;
                nameTB.IsEnabled = false;
                browseBtn.IsEnabled = true;
                label1.FontWeight = FontWeights.Normal;
                label2.FontWeight = FontWeights.Bold;
                label6.Content = "";
                label7.Content = "Choose image";
            }
        }

        private void fourthStep(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                descriptBorder.Opacity = 0;
                descriptionTB.IsEnabled = false;
                addTypeBtn.IsEnabled = true;
                cancel_addBtn.IsEnabled = true;
                label3.FontWeight = FontWeights.Normal;
                label8.Content = "";
                this.Background.Opacity = 1;
                this.Height = 550;
                addTypeBtn.Margin = new Thickness(105, 462, 0, 0);
                cancel_addBtn.Margin = new Thickness(187, 462, 0, 0);
                label9.Content = "Now, when you filled all fields you can";
                label10.Content = "click on 'Add' button and add Type or";
                label11.Content = "click on 'Cancel' button and cancel operation.";
            }
        }
    }
}
