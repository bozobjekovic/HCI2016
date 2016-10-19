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
using Xceed.Wpf.Toolkit;

namespace main.Dialogs
{
    /// <summary>
    /// Interaction logic for AddTagDialog.xaml
    /// </summary>
    public partial class AddTagDialog : Window
    {
        private Tag tag;

        public AddTagDialog()
        {
            InitializeComponent();

            tag = new Tag();

            this.DataContext = tag;
        }

        private void addTagCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addTagBtn_Click(object sender, RoutedEventArgs e)
        {
            bool fillingOK = true;
            BindingExpression tagID = idTB.GetBindingExpression(TextBox.TextProperty);
            if (idTB.Text.Trim().Equals(""))
            {
                label9.Content = "ID is";
                label10.Content = "required!";
                fillingOK = false;
            }
            else
            {
                label9.Content = "";
                label10.Content = "";
                for (int i = 0; i < MainWindow.Tags.Count; i++)
                {
                    if (MainWindow.Tags.ElementAt(i).TadID.Equals(idTB.Text))
                    {
                        label9.Content = "ID";
                        label10.Content = "exists!";
                        fillingOK = false;
                        break;
                    }
                }
            }
            tagID.UpdateSource();
            BindingExpression tagColor = colorPicker.GetBindingExpression(ColorPicker.SelectedColorProperty);
            tagColor.UpdateSource();
            BindingExpression tagDescription = descrriptionTB.GetBindingExpression(TextBox.TextProperty);
            tagDescription.UpdateSource();

            if (fillingOK)
            {
                MainWindow.Tags.Add(tag);
                Close();
            }
        }

    }
}
